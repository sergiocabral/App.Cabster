using System;
using System.Windows.Forms;
using Cabster.Properties;

namespace Cabster.Components
{
    /// <summary>
    ///     Form de exibição de mensagem.
    /// </summary>
    public partial class FormDialogConfirm : FormDialogBase
    {
        /// <summary>
        ///     Construtor.
        /// </summary>
        private FormDialogConfirm()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     Exibir caixa de dialogo.
        /// </summary>
        /// <param name="message">Texto.</param>
        /// <param name="textForCancel">Texto para "Cancelar"</param>
        /// <param name="textForConfirm">Texto para "Confirmar"</param>
        public static bool Show(string message, string? textForCancel = null, string? textForConfirm = null)
        {
            using var form = new FormDialogConfirm
            {
                labelText =
                {
                    Text = message
                },
                buttonDialogCancel =
                {
                    Text = textForCancel ?? Resources.Name_Term_Cancel
                },
                buttonDialogConfirm = 
                {
                    Text = textForConfirm ?? Resources.Name_Term_Confirm
                }
            };
            return form.ShowDialog() != DialogResult.Cancel;
        }

        /// <summary>
        ///     Evento ao clicar no botão Fechar.
        /// </summary>
        /// <param name="sender">Fonte do evento.</param>
        /// <param name="args">Informações do evento.</param>
        private void buttonDialog_Click(object sender, EventArgs args)
        {
            DialogResult = sender == buttonDialogConfirm ? DialogResult.OK : DialogResult.Cancel;
            Close();
        }

        /// <summary>
        ///     Quando pressionar uma tecla.
        /// </summary>
        /// <param name="sender">Fonte do evento.</param>
        /// <param name="args">Informações do evento.</param>
        private void FormDialogConfirm_KeyUp(object sender, KeyEventArgs args)
        {
            if (args.KeyCode == Keys.Escape) buttonDialogCancel.PerformClick();
        }
    }
}