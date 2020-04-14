using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cabster.Extensions
{
    /// <summary>
    /// Funções para formatar a exibição das teclas de atalho.
    /// </summary>
    public static class ShortcutKeysExtensions
    {
        /// <summary>
        /// Converte tecla de atalho num formato texto para exibição.
        /// </summary>
        /// <param name="shortcut">Tecla de atalho.</param>
        /// <returns>Tecla de atalho como texto.</returns>
        public static string ToShortcutDescription(this Keys shortcut)
        {
            var keys = new List<string>();

            void PatchModifier(Keys modifier)
            {
                if ((shortcut & modifier) != modifier) return;
                shortcut ^= modifier;
                keys.Add($"{modifier}");
            }

            PatchModifier(Keys.Control);
            PatchModifier(Keys.Shift);
            PatchModifier(Keys.Alt);

            if (shortcut == Keys.None) return string.Join("+", keys);
            
            var text = $"{shortcut}";
            text = text.Length == 2 ? text.Substring(1) : text;
            keys.Add(text);

            return string.Join("+", keys);
        }
    }
}