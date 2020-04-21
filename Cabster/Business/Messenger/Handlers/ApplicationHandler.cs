using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cabrones.Utils.Text;
using Cabster.Business.Entities;
using Cabster.Business.Messenger.Notification;
using Cabster.Business.Messenger.Request;
using Cabster.Business.Values;
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
    // ReSharper disable once UnusedType.Global
    public class ApplicationHandler :
        MessengerHandler,
        IRequestHandler<ApplicationInitialize, bool>,
        IRequestHandler<ApplicationFinalize>,
        IRequestHandler<ApplicationChangeLanguage>,
        INotificationHandler<DataUpdated>
    {
        /// <summary>
        ///     Marcação que sinaliza que a aplicação deve ser reiniciada.
        /// </summary>
        private static readonly object SignalForApplicationRestart = new object();

        /// <summary>
        ///     Bloqueador de telas.
        /// </summary>
        private readonly ILockScreen _lockScreen;

        /// <summary>
        ///     Barramento de mensagens.
        /// </summary>
        private readonly IMediator _messageBus;

        /// <summary>
        ///     Configurações de teclas de atalho.
        /// </summary>
        private readonly IShortcut _shortcut;

        /// <summary>
        ///     Construtor.
        /// </summary>
        /// <param name="messageBus">IMediator</param>
        /// <param name="shortcut">Configurações de teclas de atalho.</param>
        /// <param name="lockScreen">Bloqueador de telas.</param>
        public ApplicationHandler(
            IMediator messageBus,
            IShortcut shortcut,
            ILockScreen lockScreen)
        {
            _messageBus = messageBus;
            _shortcut = shortcut;
            _lockScreen = lockScreen;
        }

        /// <summary>
        ///     Evento: DataUpdated
        /// </summary>
        /// <param name="notification">Evento.</param>
        /// <param name="cancellationToken">Token de cancelamento.</param>
        /// <returns>Task</returns>
        public async Task Handle(DataUpdated notification, CancellationToken cancellationToken)
        {
            if (DataSection.ApplicationLanguage == (DataSection.ApplicationLanguage & notification.Request.Section))
                await ApplyDataApplicationLanguage(notification, cancellationToken);

            if (DataSection.ApplicationShortcut == (DataSection.ApplicationShortcut & notification.Request.Section))
                await ApplyDataApplicationShortcut(notification, cancellationToken);

            if (DataSection.ApplicationLockScreen == (DataSection.ApplicationLockScreen & notification.Request.Section))
                await ApplyDataApplicationLockScreen(notification, cancellationToken);
        }

        /// <summary>
        ///     Processa o comando: ApplicationChangeLanguage
        /// </summary>
        /// <param name="request">Comando</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Task</returns>
        public async Task<Unit> Handle(ApplicationChangeLanguage request, CancellationToken cancellationToken)
        {
            var data = Program.Data;
            data.Application.Language = request.NewLanguage.TwoLetterISOLanguageName;

            await _messageBus.Send(new DataUpdate(data, DataSection.ApplicationLanguage), cancellationToken);

            const Window formType = Window.Main;
            var forms = await _messageBus.Send<IDictionary<Window, Form>>(
                new WindowOpen(formType), cancellationToken);
            var form = forms[formType];
            
            form.Tag = SignalForApplicationRestart;

            await _messageBus.Send(new ApplicationFinalize(), cancellationToken);

            return Unit.Value;
        }

        /// <summary>
        ///     Processa o comando: ApplicationFinalize
        /// </summary>
        /// <param name="request">Comando</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Task</returns>
        public async Task<Unit> Handle(ApplicationFinalize request, CancellationToken cancellationToken)
        {
            await _messageBus.Publish(new ApplicationFinalized(request), cancellationToken);
            return Unit.Value;
        }

        /// <summary>
        ///     Processa o comando: ApplicationInitialize
        /// </summary>
        /// <param name="request">Comando</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Retorna true se a aplicação precisar reiniciar.</returns>
        public async Task<bool> Handle(ApplicationInitialize request, CancellationToken cancellationToken)
        {
            await _messageBus.Publish(new ApplicationInitialized(request), cancellationToken);
            
            const Window formType = Window.Main;
            var forms = await _messageBus.Send<IDictionary<Window, Form>>(
                new WindowOpen(formType), cancellationToken);
            var form = forms[formType];

            Application.Run(form);
            return form.Tag == SignalForApplicationRestart;
        }

        /// <summary>
        ///     Aplica os dados do aplicativo para: Shortcut
        /// </summary>
        /// <param name="dataUpdatedNotification">Notificação de atualização de dados.</param>
        /// <param name="cancellationToken">Token de cancelamento.</param>
        /// <returns>Task</returns>
        private async Task ApplyDataApplicationShortcut(DataUpdated dataUpdatedNotification,
            CancellationToken cancellationToken)
        {
            var request = dataUpdatedNotification.Request;
            var dataApplicationShortcut = request.Data.Application.Shortcut;

            var shortcut = dataApplicationShortcut.ToShortcutDescription();

            try
            {
                var registered = _shortcut.Register(dataApplicationShortcut);

                Log.Debug("Shortcut key \"{Shortcut}\" registered: {Registered}",
                    shortcut, registered);

                await _messageBus.Send(new UserNotificationPost(
                    new NotificationMessage(
                        (registered
                            ? Resources.Notification_ShortcutDefined
                            : dataApplicationShortcut != Keys.None
                                ? Resources.Notification_ShortcutInvalid
                                : Resources.Notification_ShortcutRemoved).QueryString(shortcut),
                        registered || dataApplicationShortcut == Keys.None),
                    request), cancellationToken);
            }
            catch (Exception exception)
            {
                Log.Error(exception,
                    "Error registering shortcut key: {Shortcut}", shortcut);

                await _messageBus.Send(new UserNotificationPost(
                    new NotificationMessage(
                        Resources.Exception_Application_ShortcutAlreadyUsed.QueryString(shortcut),
                        false),
                    request), cancellationToken);
            }
        }

        /// <summary>
        ///     Aplica os dados do aplicativo para: Language
        /// </summary>
        /// <param name="dataUpdatedNotification">Notificação de atualização de dados.</param>
        /// <param name="cancellationToken">Token de cancelamento.</param>
        /// <returns>Task</returns>
        private async Task ApplyDataApplicationLanguage(DataUpdated dataUpdatedNotification,
            CancellationToken cancellationToken)
        {
            var request = dataUpdatedNotification.Request;
            var dataApplicationLanguage = request.Data.Application.Language;

            if (CultureInfo.DefaultThreadCurrentCulture?.TwoLetterISOLanguageName != dataApplicationLanguage)
            {
                var fromLanguage = CultureInfo.DefaultThreadCurrentUICulture != null
                    ? CultureInfo.DefaultThreadCurrentUICulture
                    : CultureInfo.InstalledUICulture;
                var toLanguage = dataApplicationLanguage.ToCultureInfo();

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
                            )), request), cancellationToken);
                }
            }
        }

        /// <summary>
        ///     Aplica os dados do aplicativo para: LockScreen
        /// </summary>
        /// <param name="dataUpdatedNotification">Notificação de atualização de dados.</param>
        /// <param name="cancellationToken">Token de cancelamento.</param>
        /// <returns>Task</returns>
        private async Task ApplyDataApplicationLockScreen(DataUpdated dataUpdatedNotification,
            CancellationToken cancellationToken)
        {
            var request = dataUpdatedNotification.Request;
            var dataApplicationLockScreen = request.Data.Application.LockScreen;

            if (_lockScreen.IsLocked != dataApplicationLockScreen)
            {
                if (dataApplicationLockScreen) _lockScreen.Lock();
                else _lockScreen.Unlock();

                Log.Debug("Lock screen activated: {Mode}", dataApplicationLockScreen);

                await _messageBus.Send(
                    new UserNotificationPost(
                        new NotificationMessage(Resources.Notification_LockScreenDefined.QueryString(
                            dataApplicationLockScreen
                                ? Resources.Name_Term_Active
                                : Resources.Name_Term_Inactive
                        )), request), cancellationToken);
            }
        }
    }
}