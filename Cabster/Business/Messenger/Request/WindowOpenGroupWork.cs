using System.Windows.Forms;

namespace Cabster.Business.Messenger.Request
{
    /// <summary>
    ///     Abrir janela de trabalho em grupo
    /// </summary>
    public class WindowOpenGroupWork : WindowOpen
    {
        /// <summary>
        ///     Construtor.
        /// </summary>
        /// <param name="parent">Form pai.</param>
        public WindowOpenGroupWork(Form? parent = null) : base(parent)
        {
        }
    }
}