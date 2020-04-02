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

            this.MakeInvisible();

            new FormConfiguration().Show();
        }

        private void timer_Tick(object sender, EventArgs e)
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