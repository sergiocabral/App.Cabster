using System;
using System.Diagnostics;
using System.Windows.Forms;
using Cabster.Business.Entities;
using Cabster.Business.Messenger.Request;
using Cabster.Components;
using Cabster.Extensions;

namespace Cabster.Business.Forms
{
    /// <summary>
    ///     Janela para exibir o tempo do trabalho.
    /// </summary>
    public partial class FormGroupWorkTimer : FormBase, IFormContainerData
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
        ///     Construtor.
        /// </summary>
        public FormGroupWorkTimer()
        {
            InitializeComponent();
            InitializeComponent2();
        }

        /// <summary>
        ///     Valor no temporizador
        /// </summary>
        private string Timer
        {
            get => labelTimer.Text;
            set => labelTimer.Invoke((Action) (() => labelTimer.Text = value));
        }

        /// <summary>
        ///     Nome do driver.
        /// </summary>
        private string Driver
        {
            get => labelDriver.Text;
            set => labelDriver.Invoke((Action) (() => labelDriver.Text = value));
        }

        /// <summary>
        ///     Nome do navegador.
        /// </summary>
        private string Navigator
        {
            get => labelNavigator.Text;
            set => labelNavigator.Invoke((Action) (() => labelNavigator.Text = value));
        }

        /// <summary>
        ///     Tempo limite da exibição da janela.
        /// </summary>
        private DateTimeOffset Limit { get; set; }

        /// <summary>
        ///     Notifica a atualização dos controles da tela.
        /// </summary>
        /// <param name="data">Dados da aplicação.</param>
        public void UpdateControls(ContainerData? data = null)
        {
            data ??= Program.Data;
            Driver = data.GroupWork.Timer.Driver;
            Navigator = data.GroupWork.Timer.Navigator;
            Limit = data.GroupWork.Timer.Limit;
            UpdateTimer();
        }

        /// <summary>
        ///     Inicialização dos controles.
        /// </summary>
        private void InitializeComponent2()
        {
            Shown += UpdatePosition;
            Shown += UpdateControls;
            foreach (var control in this.AllControls()) control.MouseEnter += UpdatePosition;
            VisibleChanged += UpdatePosition;
            VisibleChanged += (sender, args) => timer.Enabled = Visible;
        }

        /// <summary>
        ///     Atualiza a posição da janela.
        /// </summary>
        private void UpdatePosition()
        {
            if (!Visible) return;
            if (_stopwatchUpdatePosition.IsRunning && _stopwatchUpdatePosition.ElapsedMilliseconds < 100) return;
            _stopwatchUpdatePosition.Restart();

            var screen = Screen.FromControl(this);
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
            if (timeLeft.Ticks <= 0)
            {
                MessageBus.Send(new UserActionGroupWorkTimerEnd());
                Timer = TimerReset;
            }
            else
            {
                Timer = new DateTime(timeLeft.Ticks).ToString(TimerFormat);
            }
        }

        /// <summary>
        ///     Timer para atualizar os controles da tela.
        /// </summary>
        /// <param name="sender">Fonte do evento.</param>
        /// <param name="args">Informações do evento.</param>
        private void timer_Tick(object sender, EventArgs e)
        {
            UpdateTimer();
        }
    }
}