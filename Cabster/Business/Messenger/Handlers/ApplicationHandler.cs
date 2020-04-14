﻿using System;
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
        public ApplicationHandler(
            IMediator messageBus,
            IShortcut shortcut)
        {
            _messageBus = messageBus;
            _shortcut = shortcut;
        }

        /// <summary>
        ///     Evento: DataUpdated
        /// </summary>
        /// <param name="notification">Evento.</param>
        /// <param name="cancellationToken">Token de cancelamento.</param>
        /// <returns>Task</returns>
        public async Task Handle(DataUpdated notification, CancellationToken cancellationToken)
        {
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

            var mainWindow = await _messageBus.Send<Form>(new WindowOpenMain(), cancellationToken);
            mainWindow.Tag = SignalForApplicationRestart;

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
        /// <returns>Task</returns>
        public async Task<bool> Handle(ApplicationInitialize request, CancellationToken cancellationToken)
        {
            await _messageBus.Publish(new ApplicationInitialized(request), cancellationToken);
            var mainWindow = await _messageBus.Send<Form>(new WindowOpenMain(), cancellationToken);
            Application.Run(mainWindow);
            return mainWindow.Tag != SignalForApplicationRestart;
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
            await Task.Delay(1, cancellationToken);
        }
    }
}