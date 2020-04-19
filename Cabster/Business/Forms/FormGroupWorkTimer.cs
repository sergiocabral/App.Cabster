using System;
using System.Diagnostics;
using System.Windows.Forms;
using Cabster.Business.Entities;
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
        ///     Nome do driver.
        /// </summary>
        private string Driver
        {
            get => labelDriver.Text;
            set => labelDriver.Text = value;
        }

        /// <summary>
        ///     Nome do navegador.
        /// </summary>
        private string Navigator
        {
            get => labelNavigator.Text;
            set => labelNavigator.Text = value;
        }

        /// <summary>
        ///     Notifica a atualização dos controles da tela.
        /// </summary>
        /// <param name="data">Dados da aplicação.</param>
        public void UpdateControls(ContainerData? data = null)
        {
            data ??= Program.Data;
            Driver = data.GroupWork.Current.Driver;
            Navigator = data.GroupWork.Current.Navigator;
        }

        /// <summary>
        ///     Inicialização dos controles.
        /// </summary>
        private void InitializeComponent2()
        {
            Shown += UpdatePosition;
            foreach (var control in this.AllControls()) control.MouseEnter += UpdatePosition;
            VisibleChanged += UpdatePosition;
        }

        /// <summary>
        ///     Atualiza a posição da janela.
        /// </summary>
        private void UpdatePosition()
        {
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
    }
}