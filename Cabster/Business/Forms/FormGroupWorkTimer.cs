using System;
using System.Diagnostics;
using System.Windows.Forms;
using Cabster.Components;

namespace Cabster.Business.Forms
{
    /// <summary>
    ///     Janela para exibir o tempo do trabalho.
    /// </summary>
    public partial class FormGroupWorkTimer : FormBase, IFormApplication
    {
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
        public string Driver
        {
            get => labelDriver.Text;
            set => labelDriver.Text = value;
        }

        /// <summary>
        ///     Nome do navegador.
        /// </summary>
        public string Navigator
        {
            get => labelNavigator.Text;
            set => labelNavigator.Text = value;
        }

        /// <summary>
        ///     Inicialização dos controles.
        /// </summary>
        private void InitializeComponent2()
        {
            UpdatePosition();
        }

        /// <summary>
        /// Cronômetro para evitar atualização da posição freneticamente.
        /// </summary>
        private readonly Stopwatch _stopwatchUpdatePosition = new Stopwatch();
        
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
    }
}