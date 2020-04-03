namespace Cabster.Business
{
    /// <summary>
    ///     Agrupa toda a lógica de funcionamento da aplicação.
    /// </summary>
    public sealed class Engine : IEngine
    {
        /// <summary>
        ///     Instância única para esta classe.
        /// </summary>
        public static readonly Engine Instance = new Engine();

        /// <summary>
        ///     Construtor.
        /// </summary>
        private Engine()
        {
        }

        /// <summary>
        ///     Clock da aplicação.
        ///     Método chamado continuamente.
        /// </summary>
        public void Clock()
        {
        }
    }
}