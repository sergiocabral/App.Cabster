using System.Threading;
using System.Threading.Tasks;
using Cabster.Business.Messenger.Request;
using Cabster.Infrastructure;
using MediatR;
using Serilog;

namespace Cabster.Business.Messenger.Handlers
{
    /// <summary>
    ///     Ações do usuário.
    /// </summary>
    // ReSharper disable once UnusedType.Global
    public class UserActionHandler :
        MessengerHandler,
        IRequestHandler<UserActionPoke>,
        IRequestHandler<UserActionGroupWorkStart>
    {
        /// <summary>
        ///     Processa o comando: UserActionPoke
        /// </summary>
        /// <param name="request">Comando</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Task</returns>
        public Task<Unit> Handle(UserActionPoke request, CancellationToken cancellationToken)
        {
            //TODO: Implementar UserActionPoke
            Log.Verbose(nameof(UserActionPoke));

            return Unit.Task;
        }
        
        /// <summary>
        ///     Processa o comando: UserActionGroupWorkStart
        /// </summary>
        /// <param name="request">Comando</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Task</returns>
        public Task<Unit> Handle(UserActionGroupWorkStart request, CancellationToken cancellationToken)
        {
            //TODO: Implementar UserActionGroupWorkStart
            Log.Verbose(nameof(UserActionGroupWorkStart));

            return Unit.Task;
        }
    }
}