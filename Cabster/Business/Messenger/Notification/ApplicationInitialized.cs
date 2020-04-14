using Cabster.Business.Messenger.Request;
using Cabster.Infrastructure;

namespace Cabster.Business.Messenger.Notification
{
    /// <summary>
    ///     Sinaliza que a aplicação foi inicializada.
    /// </summary>
    public class ApplicationInitialized : MessengerNotification<ApplicationInitialize>
    {
        /// <summary>
        ///     Construtor.
        /// </summary>
        /// <param name="request">Comando.</param>
        public ApplicationInitialized(ApplicationInitialize request) : base(request)
        {
        }
    }
}