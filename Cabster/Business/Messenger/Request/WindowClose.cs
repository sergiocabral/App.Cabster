using System.Windows.Forms;
using Cabster.Business.Values;
using Cabster.Infrastructure;

namespace Cabster.Business.Messenger.Request
{
    /// <summary>
    ///     Fechar uma janela da aplicação.
    /// </summary>
    public class WindowClose : MessengerRequest
    {
        /// <summary>
        ///     Construtor.
        /// </summary>
        /// <param name="window">Janela pai.</param>
        /// <param name="orderBy">Ordem de abertura das janelas.</param>
        public WindowClose(Window window, params Window[] orderBy)
        {
            Window = window;
            OrderBy = orderBy;
        }

        /// <summary>
        ///     Janela pai.
        /// </summary>
        public Window Window { get; }

        /// <summary>
        ///     Ordem de abertura das janelas.
        /// </summary>
        public Window[] OrderBy { get; }
    }
}