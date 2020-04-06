using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using Cabster.Exceptions;

namespace Cabster.Extensions
{
    /// <summary>
    ///     Destaca a cor de um controle.
    /// </summary>
    public static class ControlHighlightExtensions
    {
        /// <summary>
        ///     Lista de controles que foram ajustados.
        /// </summary>
        private static readonly Dictionary<Control, MakeHighlightInfo> Controls =
            new Dictionary<Control, MakeHighlightInfo>();

        /// <summary>
        ///     Destaca a cor de um controle.
        /// </summary>
        /// <param name="control">Controle.</param>
        public static T MakeHighlight<T>(this T control) where T : Control
        {
            var containsKey = Controls.ContainsKey(control);

            if (!containsKey)
            {
                Controls.Add(control, new MakeHighlightInfo(control));
            }
            Controls[control].Highlight();

            return control;
        }

        /// <summary>
        ///     Informações dos controles que foram ajustados.
        /// </summary>
        private class MakeHighlightInfo
        {
            /// <summary>
            ///     Controle.
            /// </summary>
            private readonly Control _control;
            
            /// <summary>
            /// Temporizador.
            /// </summary>
            private readonly Timer _timer;

            /// <summary>
            /// Valor original: BackColor
            /// </summary>
            private readonly Color _backupBackColor;

            /// <summary>
            /// Valor original: BackColor
            /// </summary>
            private readonly Color? _backupBorderColor;

            /// <summary>
            /// Valor original: MouseDownBackColor
            /// </summary>
            private readonly Color? _backupMouseDownBackColor;

            /// <summary>
            /// Valor original: MouseOverBackColor
            /// </summary>
            private readonly Color? _backupMouseOverBackColor;

            /// <summary>
            ///     Construtor.
            /// </summary>
            /// <param name="control">Control.</param>
            public MakeHighlightInfo(Control control)
            {
                _control = control;
                
                _backupBackColor = control.BackColor;
                _control.BackColor = ControlPaint.LightLight(_control.BackColor);

                if (control is Button button)
                {
                    _backupBorderColor = button.FlatAppearance.BorderColor;
                    button.FlatAppearance.BorderColor = 
                        ControlPaint.LightLight(button.FlatAppearance.BorderColor);
                    
                    _backupMouseDownBackColor = button.FlatAppearance.MouseDownBackColor;
                    button.FlatAppearance.MouseDownBackColor = 
                        ControlPaint.LightLight(button.FlatAppearance.MouseDownBackColor);
                    
                    _backupMouseOverBackColor = button.FlatAppearance.MouseOverBackColor;
                    button.FlatAppearance.MouseOverBackColor = 
                        ControlPaint.LightLight(button.FlatAppearance.MouseOverBackColor);
                }

                _timer = new Timer
                {
                    Interval = 500,
                    Enabled = false
                };
                _timer.Tick += TimerOnTick;
            }

            /// <summary>
            /// Temporizador ativado para retornar o controle para seu estado original.
            /// </summary>
            /// <param name="sender">Fonte do evento.</param>
            /// <param name="args">Informações do evento.</param>
            private void TimerOnTick(object sender, EventArgs args)
            {
                _timer.Enabled = false;
                _timer.Dispose();
                
                _control.BackColor = _backupBackColor;
                if (_control is Button button)
                {
                    if (_backupBorderColor.HasValue)
                        button.FlatAppearance.BorderColor = _backupBorderColor.Value;
                    if (_backupMouseDownBackColor.HasValue)
                        button.FlatAppearance.MouseDownBackColor = _backupMouseDownBackColor.Value;
                    if (_backupMouseOverBackColor.HasValue)
                        button.FlatAppearance.MouseOverBackColor = _backupMouseOverBackColor.Value;
                }

                Controls.Remove(_control);
            }

            /// <summary>
            /// Destacar cor.
            /// </summary>
            public void Highlight()
            {
                _timer.Enabled = false;
                _timer.Enabled = true;
            }
        }
    }
}