using System;
using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Windows.Forms;
using Cabster.Business;
using Cabster.Business.Messenger.Request;
using Cabster.Business.Values;
using Cabster.Exceptions;
using Cabster.Extensions;
using Cabster.Properties;
using Environment = Cabster.Infrastructure.Environment;

namespace Cabster.Components
{
    /// <summary>
    ///     Janela invisível.
    /// </summary>
    public partial class FormLayout : FormBase, IFormLayout
    {
        /// <summary>
        ///     Lista de forms e suas posições do eixo Z.
        /// </summary>
        private static readonly ConcurrentDictionary<int, int> ZOrders = new ConcurrentDictionary<int, int>();

        /// <summary>
        ///     Identificador desta instância.
        /// </summary>
        private int _myHashCode;

        /// <summary>
        ///     Exibe o logotipo.
        /// </summary>
        private bool _showLogo;

        /// <summary>
        ///     Construtor.
        /// </summary>
        public FormLayout()
        {
            InitializeComponent();
            InitializeComponent2();
        }

        /// <summary>
        ///     Esconde a barra de status
        /// </summary>
        protected bool HideStatusBar
        {
            get => !labelStatus.Visible;
            set => buttonNotification.Visible = labelStatus.Visible = !value;
        }

        /// <summary>
        ///     ButtonClose.
        /// </summary>
        protected Button ButtonClose => buttonClose;

        /// <summary>
        ///     ButtonMinimize.
        /// </summary>
        protected Button ButtonMinimize => buttonMinimize;

        /// <summary>
        ///     Bloqueador de telas.
        /// </summary>
        private static ILockScreen LockScreen =>
            Program.DependencyResolver.GetInstanceRequired<ILockScreen>();

        /// <summary>
        ///     Exibe o botão minimizar.
        /// </summary>
        public bool ShowButtonMinimize
        {
            get => buttonMinimize.Visible; 
            set => buttonMinimize.Visible = value;
        }

        /// <summary>
        ///     Exibe o logotipo.
        /// </summary>
        public bool ShowLogo
        {
            get => panelLogo.Visible = _showLogo;
            set
            {
                _showLogo = value;
                panelLogo.Visible = _showLogo;
                panelLogo.Left = _showLogo ? 0 : Width + 10;
            }
        }

        /// <summary>
        ///     Evita o uso de ESC para fechar a janela.
        /// </summary>
        public bool NotUseEscToClose { get; set; }

        /// <summary>
        ///     Mensagem de status.
        /// </summary>
        public string StatusMessage
        {
            get => labelStatus.Text;
            set => SetStatusMessage(value);
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
        ///     Define uma mensagem de status.
        /// </summary>
        /// <param name="message">Mensagem.</param>
        /// <param name="information">Quando true, azul. Se false, vermelho.</param>
        public void SetStatusMessage(string message, bool information = true)
        {
            timerStatus.Enabled = false;
            timerStatus.Enabled = true;
            labelStatus.Text = message;
            labelStatus.ForeColor = information
                ? Color.NotificationSuccess
                : Color.NotificationError;
        }

        /// <summary>
        ///     Ordem do eixo Z.
        /// </summary>
        public int ZOrder =>
            ZOrders.ContainsKey(_myHashCode)
                ? ZOrders[_myHashCode]
                : throw new ThisWillNeverOccurException();

        /// <summary>
        ///     Inicializa os componentes da janela.
        /// </summary>
        private void InitializeComponent2()
        {
            if (!Environment.IsDesign)
            {
                SetStyle(
                    ControlStyles.AllPaintingInWmPaint |
                    ControlStyles.UserPaint |
                    ControlStyles.DoubleBuffer,
                    true);

                TopMost = LockScreen.IsLocked;
                
                ShowButtonMinimize = false;
            }

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
                buttonResize.Top = Height - buttonResize.Height;

                const int padding = 10;

                buttonNotification.Height = labelStatus.Height;
                buttonNotification.Top = Height - buttonNotification.Height - padding;
                buttonNotification.Left = padding;

                labelStatus.Top = buttonNotification.Top;
                labelStatus.Left = buttonNotification.Right + padding / 2;
                labelStatus.Width = Width - buttonResize.Width - labelStatus.Left;
            };
            Shown += (sender, args) => BringToFront();

            _myHashCode = GetHashCode();
            Activated += OnActivatedUpdateZOrder;
            OnActivatedUpdateZOrder(this, new EventArgs());
        }

        private void OnActivatedUpdateZOrder(object sender, EventArgs e)
        {
            var otherZOrders = ZOrders
                .Where(a => a.Key != _myHashCode)
                .ToArray();

            var maxZOrder =
                otherZOrders.Length > 0
                    ? otherZOrders.Max(a => a.Value) + 1
                    : 0;

            ZOrders.AddOrUpdate(
                _myHashCode,
                maxZOrder,
                (key, value) => maxZOrder);
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
        ///     Timer para remover mensagem de status.
        /// </summary>
        /// <param name="sender">Fonte do evento.</param>
        /// <param name="args">Informações do evento.</param>
        private void timerStatus_Tick(object sender, EventArgs args)
        {
            timerStatus.Enabled = false;
            labelStatus.Text = string.Empty;
        }

        /// <summary>
        ///     Ao minimizar, restaurar, maximizar.
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

        /// <summary>
        ///     Evento ao clicar no botão de notificações.
        /// </summary>
        /// <param name="sender">Fonte do evento.</param>
        /// <param name="args">Informações do evento.</param>
        private void buttonNotification_Click(object sender, EventArgs args)
        {
            MessageBus.Send<Form>(new WindowOpenNotification(this));
        }

        /// <summary>
        ///     Evento ao pressionar teclas.
        /// </summary>
        /// <param name="sender">Fonte do evento.</param>
        /// <param name="args">Informações do evento.</param>
        private void FormLayout_KeyUp(object sender, KeyEventArgs args)
        {
            if (!NotUseEscToClose && args.KeyCode == Keys.Escape)
                buttonClose.PerformClick();
        }
    }
}