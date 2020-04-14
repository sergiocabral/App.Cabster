using Cabster.Infrastructure;

namespace Cabster.Business.Messenger.Request
{
    /// <summary>
    ///     Inicializa a aplicação e sinaliza se deve ser finaliza (true) ou reiniciada (false).
    /// </summary>
    public class ApplicationInitialize : MessengerRequest<bool>
    {
    }
}