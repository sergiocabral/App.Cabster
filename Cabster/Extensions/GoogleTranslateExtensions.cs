using System;
using System.Globalization;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Cabster.Exceptions;
using Newtonsoft.Json;
using Serilog;

namespace Cabster.Extensions
{
    /// <summary>
    ///     Tradução com Google Translate
    /// </summary>
    public static class GoogleTranslateExtensions
    {
        /// <summary>
        ///     Máscara da URL do Google Translate.
        /// </summary>
        private const string UrlMask =
            "https://translate.google.com.br/translate_a/single?client=gtx&sl={1}&tl={2}&hl={1}-BR&dt=at&dt=bd&dt=ex&dt=ld&dt=md&dt=qca&dt=rw&dt=rm&dt=ss&dt=t&otf=1&ssel=0&tsel=0&kc=7&q={0}";

        /// <summary>
        ///     WebClient.
        /// </summary>
        private static readonly WebClient WebClient = new WebClient {Encoding = Encoding.UTF8};

        /// <summary>
        ///     Traduz um texto.
        /// </summary>
        /// <param name="text">Texto original.</param>
        /// <param name="fromLanguage">Idioma de origem.</param>
        /// <param name="toLanguage">Idioma de destino.</param>
        /// <returns>Texto traduzido.</returns>
        public static async Task<string> GoogleTranslate(this string text, string fromLanguage,
            string? toLanguage = null)
        {
            var url = string.Format(
                UrlMask,
                HttpUtility.UrlEncode(text),
                fromLanguage,
                toLanguage ?? CultureInfo.CurrentUICulture.TwoLetterISOLanguageName);

            try
            {
                Log.Verbose("Requesting Google Translate: {Url}", url);
                var response = await Task.Run(() => WebClient.DownloadString(url));

                var responseJson = (dynamic)
                    (JsonConvert.DeserializeObject(response)
                     ?? throw new IsNullOrEmptyException($"{nameof(WebClient)}.{nameof(WebClient.DownloadString)}()"));

                var result = new StringBuilder();

                foreach (var json in responseJson[0]) result.Append(json[0].ToString());

                return result.ToString();
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error on requesting Google Translate: {Url}", url);
                return text;
            }
        }
    }
}