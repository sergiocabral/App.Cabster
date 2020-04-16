using System.Windows.Forms;

namespace Cabster.Business.Messenger.Request
{
    /// <summary>
    ///     Abrir janela de notificações..
    /// </summary>
    public class WindowOpenNotification : WindowOpen
    {
        /// <summary>
        ///     Construtor.
        /// </summary>
        /// <param name="parent">Form pai.</param>
        public WindowOpenNotification(Form? parent = null) : base(parent)
        {
        }
    }
}