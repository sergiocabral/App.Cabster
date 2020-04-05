using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Windows.Forms;

namespace Cabster.Extensions
{
    /// <summary>
    ///     Habilita o movimento do controle pelo mouse.
    /// </summary>
    public static class ControlAbleToMoveWithMouseExtensions
    {
        /// <summary>
        ///     Lista de controles.
        /// </summary>
        private static readonly Dictionary<Control, MakeAbleToMoveWithMouseInfo> Forms =
            new Dictionary<Control, MakeAbleToMoveWithMouseInfo>();

        /// <summary>
        ///     Torna um controle capaz ser movido pelo mouse.
        /// </summary>
        /// <param name="control">Controle.</param>
        /// <param name="enable">Modo.</param>
        public static T MakeAbleToMoveWithMouse<T>(this T control, bool enable = true) where T : Control
        {
            var containsKey = Forms.ContainsKey(control);

            if (!containsKey && !enable) return control;

            if (!containsKey) Forms.Add(control, new MakeAbleToMoveWithMouseInfo(control));

            Forms[control].Enable(enable);

            if (!enable) Forms.Remove(control);

            return control;
        }

        /// <summary>
        ///     Informações dos controles que movem o form.
        /// </summary>
        private class MakeAbleToMoveWithMouseInfo
        {
            /// <summary>
            ///     Controle.
            /// </summary>
            private readonly Control _control;

            /// <summary>
            ///     Posição inicial do mouse ao clicar.
            /// </summary>
            private Point _initialPositionOfMouse;

            /// <summary>
            ///     Indica que mouse está sendo pressionado.
            /// </summary>
            private bool _isPressing;

            /// <summary>
            ///     Construtor.
            /// </summary>
            /// <param name="control">Control.</param>
            public MakeAbleToMoveWithMouseInfo(Control control)
            {
                _control = control;
            }

            /// <summary>
            ///     Ativa ou desativa a funcionalidade.
            /// </summary>
            /// <param name="enable">Modo.</param>
            public void Enable(bool enable)
            {
                if (enable)
                {
                    _control.MouseDown += ControlOnMouseDown;
                    _control.MouseMove += ControlOnMouseMove;
                    _control.MouseUp += ControlOnMouseUp;
                }
                else
                {
                    _control.MouseDown -= ControlOnMouseDown;
                    _control.MouseMove -= ControlOnMouseMove;
                    _control.MouseUp -= ControlOnMouseUp;
                }
            }

            /// <summary>
            ///     Evento quando o mouse clica.
            /// </summary>
            /// <param name="sender">Fonte do evento.</param>
            /// <param name="args">Informações do evento.</param>
            [ExcludeFromCodeCoverage]
            private void ControlOnMouseDown(object sender, MouseEventArgs args)
            {
                _isPressing = true;
                _initialPositionOfMouse = new Point(args.X, args.Y);
                _control.BringToFront();
            }

            /// <summary>
            ///     Evento quando o mouse se move.
            /// </summary>
            /// <param name="sender">Fonte do evento.</param>
            /// <param name="args">Informações do evento.</param>
            [ExcludeFromCodeCoverage]
            private void ControlOnMouseMove(object sender, MouseEventArgs args)
            {
                if (!_isPressing) return;

                var moveLeft = args.X - _initialPositionOfMouse.X;
                var moveTop = args.Y - _initialPositionOfMouse.Y;

                _control.Left += moveLeft;
                _control.Top += moveTop;
            }

            /// <summary>
            ///     Evento quando o mouse é liberado.
            /// </summary>
            /// <param name="sender">Fonte do evento.</param>
            /// <param name="args">Informações do evento.</param>
            [ExcludeFromCodeCoverage]
            private void ControlOnMouseUp(object sender, EventArgs args)
            {
                _isPressing = false;
            }
        }
    }
}