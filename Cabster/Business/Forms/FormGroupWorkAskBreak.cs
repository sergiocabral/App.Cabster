using Cabster.Business.Messenger.Request;
using Cabster.Components;

#pragma warning disable 109

namespace Cabster.Business.Forms
{
    /// <summary>
    ///     Janela de trabalho em grupo.
    /// </summary>
    public partial class FormGroupWorkAskBreak : FormLayout
    {
        /// <summary>
        ///     Construtor.
        /// </summary>
        public FormGroupWorkAskBreak()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Evento ao clicar no botão para ignorar o intervalo.
        /// </summary>
        /// <param name="sender">Fonte do evento.</param>
        /// <param name="args">Informações sobre o evento.</param>
        private void buttonSkip_Click(object sender, System.EventArgs args)
        {
            MessageBus.Send(new UserActionGroupWorkBreakResponse(false));
        }

        /// <summary>
        /// Evento ao clicar no botão para aceitar fazer um intervalo.
        /// </summary>
        /// <param name="sender">Fonte do evento.</param>
        /// <param name="args">Informações sobre o evento.</param>
        private void buttonAccept_Click(object sender, System.EventArgs args)
        {
            MessageBus.Send(new UserActionGroupWorkBreakResponse(true));
        }
    }
}