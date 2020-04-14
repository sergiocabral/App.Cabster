using Cabster.Business.Messenger.Request;
using Cabster.Infrastructure;

namespace Cabster.Business.Messenger.Notification
{
    /// <summary>
    ///     Sinaliza que a aplicação foi finalizada.
    /// </summary>
    public class ApplicationFinalized : MessengerNotification<ApplicationFinalize>
    {
        /// <summary>
        ///     Construtor.
        /// </summary>
        /// <param name="request">Comando.</param>
        public ApplicationFinalized(ApplicationFinalize request) : base(request)
        {
        }
    }
}