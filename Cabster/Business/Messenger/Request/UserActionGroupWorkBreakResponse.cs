using Cabster.Infrastructure;

namespace Cabster.Business.Messenger.Request
{
    /// <summary>
    ///     Resposta para a pergunta para fazer ou não o intervalo.
    /// </summary>
    public class UserActionGroupWorkBreakResponse : MessengerRequest
    {
        /// <summary>
        ///     Construtor.
        /// </summary>
        /// <param name="acceptBreak">Aceitar o intervalo.</param>
        public UserActionGroupWorkBreakResponse(bool acceptBreak)
        {
            AcceptBreak = acceptBreak;
        }

        /// <summary>
        ///     Aceitar o intervalo.
        /// </summary>
        public bool AcceptBreak { get; }
    }
}