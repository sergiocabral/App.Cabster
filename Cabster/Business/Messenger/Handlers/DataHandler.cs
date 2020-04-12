using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Cabster.Business.Entities;
using Cabster.Business.Enums;
using Cabster.Business.Messenger.Notification;
using Cabster.Business.Messenger.Request;
using Cabster.Infrastructure;
using MediatR;
using Serilog;

namespace Cabster.Business.Messenger.Handlers
{
    /// <summary>
    ///     Operações de atualização de dados da aplicação.
    /// </summary>
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
            if (!notification.Request.AvoidDataSave)
                _messageBus.Send(new DataSaveToFile(), cancellationToken);

            return Unit.Task;
        }

        /// <summary>
        ///     Processa o comando: DataLoadFromFile
        /// </summary>
        /// <param name="request">Comando</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Task</returns>
        public Task<Unit> Handle(DataLoadFromFile request, CancellationToken cancellationToken)
        {
            try
            {
                var data = _dataManipulation.LoadFromFile();

                if (data != null)
                {
                    Log.Debug("Application data was loaded from: {Path}", _dataManipulation.Path);
                    _messageBus.Publish(new DataLoadedFromFile(request), cancellationToken);
                    _messageBus.Send(new DataUpdate(data, DataSection.All, true), cancellationToken);
                }
                else
                {
                    Log.Debug("Application data cannot be loaded because the file does not exist in: {Path}",
                        _dataManipulation.Path);
                }
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Application data cannot load from: {Path}", _dataManipulation.Path);
            }

            return Unit.Task;
        }

        /// <summary>
        ///     Processa o comando: DataSaveToFile
        /// </summary>
        /// <param name="request">Comando</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Task</returns>
        public Task<Unit> Handle(DataSaveToFile request, CancellationToken cancellationToken)
        {
            var data = Program.Data;

            try
            {
                _dataManipulation.SaveToFile(data);

                Log.Debug("Application data saved to: {Path}", _dataManipulation.Path);

                _messageBus.Publish(new DataSavedToFile(request), cancellationToken);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Application data cannot save to: {Path}", _dataManipulation.Path);
            }

            return Unit.Task;
        }

        /// <summary>
        ///     Processa o comando: DataUpdate
        /// </summary>
        /// <param name="request">Comando</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Task</returns>
        public Task<Unit> Handle(DataUpdate request, CancellationToken cancellationToken)
        {
            if (_programData == null)
                _programData = typeof(Program)
                    .GetFields(BindingFlags.Static | BindingFlags.NonPublic)
                    .Single(f => f.FieldType == typeof(ContainerData));
            _programData.SetValue(null, request.Data);

            Log.Debug("Application data updated. Sections: {Data}", request.Section);

            _messageBus.Publish(new DataUpdated(request), cancellationToken)
                .Wait(cancellationToken);

            return Unit.Task;
        }
    }
}