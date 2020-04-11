using MediatR;

namespace Cabster.Infrastructure
{
    /// <summary>
    ///     Classe base para qualquer evento
    /// </summary>
    public abstract class MessengerNotification : MessengerBase, INotification
    {
    }

    /// <summary>
    ///     Classe base para qualquer evento vinculado a um comando.
    /// </summary>
    public abstract class MessengerNotification<TRequest> : MessengerNotification where TRequest : MessengerRequest
    {
        /// <summary>
        ///     Construtor.
        /// </summary>
        /// <param name="request">Comando.</param>
        public MessengerNotification(TRequest request)
        {
            Request = request;
        }

        public TRequest Request { get; }
    }
}