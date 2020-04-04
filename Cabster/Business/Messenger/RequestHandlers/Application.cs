using System.Threading;
using System.Threading.Tasks;
using Cabster.Business.Messenger.Notification;
using Cabster.Business.Messenger.Request;
using Cabster.Infrastructure;
using MediatR;
using Serilog;

namespace Cabster.Business.Messenger.RequestHandlers
{
    /// <summary>
    ///     Tarefas gerais sobre a aplicação.
    /// </summary>
    public class Application : MessengerHandler, IRequestHandler<InitializeApplication>
    {
        /// <summary>
        ///     IMediator
        /// </summary>
        private readonly IMediator _mediator;

        /// <summary>
        ///     Construtor.
        /// </summary>
        /// <param name="mediator">IMediator</param>
        public Application(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        ///     Processa o comando: InitializeApplication
        /// </summary>
        /// <param name="request">Comando</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Task</returns>
        public Task<Unit> Handle(InitializeApplication request, CancellationToken cancellationToken)
        {
            Log.Information("Application started.");
            _mediator.Publish(new ApplicationInitialized(request), cancellationToken);
            return Unit.Task;
        }
    }
}