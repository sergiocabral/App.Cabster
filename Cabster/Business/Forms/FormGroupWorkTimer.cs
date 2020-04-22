using System;
using System.Diagnostics;
using System.Windows.Forms;
using Cabster.Business.Entities;
using Cabster.Business.Messenger.Request;
using Cabster.Components;
using Cabster.Extensions;
using Cabster.Properties;

namespace Cabster.Business.Forms
{
    /// <summary>
    ///     Janela para exibir o tempo do trabalho.
    /// </summary>
    public partial class FormGroupWorkTimer : FormBase, IFormContainerData, IFormTopMost
    {
        /// <summary>
        ///     Formato de exibição do temporizador.
        /// </summary>
        private const string TimerFormat = "mm:ss";

        /// <summary>
        ///     Texto para quando o temporizador está zerado.
        /// </summary>
        private static readonly string TimerReset =
            new DateTime().ToString(TimerFormat);

        /// <summary>
        ///     Cronômetro para evitar atualização da posição freneticamente.
        /// </summary>
        private readonly Stopwatch _stopwatchUpdatePosition = new Stopwatch();

        /// <summary>
        ///     Tempo que deve ser descontado do total.
        /// </summary>
        private TimeSpan _timeDiscarded;

        /// <summary>
        ///     Tempo total decorrido.
        /// </summary>
        private DateTimeOffset _timeStarted;

        /// <summary>
        ///     Construtor.
        /// </summary>
        public FormGroupWorkTimer()
        {
            InitializeComponent();
            InitializeComponent2();
        }

        /// <summary>
        ///     Tempo limite da exibição da janela.
        /// </summary>
        private DateTimeOffset Limit { get; set; }

        /// <summary>
        ///     Tempo decorrido incluindo descontos.
        /// </summary>
        private TimeSpan TimeElapsed =>
            DateTimeOffset.Now - _timeStarted - _timeDiscarded;

        /// <summary>
        ///     Notifica a atualização dos controles da tela.
        /// </summary>
        /// <param name="data">Dados da aplicação.</param>
        public void UpdateControls(ContainerData? data = null)
        {
            Invoke((Action) (() =>
            {
                data ??= Program.Data;
                
                var current = data.GroupWork.History[0];

                _timeDiscarded = TimeSpan.Zero;
                _timeStarted = current.Started;
                labelBreak.Visible = current.IsBreak;
                labelDriver.Text = current.Driver;
                labelNavigator.Text = current.Navigator;

                Limit = current.Started.Add(current.TimeExpected).ToLocalTime();
                
                UpdateTimer();
            }));
        }

        /// <summary>
        ///     Inicialização dos controles.
        /// </summary>
        private void InitializeComponent2()
        {
            labelBreak.BringToFront();
            Shown += UpdatePosition;
            Shown += UpdateControls;
            foreach (var control in this.AllControls()) control.MouseEnter += UpdatePosition;
            VisibleChanged += UpdatePosition;
        }

        /// <summary>
        ///     Atualiza a posição da janela.
        /// </summary>
        private void UpdatePosition()
        {
            if (!Visible) return;
            if (_stopwatchUpdatePosition.IsRunning && _stopwatchUpdatePosition.ElapsedMilliseconds < 100) return;
            _stopwatchUpdatePosition.Restart();

            var screen = Screen.FromPoint(Cursor.Position);
            var cursor = Cursor.Position;
            var isRight = cursor.X < screen.Bounds.Left + screen.Bounds.Width / 2;
            Top = screen.WorkingArea.Top + screen.WorkingArea.Height - Height;
            Left = isRight
                ? screen.WorkingArea.X + screen.WorkingArea.Width - Width
                : screen.WorkingArea.X;
            BringToFront();
        }

        /// <summary>
        ///     Atualiza a posição da janela
        /// </summary>
        /// <param name="sender">Fonte do evento.</param>
        /// <param name="args">Informações do evento.</param>
        private void UpdatePosition(object sender, EventArgs args)
        {
            UpdatePosition();
        }

        /// <summary>
        ///     Atualiza os dados da tela.
        /// </summary>
        /// <param name="sender">Fonte do evento.</param>
        /// <param name="args">Informações do evento.</param>
        private void UpdateControls(object sender, EventArgs args)
        {
            UpdateControls();
        }

        /// <summary>
        ///     Atualiza a exibição do temporizador.
        /// </summary>
        private void UpdateTimer()
        {
            var timeLeft = Limit - DateTimeOffset.Now;
            if (timeLeft.Ticks > 0)
            {
                if (!timer.Enabled) timer.Enabled = true;
                labelTimer.Text = new DateTime(timeLeft.Ticks).ToString(TimerFormat);
            }
            else
            {
                if (!timer.Enabled) return;
                timer.Enabled = false;
                MessageBus.Send(new UserActionGroupWorkTimerEnd(TimeElapsed));
                labelTimer.Text = TimerReset;
            }
        }

        /// <summary>
        ///     Timer para atualizar os controles da tela.
        /// </summary>
        /// <param name="sender">Fonte do evento.</param>
        /// <param name="args">Informações do evento.</param>
        private void timer_Tick(object sender, EventArgs args)
        {
            UpdateTimer();
            if (Screen.FromPoint(Cursor.Position).Bounds != Screen.FromControl(this).Bounds) UpdatePosition();
        }

        /// <summary>
        ///     Pausa o temporizador.
        /// </summary>
        public void Pause()
        {
            timer.Enabled = false;
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var cancel = FormDialogConfirm.Show(
                labelBreak.Visible
                    ? Resources.Window_GroupWorkTimer_StopwatchStoppedForBreak
                    : Resources.Window_GroupWorkTimer_StopwatchStoppedForWork,
                Resources.Name_Term_No,
                Resources.Name_Term_Yes);
            stopwatch.Stop();
            _timeDiscarded += stopwatch.Elapsed;

            if (cancel)
            {
                MessageBus.Send(new UserActionGroupWorkTimerEnd(TimeElapsed, false));
            }
            else
            {
                Limit = Limit.Add(stopwatch.Elapsed);
                timer.Enabled = true;
            }
        }
    }
}