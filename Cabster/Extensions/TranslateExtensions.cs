using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Cabster.Exceptions;
using Cabster.Properties;

namespace Cabster.Extensions
{
    /// <summary>
    ///     Utilitários para tradução.
    /// </summary>
    public static class TranslateExtensions
    {
        /// <summary>
        ///     Lista de recursos de mensagens para tradução.
        /// </summary>
        private static readonly Dictionary<string, PropertyInfo> Resources = typeof(Resources)
            .GetProperties(BindingFlags.Static | BindingFlags.Public)
            .Where(p => p.PropertyType == typeof(string))
            .ToDictionary(
                p => p.Name,
                p => p);

        /// <summary>
        ///     Traduz todos os controles dentro de um controle.
        /// </summary>
        /// <param name="container">Controle.</param>
        public static T Translate<T>(this T container) where T : Control
        {
            // ReSharper disable once SuggestBaseTypeForParameter
            static void TranslateControl(Control control)
            {
                var properties = new[] {"Text", "Caption", "Title", "Placeholder"};

                foreach (var property in properties)
                {
                    var propertyInfo = control.GetType()
                        .GetProperty(property, BindingFlags.Instance | BindingFlags.Public);

                    if (propertyInfo == null || propertyInfo.PropertyType != typeof(string)) continue;

                    var value = (string) propertyInfo.GetValue(control);

                    var valuePaddingLeft = Regex.Match(value, @"^\s*").Value;
                    var valuePaddingRight = Regex.Match(value, @"\s*$").Value;

                    value = FormatResourceKey(value.Trim());
                    if (string.IsNullOrWhiteSpace(value) || !Resources.ContainsKey(value)) continue;

                    propertyInfo.SetValue(control,
                        valuePaddingLeft +
                        Resources[value].GetValue(null) +
                        valuePaddingRight);
                }
            }

            foreach (Control control in container.Controls)
            {
                TranslateControl(control);
                Translate(control);
            }

            TranslateControl(container);

            return container;
        }

        /// <summary>
        ///     Localiza todos as mensagens e realiza a tradução quando possível.
        /// </summary>
        /// <param name="tooltip">ToolTip</param>
        public static ToolTip Translate(this ToolTip tooltip)
        {
            var controlsIntoTooltip = tooltip.Hashtable();
            var messagesNotTranslated = new Dictionary<Control, string>();
            PropertyInfo? propertyInfo = null;
            foreach (var entry in controlsIntoTooltip.Cast<DictionaryEntry>().ToList())
            {
                if (propertyInfo == null)
                    propertyInfo =
                        entry.Value.GetType().GetProperty("Caption", BindingFlags.Instance | BindingFlags.Public)
                        ?? throw new ThisWillNeverOccurException();

                var control = (Control) entry.Key;
                var resource = FormatResourceKey((string) propertyInfo.GetValue(entry.Value));

                if (!Resources.ContainsKey(resource)) continue;

                messagesNotTranslated.Add(control, resource);
                controlsIntoTooltip.Remove(control);
            }

            foreach (var message in messagesNotTranslated)
            {
                var text = (string) Resources[message.Value].GetValue(null);
                tooltip.SetToolTip(message.Key, text);
            }

            return tooltip;
        }

        /// <summary>
        ///     Formata uma chave de recurso para corresponder a pesquisa.
        /// </summary>
        /// <param name="resourceKey">Chave do recurso.</param>
        /// <returns>Mesma chave, porém formatada.</returns>
        private static string FormatResourceKey(string resourceKey)
        {
            return Regex.Replace(resourceKey, @"[^a-zA-Z0-9]{1}", "_");
        }
    }
}