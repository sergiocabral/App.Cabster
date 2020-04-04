using Cabster.Infrastructure;

namespace Cabster.Business.Messenger.Command
{
    /// <summary>
    ///     Sinalização do click do sistema.
    /// </summary>
    public class SinalizeApplicationClock : MessengerCommand
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