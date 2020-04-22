using System;

namespace Cabster.Business.Values
{
    /// <summary>
    ///     Estados possíveis da aplicação.
    /// </summary>
    public enum ApplicationState
    {
        /// <summary>
        ///     Aplicação parada.
        /// </summary>
        Idle,

        /// <summary>
        ///     Trabalho em grupo MOB rodando em tempo de trabalho.
        /// </summary>
        GroupWorkTimerForWork,

        /// <summary>
        ///     Trabalho em grupo MOB rodando em tempo de intervalo.
        /// </summary>
        GroupWorkTimerForBreak,

        /// <summary>
        ///     Trabalho em grupo MOB perguntando pelo intervalo
        /// </summary>
        GroupWorkAskForBreak
    }
}