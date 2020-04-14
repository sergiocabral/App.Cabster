﻿namespace Cabster.Infrastructure
{
    /// <summary>
    ///     Informações constantes sobre o ambiente.
    /// </summary>
    public static class Environment
    {
        /// <summary>
        ///     Indica se a aplicação está executando em modo Debug.
        /// </summary>
        // ReSharper disable once ConvertToConstant.Global
        public static readonly bool IsDebug
#if DEBUG
            = true;
#else
            = false;
#endif
    }
}