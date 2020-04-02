using System;
using System.Diagnostics;
using Cabster.Business.Forms;
using Cabster.Extensions;

namespace Cabster.Components
{
    /// <summary>
    ///     Janela invisível.
    /// </summary>
    public partial class FormMainWindow : FormBase
    {
        /// <summary>
        ///     Construtor.
        /// </summary>
        public FormMainWindow()
        {
            InitializeComponent();
            InitializeComponent2();
        }

        /// <summary>
        ///     Inicializa os componentes da janela.
        /// </summary>
        private void InitializeComponent2()
        {
            this.MakeInvisible();

            new FormConfiguration().Show();
        }

        /// <summary>
        ///     Clock de funcionamento da aplicação.
        /// </summary>
        /// <param name="sender">Fonte do evento.</param>
        /// <param name="args">Informações do evento.</param>
        private void timer_Tick(object sender, EventArgs args)
        {
            timer.Enabled = false;
            try
            {
                Trace.WriteLine($"Tick {DateTime.Now.Ticks}");
            }
            finally
            {
                if (Program.SignalToTerminate) Close();
                else timer.Enabled = true;
            }
        }
    }
}