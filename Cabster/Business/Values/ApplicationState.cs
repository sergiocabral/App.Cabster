using System;

namespace Cabster.Business.Values
{
    /// <summary>
    ///     Estados possíveis da aplicação.
    /// </summary>
    [Flags]
    public enum ApplicationState
    {
        /// <summary>
        ///     Aplicação parada.
        /// </summary>
        Idle = 0,

        /// <summary>
        ///     Trabalho em grupo MOB rodando.
        /// </summary>
        GroupWorkRunning = 1
    }
}