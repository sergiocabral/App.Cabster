namespace Cabster.Business
{
    /// <summary>
    ///     Bloqueador de telas.
    /// </summary>
    public interface IScreenBlocker
    {
        /// <summary>
        ///     Determina se as telas estão bloqueada.
        /// </summary>
        bool IsBlocked { get; }

        /// <summary>
        ///     Bloqueia todas as telas.
        /// </summary>
        void Block();

        /// <summary>
        ///     Desbloqueia todas as telas.
        /// </summary>
        void Unblock();
    }
}