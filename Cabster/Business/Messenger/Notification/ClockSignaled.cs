using Cabster.Business.Messenger.Request;
using Cabster.Infrastructure;

namespace Cabster.Business.Messenger.Notification
{
    /// <summary>
    ///     Sinalização do click do sistema.
    /// </summary>
    public class ClockSignaled : MessengerNotification<ClockSinalize>
    {
        /// <summary>
        ///     Construtor.
        /// </summary>
        /// <param name="request">Comando.</param>
        public ClockSignaled(ClockSinalize request) : base(request)
        {
        }

        /// <summary>
        ///     Ignora o log desse Request.
        /// </summary>
        protected override bool IgnoreLog { get; } = true;
    }
}