using System.Threading;
using System.Threading.Tasks;
using Cabster.Business.Messenger.Notification;
using Cabster.Business.Messenger.Request;
using Cabster.Infrastructure;
using MediatR;

namespace Cabster.Business.Messenger.RequestHandlers
{
    /// <summary>
    ///     Tarefas relacionadas ao clock.
    /// </summary>
    public class Clock :
        MessengerHandler,
        IRequestHandler<SinalizeApplicationClock>
    {
        /// <summary>
        ///     Barramento de mensagens.
        /// </summary>
        private readonly IMediator _messageBus;

        /// <summary>
        ///     Construtor.
        /// </summary>
        /// <param name="messageBus">IMediator</param>
        public Clock(IMediator messageBus)
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
        public Task<Unit> Handle(SinalizeApplicationClock request, CancellationToken cancellationToken)
        {
            _messageBus.Publish(new ApplicationClockSignaled(request), cancellationToken);
            return Unit.Task;
        }
    }
}