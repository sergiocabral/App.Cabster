using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
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
        ///     Lista de CultureInfo já carregados.
        /// </summary>
        private static readonly ConcurrentDictionary<string, CultureInfo> CultureInfos 
            = new ConcurrentDictionary<string, CultureInfo>();

        /// <summary>
        ///     Converte a sigla em nome do idioma.
        /// </summary>
        /// <param name="twoLetterLanguage">Sigla do idioma.</param>
        /// <returns>Nome do idioma.</returns>
        public static string ToLanguageName(this string twoLetterLanguage)
        {
            return twoLetterLanguage switch
            {
                English => Resources.Name_Language_English,
                Portuguese => Resources.Name_Language_Portuguese,
                _ => twoLetterLanguage
            };
        }

        /// <summary>
        ///     Converte a sigla em CultureInfo.
        /// </summary>
        /// <param name="twoLetterLanguage">Sigla do idioma.</param>
        /// <returns>CultureInfo</returns>
        public static CultureInfo ToCultureInfo(this string twoLetterLanguage)
        {
            return CultureInfos.GetOrAdd(twoLetterLanguage, new CultureInfo(twoLetterLanguage));
        }
    }
}