using System.Threading;
using System.Threading.Tasks;
using Cabster.Business.Messenger.Notification;
using Cabster.Business.Messenger.Request;
using Cabster.Infrastructure;
using MediatR;

namespace Cabster.Business.Messenger.Handlers
{
    /// <summary>
    ///     Tarefas relacionadas ao clock.
    /// </summary>
    public class ClockHandler :
        MessengerHandler,
        IRequestHandler<ClockSinalize>
    {
        /// <summary>
        ///     Barramento de mensagens.
        /// </summary>
        private readonly IMediator _messageBus;

        /// <summary>
        ///     Construtor.
        /// </summary>
        /// <param name="messageBus">IMediator</param>
        public ClockHandler(IMediator messageBus)
        {
            _messageBus = messageBus;
        }

        /// <summary>
        ///     Ignora o log desse Request.
        /// </summary>
        protected override bool IgnoreLog { get; } = true;

        /// <summary>
        ///     Processa o comando: SinalizeApplicationClock
        /// </summary>
        /// <param name="request">Comando</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Task</returns>
        public Task<Unit> Handle(ClockSinalize request, CancellationToken cancellationToken)
        {
            _messageBus.Publish(new ClockSignaled(request), cancellationToken);
            return Unit.Task;
        }
    }
}