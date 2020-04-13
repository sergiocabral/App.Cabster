using Cabster.Business.Messenger.Request;
using Cabster.Infrastructure;

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
        }
    }
}