using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Cabster.Business.Messenger.Request;
using Cabster.Business.Values;
using Cabster.Components;
using Cabster.Properties;
using Serilog;

namespace Cabster.Business.Forms
{
    /// <summary>
    ///     Janela de configuração
    /// </summary>
    public partial class FormConfiguration : FormLayout, IFormContainerData
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
            ButtonCloseClick += OnButtonCloseClick;
            Shown += (sender, args) =>
            {
                UpdateControls();
                _loaded = true;
            };
        }

        /// <summary>
        /// Sinaliza o carregamento da tela.
        /// </summary>
        private bool _loaded;
        
        /// <summary>
        /// Notifica a atualização dos controles da tela.
        /// </summary>
        public void UpdateControls()
        {
            var data = Program.Data;
            _lastShortcut = Shortcut = data.Application.Shortcut;
        }

        /// <summary>
        /// Tecla de atalho.
        /// </summary>
        public Keys Shortcut
        {
            get
            {
                var shortcut = Keys.None;
                
                if (checkBoxShortcutControl.Checked) shortcut |= Keys.Control;
                if (checkBoxShortcutShift.Checked) shortcut |= Keys.Shift;
                if (checkBoxShortcutAlt.Checked) shortcut |= Keys.Alt;

                if (string.IsNullOrWhiteSpace(textBoxShortcutLetter.Text)) return shortcut;
                
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

                if (text.Length == 2 && text[0] == 'D') text = text.Substring(1);

                textBoxShortcutLetter.Text = text.Length == 1 ? text : string.Empty;
            }
        }

        /// <summary>
        ///     Botão para troca de idioma.
        /// </summary>
        /// <param name="sender">Fonte do evento.</param>
        /// <param name="args">Informações do evento.</param>
        private void buttonLanguage_Click(object sender, EventArgs args)
        {
            var newLanguage = new CultureInfo(sender == buttonLanguagePortuguese 
                ? TwoLetterLanguage.Portuguese 
                : TwoLetterLanguage.English);
            var currentLanguage = CultureInfo.CurrentUICulture;

            if (currentLanguage.TwoLetterISOLanguageName == newLanguage.TwoLetterISOLanguageName)
            {
                SetStatusMessage(Resources.Window_Configuration_LanguageAlreadySelected);
                return;
            }

            if (!FormDialogConfirm.Show(Resources.Window_Configuration_LanguageChangeConfirm)) return;

            MessageBus.Send(new ApplicationChangeLanguage(newLanguage));
            
            ButtonClose.PerformClick();
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
            SaveShortcut();
        }

        /// <summary>
        /// Evento ao marcar um botão de atalho.
        /// </summary>
        /// <param name="sender">Fonte do evento.</param>
        /// <param name="args">Informações do evento.</param>
        private void checkBoxShortcut_CheckedChanged(object sender, EventArgs args)
        {
            SaveShortcut();
        }

        /// <summary>
        /// Última tecla de atalho gravada.
        /// </summary>
        private Keys _lastShortcut;

        /// <summary>
        /// Dados pendentes de gravação.
        /// </summary>
        private DataSection _pendingToSave;
        
        /// <summary>
        /// Grava as informações da tecla de atalho.
        /// </summary>
        private void SaveShortcut()
        {
            if (!_loaded) return;
            timerToSaveShortcut.Enabled = false;
            timerToSaveShortcut.Enabled = true;
            _pendingToSave |= DataSection.ApplicationShortcut;
        }

        /// <summary>
        /// Evento para efetivar a gravação da tecla de atalho.
        /// </summary>
        /// <param name="sender">Fonte do evento.</param>
        /// <param name="args">Informações do evento.</param>
        private void timerToSaveShortcut_Tick(object sender, EventArgs args)
        {
            ((Timer) sender).Enabled = false;
            if (Shortcut == _lastShortcut) return;
            var data = Program.Data;
            data.Application.Shortcut = Shortcut;
            MessageBus.Send(new DataUpdate(data, DataSection.ApplicationShortcut));
            _pendingToSave ^= DataSection.ApplicationShortcut;
        }

        /// <summary>
        ///     Quando clica o botão de fechar a janela.
        /// </summary>
        private async void OnButtonCloseClick()
        {
            Hide();
            if (_pendingToSave == 0) return;
            var data = Program.Data;
            data.Application.Shortcut = Shortcut;
            await MessageBus.Send(new DataUpdate(data, _pendingToSave));
        }
    }
}