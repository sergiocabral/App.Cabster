using System.Threading;
using System.Threading.Tasks;
using Cabster.Business.Enums;
using Cabster.Business.Messenger.Notification;
using Cabster.Business.Messenger.Request;
using Cabster.Infrastructure;
using MediatR;
using Serilog;

namespace Cabster.Business.Messenger.RequestHandlers
{
    /// <summary>
    /// Operações de atualização de dados da aplicação.
    /// </summary>
    public class Data:
        MessengerHandler,
        IRequestHandler<DataUpdate>
    {
        /// <summary>
        ///     Barramento de mensagens.
        /// </summary>
        private readonly IMediator _messageBus;

        /// <summary>
        ///     Construtor.
        /// </summary>
        /// <param name="messageBus">IMediator</param>
        public Data(IMediator messageBus)
        {
            _messageBus = messageBus;
        }
        
        /// <summary>
        ///     Processa o comando: DataUpdate
        /// </summary>
        /// <param name="request">Comando</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Task</returns>
        public Task<Unit> Handle(DataUpdate request, CancellationToken cancellationToken)
        {
            Program.Data = request.Data;
            
            Log.Debug("Application data updated. Sections: {Data}", request.Section);
            
            _messageBus.Publish(new DataUpdated(request), cancellationToken)
                .Wait(cancellationToken);

            return Unit.Task;
        }
    }
}