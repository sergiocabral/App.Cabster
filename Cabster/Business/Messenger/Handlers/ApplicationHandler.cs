using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cabster.Business.Enums;
using Cabster.Business.Messenger.Request;
using Cabster.Components;
using Cabster.Infrastructure;
using MediatR;
using Serilog;

namespace Cabster.Business.Messenger.Handlers
{
    /// <summary>
    ///     Tarefas gerais sobre a aplicação.
    /// </summary>
    public class ApplicationHandler :
        MessengerHandler,
        IRequestHandler<ApplicationInitialize>,
        IRequestHandler<ApplicationFinalize>,
        IRequestHandler<ApplicationChangeLanguage>
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
        public ApplicationHandler(IMediator messageBus, FormMainWindow formMainWindow)
        {
            _messageBus = messageBus;
            _formMainWindow = formMainWindow;
        }

        /// <summary>
        ///     Processa o comando: ApplicationChangeLanguage
        /// </summary>
        /// <param name="request">Comando</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Task</returns>
        public async Task<Unit> Handle(ApplicationChangeLanguage request, CancellationToken cancellationToken)
        {
            Log.Information("Changing application language from {fromLanguage} to {toLanguage}.",
                CultureInfo.CurrentUICulture.TwoLetterISOLanguageName,
                request.NewLanguage.TwoLetterISOLanguageName);

            Program.RestartWhenClose = true;

            var data = Program.Data;
            data.Application.Language = request.NewLanguage.TwoLetterISOLanguageName;

            await _messageBus.Send(new DataUpdate(data, DataSection.ApplicationLanguage), cancellationToken);

            await _messageBus.Send(new ApplicationFinalize(), cancellationToken);

            return Unit.Value;
        }

        /// <summary>
        ///     Processa o comando: ApplicationFinalize
        /// </summary>
        /// <param name="request">Comando</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Task</returns>
        public Task<Unit> Handle(ApplicationFinalize request, CancellationToken cancellationToken)
        {
            Log.Information("Application finalized.");
            _formMainWindow.Close();
            return Unit.Task;
        }

        /// <summary>
        ///     Processa o comando: ApplicationInitialize
        /// </summary>
        /// <param name="request">Comando</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Task</returns>
        public async Task<Unit> Handle(ApplicationInitialize request, CancellationToken cancellationToken)
        {
            Log.Information("Application started.");
            await _messageBus.Send(new WindowOpenGroupWork(), cancellationToken);
            Application.Run(_formMainWindow);
            return Unit.Value;
        }
    }
}