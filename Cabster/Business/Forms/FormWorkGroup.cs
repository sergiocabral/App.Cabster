using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cabrones.Utils.Text;
using Cabster.Business.Messenger.Notification;
using Cabster.Business.Messenger.Request;
using Cabster.Components;
using Cabster.Exceptions;
using Cabster.Extensions;
using MediatR;
using Serilog;

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

            var random = new Random();
            foreach (Control control in flowLayoutPanel1.Controls)
            {
                control.MakeAbleToMoveWithMouse();
                control.MouseUp += ControlOnMouseUp;
                control.Text = Guid.NewGuid().ToString().Substring(0, random.Next(30) + 6);
            }
            myButton.Click += (sender, args) => flowLayoutPanel1.OrganizeChildren();
            myButton.UpdateSizeToText();  
        }

        private void ControlOnMouseUp(object sender, MouseEventArgs e)
        {
            ((Control)sender).SendToBack();
            var i = 0;
            flowLayoutPanel1.OrganizeChildren(control =>
            {
                return i++;
            });
        }

        /// <summary>
        ///     Quando clica o botão de fechar a janela.
        /// </summary>
        private void OnButtonCloseClick()
        {
            MessengerBus.Send(new FinalizeApplication());
        }

        /// <summary>
        /// Evento para atualiza a exibição dos controles.
        /// </summary>
        /// <param name="sender">Fonte do evento.</param>
        /// <param name="args">Dados do evento.</param>
        private void UpdateControls(object sender, System.EventArgs args)
        {
            if (labelBreakStartsAfterHowManyRounds_Part2.Tag == null)
            {
                labelBreakStartsAfterHowManyRounds_Part2.Tag = labelBreakStartsAfterHowManyRounds_Part2.Text;
            }

            var textTemplate = (string) labelBreakStartsAfterHowManyRounds_Part2.Tag;
            var minutes = (int) 
                (numericUpDownBreakStartsAfterHowManyRounds.Value * numericUpDownDurationOfEachRound.Value);

            labelBreakStartsAfterHowManyRounds_Part2.Text = textTemplate.QueryString(minutes);
        }
    }
}