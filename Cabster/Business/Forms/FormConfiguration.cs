using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;
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
        /// Tecla de atalho.
        /// </summary>
        public Keys? Shortcut
        {
            get
            {
                if (string.IsNullOrWhiteSpace(textBoxShortcutLetter.Text)) return null;
                var shortcut = Keys.None;
                if (checkBoxShortcutControl.Checked) shortcut |= Keys.Control;
                if (checkBoxShortcutShift.Checked) shortcut |= Keys.Shift;
                if (checkBoxShortcutAlt.Checked) shortcut |= Keys.Alt;

                var text = textBoxShortcutLetter.Text[0];
                var isNumber = text >= '0' && text <= '9';
                var value = (Keys) Enum.Parse(typeof(Keys), isNumber ? $"D{text}" : $"{text}");
                
                shortcut |= value;
                
                return shortcut;
            }
            set
            {
                checkBoxShortcutControl.Checked = (value & Keys.Control) == Keys.Control;
                checkBoxShortcutShift.Checked = (value & Keys.Shift) == Keys.Shift;
                checkBoxShortcutAlt.Checked = (value & Keys.Alt) == Keys.Alt;

                var key = value & ~Keys.Control & ~Keys.Shift & ~Keys.Alt;
                var text = $"{key}";

                if (text.Length == 2) text = text.Substring(1);

                textBoxShortcutLetter.Text = text;
            }
        }

        /// <summary>
        ///     Botão para troca de idioma.
        /// </summary>
        /// <param name="sender">Fonte do evento.</param>
        /// <param name="args">Informações do evento.</param>
        private void buttonLanguage_Click(object sender, EventArgs args)
        {
            Shortcut = Keys.D3 | Keys.Control | Keys.Shift;
            
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

        /// <summary>
        /// Evento ao altera a letra do atalho.
        /// </summary>
        /// <param name="sender">Fonte do evento.</param>
        /// <param name="args">Informações do evento.</param>
        private void textBoxShortcutLetter_TextChanged(object sender, EventArgs args)
        {
            textBoxShortcutLetter.Text = 
                Regex.Replace(
                    textBoxShortcutLetter.Text.ToUpper(),
                    @"[^A-Z0-9]", string.Empty);
            textBoxShortcutLetter.SelectAll();
        }
    }
}