using System;
using System.Threading.Tasks;
using Cabster.Business.Messenger.Request;
using Cabster.Extensions;
using Serilog;

namespace Cabster.Components
{
    /// <summary>
    ///     Janela principal da aplicação.
    /// </summary>
    public partial class FormMain : FormBase
    {
        /// <summary>
        ///     Construtor.
        /// </summary>
        public FormMain()
        {
            InitializeComponent();
            InitializeComponent2();
        }

        /// <summary>
        ///     Inicializa os componentes da janela.
        /// </summary>
        private void InitializeComponent2()
        {
            notifyIcon.TranslateComponent();
            this.MakeInvisible();
        }

        /// <summary>
        /// Evento ao clicar duas vezes no ícone da aplicação.
        /// </summary>
        /// <param name="sender">Fonte do evento.</param>
        /// <param name="args">Informações do evento.</param>
        private void notifyIcon_DoubleClick(object sender, EventArgs args)
        {
            MessageBus.Send(new UserActionPoke());
        }
    }
}