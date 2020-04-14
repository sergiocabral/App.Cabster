using System.Globalization;
using System.Windows.Forms;
using Cabster.Business.Values;

namespace Cabster.Business.Entities
{
    /// <summary>
    ///     Conjunto de configurações da aplicação.
    /// </summary>
    public class ApplicationSet : EntityBase
    {
        /// <summary>
        ///     Estado da aplicação
        /// </summary>
        public ApplicationState State { get; set; } = ApplicationState.ApplicationStarted;

        /// <summary>
        ///     Tecla de atalho.
        /// </summary>
        public Keys Shortcut { get; set; } = Keys.Control | Keys.Shift | Keys.M;

        /// <summary>
        ///     Idioma padrão.
        /// </summary>
        public string Language { get; set; } = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;

        /// <summary>
        ///     Bloqueio de tela.
        /// </summary>
        public bool LockScreen { get; set; } = true;
    }
}