using System.Windows.Forms;
using Cabster.Infrastructure;

namespace Cabster.Business.Messenger.Request
{
    /// <summary>
    ///     Abrir janela de configuração.
    /// </summary>
    public abstract class WindowOpen : MessengerRequest<Form>
    {
        /// <summary>
        /// Form pai.
        /// </summary>
        public Form? Parent { get; }

        /// <summary>
        /// Construtor.
        /// </summary>
        /// <param name="parent">Form pai.</param>
        protected WindowOpen(Form? parent)
        {
            Parent = parent;
        }
    }
}