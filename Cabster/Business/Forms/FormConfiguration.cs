using System;
using System.Globalization;
using Cabster.Business.Messenger.Request;
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
        ///     Botão para troca de idioma.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void buttonLanguage_Click(object sender, EventArgs args)
        {
            var newLanguage = new CultureInfo(sender == buttonLanguagePortuguese ? "pt" : "en");
            var currentLanguage = CultureInfo.CurrentUICulture;

            if (currentLanguage.TwoLetterISOLanguageName == newLanguage.TwoLetterISOLanguageName)
            {
                SetStatusMessage(Resources.Text_Configuration_LanguageAlreadySelected);
                return;
            }

            if (!FormDialogConfirm.Show(Resources.Text_Configuration_LanguageChangeConfirm)) return;

            MessageBus.Send(new ApplicationChangeLanguage(newLanguage));
            
            buttonClose.PerformClick();
        }
    }
}