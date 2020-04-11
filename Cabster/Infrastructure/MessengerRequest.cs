using MediatR;

namespace Cabster.Infrastructure
{
    /// <summary>
    ///     Classe base para qualquer comando.
    /// </summary>
    public abstract class MessengerRequest : MessengerBase, IRequest
    {
    }

    /// <summary>
    ///     Classe base para qualquer comando.
    /// </summary>
    public abstract class MessengerRequest<TResponse> : IRequest<TResponse>
    {
    }
}