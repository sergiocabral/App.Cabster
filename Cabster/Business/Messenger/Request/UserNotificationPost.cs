using Cabster.Infrastructure;
using Cabster.Business.Entities;

namespace Cabster.Business.Messenger.Request
{
    /// <summary>
    ///     Posta uma mensagem para o usuário.
    /// </summary>
    public class UserNotificationPost : MessengerRequest
    {
        /// <summary>
        ///     Construtor.
        /// </summary>
        /// <param name="message">Mensagem</param>
        /// <param name="sourceRequest">Comando</param>
        public UserNotificationPost(NotificationMessage message, MessengerRequest? sourceRequest = null)
        {
            Message = message;
            SourceRequest = sourceRequest;
        }

        /// <summary>
        ///     Mensagem.
        /// </summary>
        public NotificationMessage Message { get; }

        /// <summary>
        /// Comando associado.
        /// </summary>
        public MessengerRequest? SourceRequest { get; }
    }
}