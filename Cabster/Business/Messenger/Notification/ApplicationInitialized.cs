using Cabster.Business.Messenger.Request;
using Cabster.Infrastructure;

namespace Cabster.Business.Messenger.Notification
{
    /// <summary>
    ///     Inicializa a aplicação.
    /// </summary>
    public class ApplicationInitialized : MessengerNotification<InitializeApplication>
    {
        /// <summary>
        ///     Construtor.
        /// </summary>
        /// <param name="request">Comando.</param>
        public ApplicationInitialized(InitializeApplication request) : base(request)
        {
        }
    }
}