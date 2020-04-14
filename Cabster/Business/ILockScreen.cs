namespace Cabster.Business
{
    /// <summary>
    ///     Bloqueador de telas.
    /// </summary>
    public interface ILockScreen
    {
        /// <summary>
        ///     Determina se as telas estão bloqueada.
        /// </summary>
        bool IsLocked { get; }

        /// <summary>
        ///     Bloqueia todas as telas.
        /// </summary>
        void Lock();

        /// <summary>
        ///     Desbloqueia todas as telas.
        /// </summary>
        void Unlock();
    }
}