using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Cabster.Properties;

namespace Cabster.Extensions
{
    /// <summary>
    ///     Utilitários para tradução.
    /// </summary>
    public static class TranslateExtensions
    {
        //TODO: Teste
        
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
        ///     Localiza todos as mensagens e realiza a tradução quando possível.
        /// </summary>
        /// <param name="tooltip">ToolTip</param>
        public static void Translate(this ToolTip tooltip)
        {
            var controlsIntoTooltip = tooltip.Hashtable();
            var messagesNotTranslated = new Dictionary<Control, string>();
            PropertyInfo? propertyInfo = null;
            foreach (var entry in controlsIntoTooltip.Cast<DictionaryEntry>().ToList())
            {
                if (propertyInfo == null)
                    propertyInfo =
                        entry.Value.GetType().GetProperty("Caption", BindingFlags.Instance | BindingFlags.Public)
                        ?? throw new Exception();

                var control = (Control) entry.Key;
                var resource = Regex.Replace((string) propertyInfo.GetValue(entry.Value), @"[^a-zA-Z0-9]{1}", "_");

                if (!Resources.ContainsKey(resource)) continue;

                messagesNotTranslated.Add(control, resource);
                controlsIntoTooltip.Remove(control);
            }

            foreach (var message in messagesNotTranslated)
            {
                var text = (string) Resources[message.Value].GetValue(null);
                tooltip.SetToolTip(message.Key, text);
            }
        }
    }
}