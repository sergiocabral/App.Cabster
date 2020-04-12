using System.Globalization;
using Cabster.Business.Enums;

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
        ///     Idioma padrão.
        /// </summary>
        public string Language { get; set; } = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
    }
}