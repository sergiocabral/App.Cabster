using System;
using Cabster.Infrastructure;

namespace Cabster.Business.Messenger.Request
{
    /// <summary>
    ///     Sinaliza que o trabalho em grupo MOB finalizou seu tempo.
    /// </summary>
    public class UserActionGroupWorkTimerEnd : MessengerRequest
    {
        /// <summary>
        ///     Construtor.
        /// </summary>
        /// <param name="time">Tempo decorrido.</param>
        /// <param name="concluded">Ação de cancelamento.</param>
        public UserActionGroupWorkTimerEnd(TimeSpan time, bool concluded = true)
        {
            Time = time;
            Concluded = concluded;
        }

        /// <summary>
        ///     Tempo decorrido.
        /// </summary>
        public TimeSpan Time { get; }

        /// <summary>
        ///     Ação de cancelamento.
        /// </summary>
        public bool Concluded { get; }
    }
}