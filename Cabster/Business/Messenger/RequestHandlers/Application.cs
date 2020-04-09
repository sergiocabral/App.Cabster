using System.Threading;
using System.Threading.Tasks;
using Cabster.Business.Messenger.Notification;
using Cabster.Business.Messenger.Request;
using Cabster.Components;
using Cabster.Infrastructure;
using MediatR;
using Serilog;

namespace Cabster.Business.Messenger.RequestHandlers
{
    /// <summary>
    ///     Tarefas gerais sobre a aplicação.
    /// </summary>
    public class Application :
        MessengerHandler,
        IRequestHandler<InitializeApplication>,
        IRequestHandler<SinalizeApplicationClock>,
        IRequestHandler<FinalizeApplication>
    {
        /// <summary>
        ///     Janela principal do sistema.
        /// </summary>
        private readonly FormMainWindow _formMainWindow;

        /// <summary>
        ///     Barramento de mensagens.
        /// </summary>
        private readonly IMediator _messageBus;

        /// <summary>
        ///     Construtor.
        /// </summary>
        /// <param name="messageBus">IMediator</param>
        /// <param name="formMainWindow">Janela principal do sistema.</param>
        public Application(IMediator messageBus, FormMainWindow formMainWindow)
        {
            _messageBus = messageBus;
            _formMainWindow = formMainWindow;
        }

        /// <summary>
        ///     Processa o comando: FinalizeApplication
        /// </summary>
        /// <param name="request">Comando</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Task</returns>
        public Task<Unit> Handle(FinalizeApplication request, CancellationToken cancellationToken)
        {
            Log.Information("Application finalized.");
            _formMainWindow.Close();
            return Unit.Task;
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
            _messageBus.Publish(new ApplicationInitialized(request), cancellationToken);
            System.Windows.Forms.Application.Run(_formMainWindow);
            return Unit.Task;
        }

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