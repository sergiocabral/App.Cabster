using System;
using Cabster.Business.Messenger.Request;
using Cabster.Infrastructure;
using Serilog;

namespace Cabster.Business.Messenger.Notification
{
    /// <summary>
    ///     Posta uma mensagem para o usuário..
    /// </summary>
    public class UserNotificationPosted : MessengerNotification<UserNotificationPost>
    {
        /// <summary>
        ///     Construtor.
        /// </summary>
        /// <param name="request">Comando.</param>
        public UserNotificationPosted(UserNotificationPost request) : base(request)
        {
            var log = request.Message.Success ? (Action<string, string>) Log.Information : Log.Error;
            log("User notification: {NotificationMessage}", request.Message.Text);
        }
    }
}