namespace Cabster.Business
{
    /// <summary>
    ///     Agrupa toda a lógica de funcionamento da aplicação.
    /// </summary>
    public interface IEngine
    {
        /// <summary>
        ///     Clock da aplicação.
        ///     Método chamado continuamente.
        /// </summary>
        void Clock();
    }
}