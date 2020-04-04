using Cabster.Business.Messenger.Command;
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
        }
    }
}