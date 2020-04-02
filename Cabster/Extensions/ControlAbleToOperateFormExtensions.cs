using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Windows.Forms;

namespace Cabster.Extensions
{
    /// <summary>
    ///     Habilita o movimento do form por um controle.
    /// </summary>
    public static class ControlAbleToOperateFormExtensions
    {
        /// <summary>
        ///     Lista de controles que movem o form.
        /// </summary>
        private static readonly Dictionary<int, MakeAbleToOperateFormInfo> Forms =
            new Dictionary<int, MakeAbleToOperateFormInfo>();

        /// <summary>
        ///     Torna um controle capaz de redimensionar o form.
        /// </summary>
        /// <param name="control">Form.</param>
        /// <param name="enable">Modo.</param>
        public static void MakeAbleToResizeForm(this Control control, bool enable = true)
        {
            MakeAbleToOperateForm(control, Operations.Resize, enable);
        }

        /// <summary>
        ///     Torna um controle capaz de mover o form.
        /// </summary>
        /// <param name="control">Form.</param>
        /// <param name="enable">Modo.</param>
        public static void MakeAbleToMoveForm(this Control control, bool enable = true)
        {
            MakeAbleToOperateForm(control, Operations.Move, enable);
        }

        /// <summary>
        ///     Torna um controle capaz de mover o form.
        /// </summary>
        /// <param name="control">Form.</param>
        /// <param name="operation">Operação.</param>
        /// <param name="enable">Modo.</param>
        private static void MakeAbleToOperateForm(Control control, Operations operation, bool enable = true)
        {
            var key = GetKey(control, nameof(MakeAbleToMoveForm));
            var containsKey = Forms.ContainsKey(key);

            if (!containsKey && !enable) return;

            if (!containsKey) Forms.Add(key, new MakeAbleToOperateFormInfo(control, operation));

            Forms[key].Enable(enable);

            if (!enable) Forms.Remove(key);
        }

        /// <summary>
        ///     Gera uma chave única.
        /// </summary>
        /// <param name="control">Controle</param>
        /// <param name="operation">Nome da operação.</param>
        /// <returns>Valor para chave.</returns>
        private static int GetKey(object control, string operation)
        {
            return $"{control.GetHashCode()}{operation}".GetHashCode();
        }

        /// <summary>
        ///     Operações disponíveis.
        /// </summary>
        private enum Operations
        {
            /// <summary>
            ///     Redimensionar form.
            /// </summary>
            Resize,

            /// <summary>
            ///     Mover form.
            /// </summary>
            Move
        }

        /// <summary>
        ///     Informações dos controles que movem o form.
        /// </summary>
        private class MakeAbleToOperateFormInfo
        {
            /// <summary>
            ///     Controle.
            /// </summary>
            private readonly Control _control;

            /// <summary>
            ///     Janela que contém o controle.
            /// </summary>
            private readonly Control _form;

            /// <summary>
            ///     Operação.
            /// </summary>
            private readonly Operations _operation;

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
            /// <param name="operation">Operação.</param>
            public MakeAbleToOperateFormInfo(Control control, Operations operation)
            {
                _operation = operation;
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

                // ReSharper disable once SwitchStatementHandlesSomeKnownEnumValuesWithDefault
                switch (_operation)
                {
                    case Operations.Move:
                        _form.Left += moveLeft;
                        _form.Top += moveTop;
                        break;
                    case Operations.Resize:
                        _form.Width += moveLeft;
                        _form.Height += moveTop;
                        break;
                }
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