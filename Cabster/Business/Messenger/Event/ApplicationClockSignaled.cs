using Cabster.Business.Messenger.Command;
using Cabster.Infrastructure;

namespace Cabster.Business.Messenger.Event
{
    /// <summary>
    ///     Sinalização do click do sistema.
    /// </summary>
    public class ApplicationClockSignaled : MessengerEvent<SinalizeApplicationClock>
    {
        /// <summary>
        ///     Construtor.
        /// </summary>
        /// <param name="command">Comando.</param>
        public ApplicationClockSignaled(SinalizeApplicationClock command) : base(command)
        {
        }
    }
}