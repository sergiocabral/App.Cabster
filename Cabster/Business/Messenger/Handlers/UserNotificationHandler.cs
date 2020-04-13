using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Cabster.Business.Entities;
using Cabster.Business.Enums;
using Cabster.Business.Messenger.Notification;
using Cabster.Business.Messenger.Request;
using Cabster.Infrastructure;
using MediatR;
using Serilog;

namespace Cabster.Business.Messenger.Handlers
{
    /// <summary>
    ///     Operações notificação ao usuário.
    /// </summary>
    public class UserNotificationHandler :
        MessengerHandler,
        IRequestHandler<UserNotificationPost>
    {
        /// <summary>
        ///     Notificação de mensagens para o usuário.
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
        /// <param name="userNotification">Notificação de mensagens para o usuário.</param>
        public UserNotificationHandler(IMediator messageBus, IUserNotification userNotification)
        {
            _messageBus = messageBus;
            _userNotification = userNotification;
        }

        /// <summary>
        ///     Processa o comando: UserNotificationPost
        /// </summary>
        /// <param name="request">Comando</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Task</returns>
        public async Task<Unit> Handle(UserNotificationPost request, CancellationToken cancellationToken)
        {
            _userNotification.Post(request.Message, request.Success);
            await _messageBus.Publish(new UserNotificationPosted(request), cancellationToken);
            return Unit.Value;
        }
    }
}