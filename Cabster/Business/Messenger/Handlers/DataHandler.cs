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
        IRequestHandler<DataSave>,
        IRequestHandler<DataLoad>,
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
                _messageBus.Send(new DataSave(), cancellationToken);

            return Unit.Task;
        }

        /// <summary>
        ///     Processa o comando: DataLoad
        /// </summary>
        /// <param name="request">Comando</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Task</returns>
        public Task<Unit> Handle(DataLoad request, CancellationToken cancellationToken)
        {
            var data = _dataManipulation.LoadFromFile();

            if (data != null)
            {
                _messageBus.Publish(new DataLoaded(request), cancellationToken);
                _messageBus.Send(new DataUpdate(data, DataSection.All, true), cancellationToken);
                Log.Debug("Application data was loaded from: {Path}", _dataManipulation.Path);
            }
            else
            {
                Log.Debug("Application data cannot be loaded because the file does not exist in: {Path}",
                    _dataManipulation.Path);
            }

            return Unit.Task;
        }

        /// <summary>
        ///     Processa o comando: DataSave
        /// </summary>
        /// <param name="request">Comando</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Task</returns>
        public Task<Unit> Handle(DataSave request, CancellationToken cancellationToken)
        {
            var data = Program.Data;

            _dataManipulation.SaveToFile(data);

            Log.Debug("Application data saved to: {Path}", _dataManipulation.Path);

            _messageBus.Publish(new DataSaved(request), cancellationToken);

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