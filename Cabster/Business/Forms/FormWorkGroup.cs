using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cabrones.Utils.Text;
using Cabster.Business.Messenger.Notification;
using Cabster.Business.Messenger.Request;
using Cabster.Components;
using MediatR;

#pragma warning disable 109

namespace Cabster.Business.Forms
{
    /// <summary>
    ///     Janela de trabalho em grupo.
    /// </summary>
    public partial class FormWorkGroup :
        FormLayout,
        INotificationHandler<ApplicationInitialized>
    {
        /// <summary>
        ///     Construtor.
        /// </summary>
        public FormWorkGroup()
        {
            InitializeComponent();
            InitializeComponent2();
        }

        /// <summary>
        ///     Processa o evento: ApplicationInitialized
        /// </summary>
        /// <param name="notification">Evento.</param>
        /// <param name="cancellationToken">Token.</param>
        /// <returns>Task</returns>
        public new Task Handle(ApplicationInitialized notification, CancellationToken cancellationToken)
        {
            Show();
            return Unit.Task;
        }

        /// <summary>
        ///     Inicializa os componentes da janela.
        /// </summary>
        [ExcludeFromCodeCoverage]
        private void InitializeComponent2()
        {
            Load += UpdateControls;
            ButtonCloseClick += OnButtonCloseClick;
        }

        /// <summary>
        ///     Quando clica o botão de fechar a janela.
        /// </summary>
        private void OnButtonCloseClick()
        {
            MessageBus.Send(new FinalizeApplication());
        }

        /// <summary>
        ///     Evento para atualiza a exibição dos controles.
        /// </summary>
        /// <param name="sender">Fonte do evento.</param>
        /// <param name="args">Dados do evento.</param>
        private void UpdateControls(object sender, EventArgs args)
        {
            if (labelBreakStartsAfterHowManyRounds_Part2.Tag == null)
                labelBreakStartsAfterHowManyRounds_Part2.Tag = labelBreakStartsAfterHowManyRounds_Part2.Text;

            var textTemplate = (string) labelBreakStartsAfterHowManyRounds_Part2.Tag;
            var minutes = (int)
                (numericUpDownBreakStartsAfterHowManyRounds.Value * numericUpDownDurationOfEachRound.Value);

            labelBreakStartsAfterHowManyRounds_Part2.Text = textTemplate.QueryString(minutes);
        }

        /// <summary>
        /// Ao adicionar participante.
        /// </summary>
        /// <param name="sender">Fonte do evento.</param>
        /// <param name="args">Dados do evento.</param>
        private void buttonAddParticipant_Click(object sender, EventArgs args)
        {
            try
            {
                var newParticipant = textBoxAddParticipant.Text;
                if (string.IsNullOrWhiteSpace(newParticipant)) return;

                var currentParticipants = panelParticipants.Controls.OfType<MyButton>();

                var participant = currentParticipants.SingleOrDefault(c =>
                    string.Equals(c.Text.Trim(), newParticipant.Trim(), StringComparison.CurrentCultureIgnoreCase));

                if (participant != null)
                {

                }
                else
                {
                    participant = new MyButton
                    {
                        Text = newParticipant.Trim(),
                    };
                    panelParticipants.Controls.Add(participant);
                }
            }
            finally
            {
                textBoxAddParticipant.Text = string.Empty;
            }
        }

        /// <summary>
        /// Evento ao pressionar uma tecla.
        /// </summary>
        /// <param name="sender">Fonte do evento.</param>
        /// <param name="args">Dados do evento.</param>
        private void textBoxAddParticipant_KeyUp(object sender, KeyEventArgs args)
        {
            if (args.KeyCode != Keys.Enter) return;
            buttonAddParticipant.Focus();
            buttonAddParticipant.PerformClick();
            ((Control) sender).Focus();
        }
    }
}