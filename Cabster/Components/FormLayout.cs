using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Windows.Forms;
using Cabster.Extensions;
using Cabster.Properties;

namespace Cabster.Components
{
    /// <summary>
    ///     Janela invisível.
    /// </summary>
    public partial class FormLayout : FormBase
    {
        /// <summary>
        ///     Construtor.
        /// </summary>
        public FormLayout()
        {
            InitializeComponent();
            InitializeComponent2();
        }

        /// <summary>
        ///     Exibe o logotipo.
        /// </summary>
        public bool ShowLogo
        {
            get => panelLogo.Visible;
            set => panelLogo.Visible = value;
        }

        /// <summary>
        ///     Quando clica no botão fechar.
        ///     Retorna false para cancelar o fechamento.
        /// </summary>
        public event Action? ButtonCloseClick;

        /// <summary>
        ///     Quando clica no botão minimizar.
        ///     Retorna false para cancelar o fechamento.
        /// </summary>
        public event Action? ButtonMinimizeClick;

        /// <summary>
        ///     Inicializa os componentes da janela.
        /// </summary>
        private void InitializeComponent2()
        {
            if (Program.IsDebug != null)
                SetStyle(
                    ControlStyles.AllPaintingInWmPaint |
                    ControlStyles.UserPaint |
                    ControlStyles.DoubleBuffer,
                    true);

            AdjustLogo();
            labelTitle.MakeAbleToMoveForm();
            buttonResize.MakeAbleToResizeForm();
            HandleCreated += (sender, args) => toolTip.Translate();
            Load += (sender, args) =>
            {
                labelTitle.Text = Text;
                Icon = Resources.IconSapiensia;
            };
            Resize += (sender, args) =>
            {
                buttonResize.Left = Width - buttonResize.Width;
                buttonResize.Top = Height - buttonResize.Height + 1;

                labelStatus.Left = 10;
                labelStatus.Top = Height - labelStatus.Height - labelStatus.Left;
                labelStatus.Width = Width - buttonResize.Width - labelStatus.Left;
            };
        }

        /// <summary>
        ///     Evento ao clicar no botão fechar.
        /// </summary>
        /// <param name="sender">Fonte do evento.</param>
        /// <param name="args">Informações do evento.</param>
        [ExcludeFromCodeCoverage]
        private void buttonClose_Click(object sender, EventArgs args)
        {
            if (ButtonCloseClick == null) Hide();
            else ButtonCloseClick();
        }

        /// <summary>
        ///     Evento ao clicar no botão minimizar.
        /// </summary>
        /// <param name="sender">Fonte do evento.</param>
        /// <param name="args">Informações do evento.</param>
        [ExcludeFromCodeCoverage]
        private void buttonMinimize_Click(object sender, EventArgs args)
        {
            if (ButtonMinimizeClick == null) WindowState = FormWindowState.Minimized;
            else ButtonMinimizeClick();
        }

        /// <summary>
        ///     Ajusta o posicionamento do logotipo.
        /// </summary>
        private void AdjustLogo()
        {
            panelLogo.Top = panelTitle.Top + panelTitle.Height;
            panelLogo.Left = 0;
            panelLogo.Width = panelLogo.BackgroundImage.Width * panelLogo.Height / panelLogo.BackgroundImage.Height;
        }

        /// <summary>
        ///     Evento ao tentar fechar o form.
        /// </summary>
        /// <param name="sender">Fonte do evento.</param>
        /// <param name="args">Informações do evento.</param>
        private void FormLayout_FormClosing(object sender, FormClosingEventArgs args)
        {
            args.Cancel = true;
            buttonClose.PerformClick();
        }

        /// <summary>
        /// Mensagem de status.
        /// </summary>
        public string StatusMessage
        {
            get => labelStatus.Text;
            set => SetStatusMessage(value);
        }

        /// <summary>
        /// Define uma mensagem de status.
        /// </summary>
        /// <param name="message">Mensagem.</param>
        /// <param name="information">Quando true, azul. Se false, vermelho.</param>
        public void SetStatusMessage(string message, bool information = true)
        {
            timerStatus.Enabled = false;
            timerStatus.Enabled = true;
            labelStatus.Text = message;
            labelStatus.ForeColor = information ? Color.RoyalBlue : Color.Brown;
        }

        /// <summary>
        /// Timer para remover mensagem de status.
        /// </summary>
        /// <param name="sender">Fonte do evento.</param>
        /// <param name="args">Informações do evento.</param>
        private void timerStatus_Tick(object sender, EventArgs args)
        {
            timerStatus.Enabled = false;
            labelStatus.Text = string.Empty;
        }

        /// <summary>
        /// Ao minimizar, restaurar, maximizar.
        /// </summary>
        /// <param name="sender">Fonte do evento.</param>
        /// <param name="args">Informações do evento.</param>
        private void FormLayout_SizeChanged(object sender, EventArgs args)
        {
            var timer = new Timer
            {
                Interval = 1,
                Enabled = true
            };
            timer.Tick += (sender2, args2) =>
            {
                ((Timer) sender2).Enabled = false;
                ((Timer) sender2).Dispose();
                this.InvalidadeAll();
            };
        }
    }
}