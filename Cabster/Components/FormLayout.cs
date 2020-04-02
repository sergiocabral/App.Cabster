using System;
using System.Diagnostics.CodeAnalysis;
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
            labelTitle.MakeAbleToMoveForm();
            buttonResize.MakeAbleToResizeForm();
            HandleCreated += (sender, args) =>
            {
                if (Text == GetType().Name) Text = Resources.System_Name;
                labelTitle.Text = Text;
                Icon = Resources.IconSapiensia;

                toolTip.Translate();
            };
            Resize += (sender, args) =>
            {
                buttonResize.Left = Width - buttonResize.Width;
                buttonResize.Top = Height - buttonResize.Height + 1;
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
    }
}