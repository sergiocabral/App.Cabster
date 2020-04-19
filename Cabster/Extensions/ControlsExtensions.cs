using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Cabster.Exceptions;

namespace Cabster.Extensions
{
    /// <summary>
    ///     Funções utilitárias para controles em geral.
    /// </summary>
    public static class ControlsExtensions
    {
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
            const string field = "tools";
            if (_fieldInfoFroToolTipHashtable == null)
                _fieldInfoFroToolTipHashtable =
                    tooltip
                        .GetType()
                        .GetField(field, BindingFlags.Instance | BindingFlags.NonPublic);
            return (Hashtable) (_fieldInfoFroToolTipHashtable?.GetValue(tooltip)
                                ?? throw new IsNullOrEmptyException($"{nameof(ToolTip)}.{field}"));
        }

        /// <summary>
        ///     Chama um determinado método para todos o controle e todos os seus filhos.
        /// </summary>
        /// <param name="control">Controle.</param>
        /// <typeparam name="T">Control</typeparam>
        /// <returns>Control</returns>
        public static T InvalidadeAll<T>(this T control) where T : Control
        {
            control.Invalidate();
            foreach (Control child in control.Controls) InvalidadeAll(child);
            return control;
        }

        /// <summary>
        /// Retorna todos os controls filhos. 
        /// </summary>
        /// <param name="target">Controle.</param>
        /// <typeparam name="T">Control</typeparam>
        /// <returns>Lista de controles</returns>
        public static IEnumerable<Control> AllControls<T>(this T target) where T : Control
        {
            var controls = new List<Control>();

            void Collect(Control control)
            {
                controls.Add(control);
                foreach (Control child in control.Controls)
                {
                    Collect(child);
                }
            }
            
            Collect(target);

            return controls;
        }

        /// <summary>
        ///     Organiza os controle filhos em flow.
        /// </summary>
        /// <param name="control">Controle.</param>
        /// <param name="order">Função para determinar a ordem de exibição.</param>
        /// <param name="padding">Espaçamento entre controles.</param>
        /// <typeparam name="T">Control</typeparam>
        /// <returns>Control</returns>
        public static T MakeChildrenOrganized<T>(this T control, Func<Control, int>? order = null, int padding = 5)
            where T : Control
        {
            var containerWidth = control.Width;
            var currentLeft = 0;
            var currentTop = 0;
            var currentHeightOfLine = 0;
            foreach (var child in control
                .Controls
                .OfType<Control>()
                .OrderBy(child => order?.Invoke(child) ?? child.Left * child.Left + child.Top * child.Top))
            {
                int childLeft;
                int childTop;
                int childRight;

                do
                {
                    // Dimensões do controle.
                    childLeft = padding + currentLeft;
                    childTop = padding + currentTop;
                    childRight = childLeft + child.Width;

                    // Não é o primeiro controle e passou do limite do container.
                    if (currentLeft > 0 && childRight > containerWidth + padding)
                    {
                        // Pula para próxima linha.
                        currentTop += padding + currentHeightOfLine;

                        // Volta para o início da linha.
                        currentLeft = 0;

                        // Redefine a altura da linha.
                        currentHeightOfLine = 0;

                        // Refaz os cálculos
                        continue;
                    }

                    // Ajusta o tamanho da linha de acordo com a altura do maior controle nela.
                    if (currentHeightOfLine < child.Height) currentHeightOfLine = child.Height;

                    // Finaliza os cálculos.
                    break;
                } while (true);

                // Avança a próxima posição do controle.
                currentLeft = childRight;

                child.Left = childLeft;
                child.Top = childTop;
            }

            return control;
        }
    }
}