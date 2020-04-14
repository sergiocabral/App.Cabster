namespace Cabster.Infrastructure
{
    /// <summary>
    ///     Informações constantes sobre o ambiente.
    /// </summary>
    public static class Environment
    {
        /// <summary>
        ///     Inicializa as propriedades dessa classe.
        /// </summary>
        public static void Initialize()
        {
            IsDesign = false;
        }

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

        /// <summary>
        ///     Indica se a aplicação está em modo de design, em não execução.
        /// </summary>
        public static bool IsDesign = true;
    }
}