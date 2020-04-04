namespace Cabster.Infrastructure
{
    /// <summary>
    ///     Classe base para qualquer comando.
    /// </summary>
    public abstract class MessengerHandler
    {
        public MessengerHandler()
        {
            this.LogVerboseInstantiate();
        }
    }
}