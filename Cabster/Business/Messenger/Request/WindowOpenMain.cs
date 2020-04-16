using System.Windows.Forms;

namespace Cabster.Business.Messenger.Request
{
    /// <summary>
    ///     Abrir e retorna janela principal da aplicação.
    /// </summary>
    public class WindowOpenMain : WindowOpen
    {
        /// <summary>
        ///     Construtor.
        /// </summary>
        /// <param name="parent">Form pai.</param>
        public WindowOpenMain(Form? parent = null) : base(parent)
        {
        }
    }
}