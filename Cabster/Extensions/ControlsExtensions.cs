using System;
using System.Collections;
using System.Reflection;
using System.Windows.Forms;

namespace Cabster.Extensions
{
    /// <summary>
    ///     Funções utilitárias para controles em geral.
    /// </summary>
    public static class ControlsExtensions
    {
        //TODO: Testar

        /// <summary>
        ///     PropertyInfo para acessar a propriedade ToolTip.tools
        /// </summary>
        private static FieldInfo? _fieldInfoFroToolTipHashtable;

        /// <summary>
        ///     Retorna o objeto Hashtable com os controles e suas respectivas traduções.
        /// </summary>
        /// <param name="tooltip">Tooltip</param>
        /// <returns>Hashtable.</returns>
        public static Hashtable Hashtable(this ToolTip tooltip)
        {
            if (_fieldInfoFroToolTipHashtable == null)
                _fieldInfoFroToolTipHashtable =
                    tooltip
                        .GetType()
                        .GetField("tools", BindingFlags.Instance | BindingFlags.NonPublic);
            return (Hashtable) (_fieldInfoFroToolTipHashtable?.GetValue(tooltip)
                                ?? throw new NullReferenceException());
        }
    }
}