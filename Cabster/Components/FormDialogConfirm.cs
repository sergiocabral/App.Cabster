﻿using System;
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
    public partial class FormDialogConfirm : FormDialogBase
    {
        /// <summary>
        /// Exibir caixa de dialogo.
        /// </summary>
        /// <param name="message">Texto.</param>
        public static bool Show(string message)
        {
            using var form = new FormDialogConfirm
            {
                labelText =
                {
                    Text = message
                }
            };
            return form.ShowDialog() != DialogResult.Cancel;
        }

        /// <summary>
        /// Construtor.
        /// </summary>
        public FormDialogConfirm()
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
        /// <param name="sender">Fonte do evento.</param>
        /// <param name="args">Informações do evento.</param>
        private void buttonDialog_Click(object sender, EventArgs args)
        {
            DialogResult = sender == buttonDialogConfirm ? DialogResult.OK : DialogResult.Cancel;
            Close();
        }

        /// <summary>
        /// Quando pressionar uma tecla.
        /// </summary>
        /// <param name="sender">Fonte do evento.</param>
        /// <param name="args">Informações do evento.</param>
        private void FormDialogConfirm_KeyUp(object sender, KeyEventArgs args)
        {
            if (args.KeyCode == Keys.Escape) buttonDialogCancel.PerformClick();
        }
    }
}