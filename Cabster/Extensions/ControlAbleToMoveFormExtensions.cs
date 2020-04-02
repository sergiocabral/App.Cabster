using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Windows.Forms;

namespace Cabster.Extensions
{
    /// <summary>
    ///     Habilita o movimento do form por um controle.
    /// </summary>
    public static class ControlAbleToMoveFormExtensions
    {
        /// <summary>
        ///     Lista de controles que movem o form.
        /// </summary>
        private static readonly Dictionary<Control, MakeAbleToMoveFormInfo> Forms =
            new Dictionary<Control, MakeAbleToMoveFormInfo>();

        /// <summary>
        ///     Torna um controle capaz de mover o form.
        /// </summary>
        /// <param name="control">Form.</param>
        /// <param name="enable">Modo.</param>
        public static void MakeAbleToMoveForm(this Control control, bool enable = true)
        {
            var containsKey = Forms.ContainsKey(control);

            if (!containsKey && !enable) return;

            if (!containsKey) Forms.Add(control, new MakeAbleToMoveFormInfo(control));

            Forms[control].Enable(enable);

            if (!enable) Forms.Remove(control);
        }

        /// <summary>
        ///     Informações dos controles que movem o form.
        /// </summary>
        private class MakeAbleToMoveFormInfo
        {
            /// <summary>
            ///     Controle.
            /// </summary>
            private readonly Control _control;

            /// <summary>
            ///     Janela que contém o controle.
            /// </summary>
            private readonly Control _form;

            private Point _initialPositionOfMouse;

            private bool _isPressing;

            /// <summary>
            ///     Construtor.
            /// </summary>
            /// <param name="control">Control.</param>
            public MakeAbleToMoveFormInfo(Control control)
            {
                _form = _control = control;
                while (_form != null && !(_form is Form)) _form = _form.Parent;
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

                _form.Left += moveLeft;
                _form.Top += moveTop;
            }

            /// <summary>
            ///     Evento quando o mouse é liberado.
            /// </summary>
            /// <param name="sender">Fonte do evento.</param>
            /// <param name="args">Informações do evento.</param>
            [ExcludeFromCodeCoverage]
            private void ControlOnMouseUp(object sender, MouseEventArgs args)
            {
                _isPressing = false;
            }
        }
    }
}