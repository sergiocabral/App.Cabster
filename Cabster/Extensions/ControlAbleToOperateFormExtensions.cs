using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        ///     Sinaliza que ao mover ou redimensionar deve desativar o redraw.
        /// </summary>
        public static bool SetRedrawFalse = false;

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
        public static T MakeAbleToResizeForm<T>(this T control, bool enable = true) where T : Control
        {
            return MakeAbleToOperateForm(control, Operations.Resize, enable);
        }

        /// <summary>
        ///     Torna um controle capaz de mover o form.
        /// </summary>
        /// <param name="control">Form.</param>
        /// <param name="enable">Modo.</param>
        public static T MakeAbleToMoveForm<T>(this T control, bool enable = true) where T : Control
        {
            return MakeAbleToOperateForm(control, Operations.Move, enable);
        }

        /// <summary>
        ///     Torna um controle capaz de mover o form.
        /// </summary>
        /// <param name="control">Form.</param>
        /// <param name="operation">Operação.</param>
        /// <param name="enable">Modo.</param>
        private static T MakeAbleToOperateForm<T>(T control, Operations operation, bool enable = true) where T : Control
        {
            var key = GetKey(control, nameof(MakeAbleToMoveForm));
            var containsKey = Forms.ContainsKey(key);

            if (!containsKey && !enable) return control;

            if (!containsKey) Forms.Add(key, new MakeAbleToOperateFormInfo(control, operation));

            var info = Forms[key];
            info.Enable(enable);

            if (enable) return control;

            info.Dispose();
            Forms.Remove(key);

            return control;
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
        private class MakeAbleToOperateFormInfo : IDisposable
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
            ///     Tempo entre desenhar de tela.
            /// </summary>
            private readonly int _millisecondsBetweenRedraw;

            /// <summary>
            ///     Operação.
            /// </summary>
            private readonly Operations _operation;

            /// <summary>
            ///     Cronômetro para determinar o tempo do Redraw.
            /// </summary>
            private readonly Stopwatch _stopwatch;

            /// <summary>
            ///     Temporizador para restabelecer os controles.
            /// </summary>
            private readonly Timer _timerToRestore;

            /// <summary>
            ///     Posição inicial do mouse ao clicar.
            /// </summary>
            private Point _initialPositionOfMouse;

            /// <summary>
            ///     Indica que mouse está sendo pressionado.
            /// </summary>
            private bool _isPressing;

            /// <summary>
            ///     Indica que o controle está redesenhando.
            /// </summary>
            private bool _isRedrawing;

            /// <summary>
            ///     Construtor.
            /// </summary>
            /// <param name="control">Control.</param>
            /// <param name="operation">Operação.</param>
            public MakeAbleToOperateFormInfo(Control control, Operations operation)
            {
                _millisecondsBetweenRedraw = operation == Operations.Resize ? 100 : int.MaxValue;
                _operation = operation;
                _form = _control = control;
                while (_form != null && !(_form is Form)) _form = _form.Parent;
                _stopwatch = new Stopwatch();
                _stopwatch.Start();
                _timerToRestore = new Timer
                {
                    Interval = 200,
                    Enabled = false
                };
                _timerToRestore.Tick += TimerToRestoreOnTick;
            }

            /// <summary>
            ///     Liberar recursos.
            /// </summary>
            public void Dispose()
            {
                _timerToRestore.Dispose();
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
                    _control.MouseLeave += ControlOnMouseUp;
                }
                else
                {
                    _control.MouseDown -= ControlOnMouseDown;
                    _control.MouseMove -= ControlOnMouseMove;
                    _control.MouseUp -= ControlOnMouseUp;
                    _control.MouseLeave -= ControlOnMouseUp;
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
                if (!SetRedrawFalse) return;
                _form.SetRedraw(false);
            }

            /// <summary>
            ///     Evento quando o mouse se move.
            /// </summary>
            /// <param name="sender">Fonte do evento.</param>
            /// <param name="args">Informações do evento.</param>
            [ExcludeFromCodeCoverage]
            private void ControlOnMouseMove(object sender, MouseEventArgs args)
            {
                if (!_isPressing || _isRedrawing) return;

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

                if (!SetRedrawFalse) return;
                if (_stopwatch.ElapsedMilliseconds < _millisecondsBetweenRedraw) return;
                _isRedrawing = true;
                _form.SetRedraw(true);
                _form.InvalidadeAll();
                Application.DoEvents();
                _form.SetRedraw(false);
                _stopwatch.Restart();
                _isRedrawing = false;
                _timerToRestore.Enabled = false;
                _timerToRestore.Enabled = true;
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
                if (!SetRedrawFalse) return;
                _form.SetRedraw(true);
                _form.InvalidadeAll();
            }

            /// <summary>
            ///     Temporizador para restabelecer estado dos controles.
            /// </summary>
            /// <param name="sender">Fonte do evento.</param>
            /// <param name="args">Informações do evento.</param>
            private void TimerToRestoreOnTick(object sender, EventArgs args)
            {
                _timerToRestore.Enabled = false;
                _form.SetRedraw(true);
                _form.InvalidadeAll();
            }
        }
    }
}