using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cabster.Business.Enums;
using Cabster.Business.Messenger.Notification;
using Cabster.Business.Messenger.Request;
using Cabster.Components;
using Cabster.Extensions;
using Cabster.Infrastructure;
using Cabster.Properties;
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
        IRequestHandler<ApplicationChangeLanguage>,
        INotificationHandler<DataUpdated>
    {
        /// <summary>
        ///     Janela principal do sistema.
        /// </summary>
        private readonly FormMainWindow _formMainWindow;

        /// <summary>
        /// Configurações de teclas de atalho.
        /// </summary>
        private readonly IShortcut _shortcut;

        /// <summary>
        /// Notificação de mensagens para o usuário.
        /// </summary>
        private readonly IUserNotification _userNotification;

        /// <summary>
        ///     Barramento de mensagens.
        /// </summary>
        private readonly IMediator _messageBus;

        /// <summary>
        ///     Construtor.
        /// </summary>
        /// <param name="messageBus">IMediator</param>
        /// <param name="formMainWindow">Janela principal do sistema.</param>
        /// <param name="shortcut">Configurações de teclas de atalho.</param>
        /// <param name="userNotification">Notificação de mensagens para o usuário.</param>
        public ApplicationHandler(
            IMediator messageBus, 
            FormMainWindow formMainWindow,
            IShortcut shortcut,
            IUserNotification userNotification)
        {
            _messageBus = messageBus;
            _formMainWindow = formMainWindow;
            _shortcut = shortcut;
            _userNotification = userNotification;
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

        /// <summary>
        /// Evento: DataUpdated
        /// </summary>
        /// <param name="notification">Evento.</param>
        /// <param name="cancellationToken">Token de ancelamento.</param>
        /// <returns>Task</returns>
        public async Task Handle(DataUpdated notification, CancellationToken cancellationToken)
        {
            if ((notification.Request.Section & DataSection.ApplicationShortcut) == DataSection.ApplicationShortcut)
            {
                var shortcut = notification.Request.Data.Application.Shortcut.ToShortcutDescription();
                
                try
                {
                    var registered = _shortcut.Register(notification.Request.Data.Application.Shortcut);
                    await _messageBus.Send(new UserNotificationPost(
                        registered
                            ? Resources.Text_Application_ShortcutDefined
                            : Resources.Text_Application_ShortcutRemoved,
                        true,
                        notification.Request), cancellationToken);

                    Log.Debug("Shortcut key {Shortcut} registered: {Registered}", 
                        shortcut, registered);
                }
                catch (Exception exception)
                {
                    Log.Error(exception,
                        "Error registering shortcut key: {Shortcut}", shortcut);
                    
                    await _messageBus.Send(new UserNotificationPost(
                        Resources.Exception_Application_ShortcutAlreadyUsed,
                        false,
                        notification.Request), cancellationToken);
                }
            }
        }
    }
}