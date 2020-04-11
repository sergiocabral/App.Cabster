using Cabster.Components;
using Cabster.Properties;

namespace Cabster.Business.Forms
{
    /// <summary>
    ///     Janela de configuração
    /// </summary>
    public partial class FormConfiguration : FormLayout
    {
        /// <summary>
        ///     Construtor.
        /// </summary>
        public FormConfiguration()
        {
            InitializeComponent();
            InitializeComponent2();
        }

        /// <summary>
        ///     Inicializa controles.
        /// </summary>
        private void InitializeComponent2()
        {
        }

        /// <summary>
        /// Botão para troca de idioma.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void buttonLanguage_Click(object sender, System.EventArgs args)
        {
            if (!FormDialogConfirm.Show(Resources.Text_Configuration_LanguageChangeConfirm)) return;
        }
    }
}