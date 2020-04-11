using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cabster.Components
{
    /// <summary>
    /// Form de exibição de mensagem.
    /// </summary>
    public partial class FormDialogAlert : FormDialogBase
    {
        /// <summary>
        /// Exibir caixa de dialogo.
        /// </summary>
        /// <param name="message">Texto.</param>
        public static void Show(string message)
        {
            using var form = new FormDialogAlert
            {
                labelText =
                {
                    Text = message
                }
            };
            form.ShowDialog();
        }

        /// <summary>
        /// Construtor.
        /// </summary>
        public FormDialogAlert()
        {
            InitializeComponent();
            InitializeComponent2();
        }

        /// <summary>
        /// Inicializa controles.
        /// </summary>
        private void InitializeComponent2()
        {

        }

        /// <summary>
        /// Evento ao clicar no botão Fechar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void buttonDialogClose_Click(object sender, EventArgs args)
        {
            Close();
        }
    }
}