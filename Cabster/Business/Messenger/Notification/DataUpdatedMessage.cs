using Cabster.Business.Messenger.Request;
using Cabster.Infrastructure;

namespace Cabster.Business.Messenger.Notification
{
    /// <summary>
    ///     Sinalização uma mensagem de atualização de dados do aplicativo.
    /// </summary>
    public class DataUpdatedMessage : MessengerNotification<DataUpdate>
    {
        /// <summary>
        /// Mensagem.
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// Indica uma mensagem de sucesso.
        /// </summary>
        public bool Success { get; }

        /// <summary>
        ///     Construtor.
        /// </summary>
        /// <param name="request">Comando.</param>
        /// <param name="message">Mensagem.</param>
        /// <param name="success">Sucesso.</param>
        public DataUpdatedMessage(DataUpdate request, string message, bool success = true) : base(request)
        {
            Message = message;
            Success = success;
        }
    }
}