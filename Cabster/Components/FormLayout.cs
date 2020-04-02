using System;
using System.Diagnostics.CodeAnalysis;
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
    }
}