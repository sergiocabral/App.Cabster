using Cabster.Infrastructure;

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
        /// <param name="success">Sucesso</param>
        /// <param name="sourceRequest">Comando fonte da notificação.</param>
        public UserNotificationPost(string message, bool success, MessengerRequest? sourceRequest = null)
        {
            Message = message;
            Success = success;
            SourceRequest = sourceRequest;
        }

        /// <summary>
        ///     Mensagem.
        /// </summary>
        public string Message { get; }

        /// <summary>
        ///     Sucesso.
        /// </summary>
        public bool Success { get; }

        /// <summary>
        /// Comando fonte da notificação.
        /// </summary>
        public MessengerRequest? SourceRequest { get; }
    }
}