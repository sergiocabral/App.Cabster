using Cabster.Infrastructure;

namespace Cabster.Business.Messenger.Request
{
    /// <summary>
    ///     Sinalização do click do sistema.
    /// </summary>
    public class SinalizeApplicationClock : MessengerRequest
    {
        /// <summary>
        ///     Contagem de clocks executados.
        /// </summary>
        private static int _count;

        /// <summary>
        ///     Contagem de clocks executados.
        /// </summary>
        public int TickCount { get; } = ++_count;
    }
}