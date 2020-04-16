using System.Windows.Forms;

namespace Cabster.Business.Messenger.Request
{
    /// <summary>
    ///     Abrir janela de configuração.
    /// </summary>
    public class WindowOpenConfiguration : WindowOpen
    {
        /// <summary>
        ///     Construtor.
        /// </summary>
        /// <param name="parent">Form pai.</param>
        public WindowOpenConfiguration(Form? parent = null) : base(parent)
        {
        }
    }
}