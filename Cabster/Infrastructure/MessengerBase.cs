namespace Cabster.Infrastructure
{
    /// <summary>
    ///     Classe base para qualquer comando ou evento.
    /// </summary>
    public abstract class MessengerBase
    {
        /// <summary>
        ///     Construtor.
        /// </summary>
        protected MessengerBase()
        {
            // ReSharper disable once VirtualMemberCallInConstructor
            if (!IgnoreLog) this.LogClassInstantiate();
        }

        /// <summary>
        ///     Ignora o log desse Request.
        /// </summary>
        protected virtual bool IgnoreLog { get; } = false;
    }
}