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
        ///     A aplicação acabou de abrir.
        /// </summary>
        ApplicationStarted = 0
    }
}