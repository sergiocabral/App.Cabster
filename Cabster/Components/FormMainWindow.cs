using System;
using System.Diagnostics;
using Cabster.Business.Entities;
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
            new FormConfiguration().Show();
        }

        /// <summary>
        ///     Inicializa os componentes da janela.
        /// </summary>
        private void InitializeComponent2()
        {
            this.MakeInvisible();
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
                // Aqui fica qualquer código que deva se basear em clock, ciclos, verificações, etc.
            }
            finally
            {
                if (Program.SignalToTerminate) Close();
                else timer.Enabled = true;
            }
        }

        /// <summary>
        /// Recarrega o conjunto de informações que configura o aplicativo.
        /// </summary>
        /// <returns>Conjunto de informações resultantes.</returns>
        public ContainerData ReloadData()
        {
            var data = Program.Data;

            return Program.Data;
        }
    }
}