using Cabster.Business.Messenger.Command;
using Cabster.Business.Messenger.Event;
using Cabster.Components;
using Merq;
using Serilog;

namespace Cabster.Business.Messenger.CommandHandlers
{
    /// <summary>
    ///     Tarefas gerais sobre a aplicação.
    /// </summary>
    public class Application : ICommandHandler<InitializeApplication>
    {
        /// <summary>
        /// IEventStream
        /// </summary>
        private readonly IEventStream _eventStream;

        /// <summary>
        /// Construtor.
        /// </summary>
        /// <param name="eventStream">IEventStream</param>
        public Application(IEventStream eventStream)
        {
            _eventStream = eventStream;
        }
        
        /// <summary>
        ///     Determina se o comando pode ser executado.
        /// </summary>
        /// <param name="command">Comando.</param>
        /// <returns>Resposta.</returns>
        public bool CanExecute(InitializeApplication command)
        {
            return true;
        }

        /// <summary>
        ///     Execução do comando.
        /// </summary>
        /// <param name="command">Comando.</param>
        public void Execute(InitializeApplication command)
        {
            Log.Verbose("Aplicação inicializada.");
            _eventStream.Push(new ApplicationInitialized(command));
        }
    }
}