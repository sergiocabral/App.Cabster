using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Cabrones.Utils.Text;
using Cabster.Business.Entities;
using Cabster.Business.Messenger.Notification;
using Cabster.Business.Messenger.Request;
using Cabster.Business.Values;
using Cabster.Infrastructure;
using Cabster.Properties;
using MediatR;
using Serilog;

namespace Cabster.Business.Messenger.Handlers
{
    /// <summary>
    ///     Operações de atualização de dados da aplicação.
    /// </summary>
    // ReSharper disable once UnusedType.Global
    public class DataHandler :
        MessengerHandler,
        IRequestHandler<DataUpdate>,
        IRequestHandler<DataSaveToFile>,
        IRequestHandler<DataLoadFromFile>,
        INotificationHandler<DataUpdated>
    {
        /// <summary>
        ///     Acesso direto ao repositório de dados da aplicação.
        /// </summary>
        private static FieldInfo? _programData;

        /// <summary>
        ///     Cronômetro para DataSaveToFile efetivar a função depois de 1 segundo.
        /// </summary>
        private static Stopwatch? _stopwatchDataSaveToFile;

        /// <summary>
        ///     Manipulação de dados.
        /// </summary>
        private readonly IDataManipulation _dataManipulation;

        /// <summary>
        ///     Barramento de mensagens.
        /// </summary>
        private readonly IMediator _messageBus;

        /// <summary>
        ///     Construtor.
        /// </summary>
        /// <param name="messageBus">IMediator</param>
        /// <param name="dataManipulation">Manipulação de dados.</param>
        public DataHandler(IMediator messageBus, IDataManipulation dataManipulation)
        {
            _messageBus = messageBus;
            _dataManipulation = dataManipulation;
        }

        /// <summary>
        ///     Processa o evento: DataUpdated
        /// </summary>
        /// <param name="notification">DataUpdated</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Task</returns>
        public Task Handle(DataUpdated notification, CancellationToken cancellationToken)
        {
            return !notification.Request.AvoidSaveToFile
                ? _messageBus.Send(new DataSaveToFile(), cancellationToken)
                : Unit.Task;
        }

        /// <summary>
        ///     Processa o comando: DataLoadFromFile
        /// </summary>
        /// <param name="request">Comando</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Task</returns>
        public async Task<Unit> Handle(DataLoadFromFile request, CancellationToken cancellationToken)
        {
            try
            {
                var data = _dataManipulation.LoadFromFile();

                if (data != null)
                {
                    Log.Debug("Application data was loaded from: {Path}", _dataManipulation.Path);
                    await _messageBus.Publish(new DataLoadedFromFile(request), cancellationToken);
                    await _messageBus.Send(new DataUpdate(data, DataSection.All, true), cancellationToken);
                }
                else
                {
                    Log.Debug("Application data cannot be loaded because the file does not exist in: {Path}",
                        _dataManipulation.Path);

                    data = Program.Data;
                    await _messageBus.Send(new DataSaveToFile {SaveImmediately = true}, cancellationToken);
                    await _messageBus.Send(new DataUpdate(data, DataSection.All, true), cancellationToken);
                }
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Application data cannot load from: {Path}", _dataManipulation.Path);
            }

            return Unit.Value;
        }

        /// <summary>
        ///     Processa o comando: DataSaveToFile
        /// </summary>
        /// <param name="request">Comando</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Task</returns>
        public async Task<Unit> Handle(DataSaveToFile request, CancellationToken cancellationToken)
        {
            const int delayToCheck = 100;
            const int delayToAction = 500;

            if (!request.SaveImmediately)
                Log.Verbose("Application data save requested. Waiting {Milliseconds} milliseconds.",
                    delayToAction);
            else if (_stopwatchDataSaveToFile != null)
                Log.Verbose(
                    "Application data save immediately requested, but there is a task in progress that must be awaited.");
            else
                Log.Verbose("Application data save immediately requested.");

            if (_stopwatchDataSaveToFile != null)
            {
                _stopwatchDataSaveToFile.Restart();

                return await Task.Run(async () =>
                {
                    while (_stopwatchDataSaveToFile != null) await Task.Delay(delayToCheck, cancellationToken);
                    return Unit.Value;
                }, cancellationToken);
            }

            _stopwatchDataSaveToFile = new Stopwatch();
            _stopwatchDataSaveToFile.Start();

            while (!request.SaveImmediately &&
                   _stopwatchDataSaveToFile != null &&
                   _stopwatchDataSaveToFile.ElapsedMilliseconds < delayToAction)
                await Task.Delay(delayToCheck, cancellationToken);

            var data = Program.Data;

            try
            {
                _dataManipulation.SaveToFile(data);

                Log.Debug("Application data saved to: {Path}", _dataManipulation.Path);

                await _messageBus.Publish(new DataSavedToFile(request), cancellationToken);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Application data cannot save to: {Path}", _dataManipulation.Path);
            }

            _stopwatchDataSaveToFile = null;

            return Unit.Value;
        }

        /// <summary>
        ///     Processa o comando: DataUpdate
        /// </summary>
        /// <param name="request">Comando</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Task</returns>
        public async Task<Unit> Handle(DataUpdate request, CancellationToken cancellationToken)
        {
            if (_programData == null)
                _programData = typeof(Program)
                    .GetFields(BindingFlags.Static | BindingFlags.NonPublic)
                    .Single(f => f.FieldType == typeof(ContainerData));

            if (DataSection.ApplicationLanguage == (DataSection.ApplicationLanguage & request.Section) &&
                CultureInfo.DefaultThreadCurrentCulture?.TwoLetterISOLanguageName != request.Data.Application.Language)
            {
                var fromLanguage = CultureInfo.DefaultThreadCurrentUICulture != null
                    ? CultureInfo.DefaultThreadCurrentUICulture
                    : CultureInfo.InstalledUICulture;
                var toLanguage = request.Data.Application.Language.ToCultureInfo();

                if (fromLanguage.TwoLetterISOLanguageName != toLanguage.TwoLetterISOLanguageName)
                {
                    CultureInfo.DefaultThreadCurrentUICulture =
                        CultureInfo.DefaultThreadCurrentCulture =
                            toLanguage;

                    Log.Debug("Changed application language from {fromLanguage} to {toLanguage}.",
                        $"{fromLanguage.TwoLetterISOLanguageName}, {fromLanguage.DisplayName},",
                        $"{toLanguage.TwoLetterISOLanguageName}, {toLanguage.DisplayName}");

                    await _messageBus.Send(
                        new UserNotificationPost(
                            new NotificationMessage(Resources.Notification_LanguageChanged.QueryString(
                                fromLanguage.TwoLetterISOLanguageName.ToLanguageName().ToLower(),
                                toLanguage.TwoLetterISOLanguageName.ToLanguageName().ToLower()
                            ))), cancellationToken);
                }
            }

            _programData.SetValue(null, request.Data);

            Log.Debug("Application data updated. Sections: {Data}", request.Section);

            await _messageBus.Publish(new DataUpdated(request), cancellationToken);

            return Unit.Value;
        }
    }
}