using System;
using System.Windows.Forms;

namespace Cabster.Components
{
    /// <summary>
    ///     Form de exibição de mensagem.
    /// </summary>
    public partial class FormDialogAlert : FormDialogBase
    {
        /// <summary>
        ///     Construtor.
        /// </summary>
        public FormDialogAlert()
        {
            InitializeComponent();
            InitializeComponent2();
        }

        /// <summary>
        ///     Exibir caixa de dialogo.
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
        ///     Inicializa controles.
        /// </summary>
        private void InitializeComponent2()
        {
        }

        /// <summary>
        ///     Evento ao clicar no botão Fechar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void buttonDialogClose_Click(object sender, EventArgs args)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        ///     Quando pressionar uma tecla.
        /// </summary>
        /// <param name="sender">Fonte do evento.</param>
        /// <param name="args">Informações do evento.</param>
        private void FormDialogConfirm_KeyUp(object sender, KeyEventArgs args)
        {
            if (args.KeyCode == Keys.Escape) buttonDialogClose.PerformClick();
        }
    }
}