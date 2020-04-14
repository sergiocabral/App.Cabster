using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Cabster.Business.Entities;
using Cabster.Business.Messenger.Notification;
using Cabster.Business.Messenger.Request;
using Cabster.Infrastructure;
using MediatR;

namespace Cabster.Business.Messenger.Handlers
{
    /// <summary>
    ///     Operações notificação ao usuário.
    /// </summary>
    // ReSharper disable once UnusedType.Global
    public class UserNotificationHandler :
        MessengerHandler,
        IRequestHandler<UserNotificationPost>,
        IRequestHandler<UserNotificationRequestList, IEnumerable<NotificationMessage>>
    {
        /// <summary>
        ///     Barramento de mensagens.
        /// </summary>
        private readonly IMediator _messageBus;

        /// <summary>
        ///     Notificação de mensagens para o usuário.
        /// </summary>
        private readonly IUserNotification _userNotification;

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
            _userNotification.Post(request.Message);
            await _messageBus.Publish(new UserNotificationPosted(request), cancellationToken);
            return Unit.Value;
        }

        /// <summary>
        ///     Processa o comando: UserNotificationRequestList
        /// </summary>
        /// <param name="request">Comando</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Task</returns>
        public Task<IEnumerable<NotificationMessage>> Handle(UserNotificationRequestList request,
            CancellationToken cancellationToken)
        {
            return Task.FromResult(_userNotification.GetMessages(request.Filter));
        }
    }
}