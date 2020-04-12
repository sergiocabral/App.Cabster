using System.Windows.Forms;

namespace Cabster.Business
{
    /// <summary>
    /// Configurações de teclas de atalho.
    /// </summary>
    public interface IShortcut
    {
        /// <summary>
        /// Registra uma tecla de atalho.
        /// </summary>
        /// <param name="shortcut">Tecla de atalho</param>
        /// <returns>True quando algum atalho é registrado.</returns>
        bool Register(Keys shortcut);
    }
}