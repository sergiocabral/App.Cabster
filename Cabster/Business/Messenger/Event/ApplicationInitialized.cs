using Cabster.Business.Messenger.Command;
using Cabster.Infrastructure;

namespace Cabster.Business.Messenger.Event
{
    /// <summary>
    ///     Inicializa a aplicação.
    /// </summary>
    public class ApplicationInitialized : MessengerEvent<InitializeApplication>
    {
        /// <summary>
        ///     Construtor.
        /// </summary>
        /// <param name="command">Comando.</param>
        public ApplicationInitialized(InitializeApplication command) : base(command)
        {
        }
    }
}