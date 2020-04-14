﻿using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cabrones.Utils.Text;
using Cabster.Business.Entities;
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
        /// Configurações de teclas de atalho.
        /// </summary>
        private readonly IShortcut _shortcut;

        /// <summary>
        ///     Barramento de mensagens.
        /// </summary>
        private readonly IMediator _messageBus;

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
        ///     Processa o comando: ApplicationChangeLanguage
        /// </summary>
        /// <param name="request">Comando</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Task</returns>
        public async Task<Unit> Handle(ApplicationChangeLanguage request, CancellationToken cancellationToken)
        {
            var fromLanguage = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
            var toLanguage = request.NewLanguage.TwoLetterISOLanguageName;
            
            var data = Program.Data;
            data.Application.Language = toLanguage;

            await _messageBus.Send(new DataUpdate(data, DataSection.ApplicationLanguage), cancellationToken);

            await _messageBus.Send(
                new UserNotificationPost(
                    new NotificationMessage(Resources.Text_Application_LanguageChanged.QueryString(
                        fromLanguage, toLanguage))), cancellationToken);

            Log.Information("Restarting application.");
            
            await _messageBus.Send(new UserNotificationPost(
                new NotificationMessage(Resources.Text_Application_Restarting)), cancellationToken);
            
            Program.RestartWhenClose = true;
            
            await _messageBus.Send(new ApplicationFinalize(), cancellationToken);

            return Unit.Value;
        }

        /// <summary>
        ///     Processa o comando: ApplicationInitialize
        /// </summary>
        /// <param name="request">Comando</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Task</returns>
        public async Task<Unit> Handle(ApplicationInitialize request, CancellationToken cancellationToken)
        {
            Log.Information("Application initialized.");
            await _messageBus.Publish(new ApplicationInitialized(request), cancellationToken);
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
            Log.Information("Application finalized.");
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
                    
                    Log.Debug("Shortcut key \"{Shortcut}\" registered: {Registered}",
                        shortcut, registered);

                    await _messageBus.Send(new UserNotificationPost(
                        new NotificationMessage(
                            (registered
                                ? Resources.Text_Application_ShortcutDefined
                                : notification.Request.Data.Application.Shortcut != Keys.None
                                    ? Resources.Text_Application_ShortcutInvalid
                                    : Resources.Text_Application_ShortcutRemoved).QueryString(shortcut),
                            registered || notification.Request.Data.Application.Shortcut == Keys.None),
                        notification.Request), cancellationToken);
                }
                catch (Exception exception)
                {
                    Log.Error(exception,
                        "Error registering shortcut key: {Shortcut}", shortcut);

                    await _messageBus.Send(new UserNotificationPost(
                        new NotificationMessage(
                            Resources.Exception_Application_ShortcutAlreadyUsed.QueryString(shortcut),
                            false),
                        notification.Request), cancellationToken);
                }
            }
        }
    }
}