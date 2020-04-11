using System.Globalization;
using Cabster.Infrastructure;

namespace Cabster.Business.Messenger.Request
{
    /// <summary>
    ///     Troca o idioma da aplicação.
    /// </summary>
    public class ApplicationChangeLanguage : MessengerRequest
    {
        /// <summary>
        ///     Construtor.
        /// </summary>
        /// <param name="newLanguage">Novo idioma.</param>
        public ApplicationChangeLanguage(CultureInfo newLanguage)
        {
            NewLanguage = newLanguage;
        }

        /// <summary>
        ///     Novo idioma.
        /// </summary>
        public CultureInfo NewLanguage { get; set; }
    }
}