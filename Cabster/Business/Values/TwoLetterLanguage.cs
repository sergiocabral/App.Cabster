using Cabster.Properties;

namespace Cabster.Business.Values
{
    /// <summary>
    ///     Informações constantes sobre idiomas
    /// </summary>
    public static class TwoLetterLanguage
    {
        /// <summary>
        ///     Sigla para português.
        /// </summary>
        public const string Portuguese = "pt";

        /// <summary>
        ///     Sigla para inglês.
        /// </summary>
        public const string English = "en";

        /// <summary>
        /// Converte a sigla em nome do idioma.
        /// </summary>
        /// <param name="twoLetterLanguage">Sigla do idioma.</param>
        /// <returns>Nome do idioma.</returns>
        public static string LanguageName(this string twoLetterLanguage)
        {
            return twoLetterLanguage switch
            {
                English => Resources.Name_Language_English,
                Portuguese => Resources.Name_Language_Portuguese,
                _ => twoLetterLanguage
            };
        } 
    }
}