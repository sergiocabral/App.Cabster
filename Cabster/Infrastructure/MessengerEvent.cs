namespace Cabster.Infrastructure
{
    /// <summary>
    ///     Classe base para qualquer evento
    /// </summary>
    public abstract class MessengerEvent
    {
    }

    /// <summary>
    ///     Classe base para qualquer evento vinculado a um comando.
    /// </summary>
    public abstract class MessengerEvent<TCommand> : MessengerEvent where TCommand : MessengerCommand
    {
        /// <summary>
        ///     Construtor.
        /// </summary>
        /// <param name="command">Comando.</param>
        public MessengerEvent(TCommand command)
        {
            Command = command;
        }

        public TCommand Command { get; }
    }
}