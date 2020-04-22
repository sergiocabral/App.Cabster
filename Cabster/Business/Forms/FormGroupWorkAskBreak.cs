using System;
using Cabster.Business.Messenger.Request;
using Cabster.Components;
using Cabster.Properties;

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
            InitializeComponent2();
        }

        /// <summary>
        /// Inicializa os controles.
        /// </summary>
        private void InitializeComponent2()
        {
            ShowButtonMinimize = false;
            ShowButtonClose = false;
            VisibleChanged += (sender, args) =>
            {
                if (Visible) LoadTip();
            };

            labelTips.Text = string.Empty;
        }

        /// <summary>
        ///     Texto de dicas aleatórias.
        /// </summary>
        private static ITips Tips => Program.DependencyResolver.GetInstanceRequired<ITips>();

        /// <summary>
        ///     Evento ao clicar duas vezes na frase de dica.
        /// </summary>
        /// <param name="sender">Fonte do evento.</param>
        /// <param name="args">Dados do evento.</param>
        private void labelTips_Click(object sender, EventArgs args)
        {
            SetStatusMessage(Resources.Window_GroupWork_TipsLoading);
            LoadTip();
        }

        /// <summary>
        ///     Carrega uma frase de dicas.
        /// </summary>
        private async void LoadTip()
        {
            var tip = await Tips.Get();
            labelTips.Invoke(new Action(() => labelTips.Text = tip));
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