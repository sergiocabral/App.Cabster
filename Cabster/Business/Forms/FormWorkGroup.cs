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
using Cabster.Extensions;
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
            // Controle sendo arrastado.
            var target = (Control) sender;

            // Control que contem todos os outros. 
            var container = target.Parent;

            // Lista de todos os outros controles em ordem.
            var controls = container
                .Controls
                .OfType<Control>()
                .Except(new[] {target})
                .GroupBy(control => control.Top)
                .OrderBy(line => line.Key)
                .SelectMany(line => line
                    .OrderBy(control => control.Left))
                .ToList();

            // Lista dos controles em posição acima.
            var sameLineControls = controls
                .Where(control => control.Bottom >= target.Top && control.Top <= target.Bottom)
                .ToList();

            // O Controle não caiu em cima de nenhum outro.
            if (sameLineControls.Count == 0)
            {
                // Se a lista era vazia, adiciona nela.
                if (controls.Count == 0) controls.Add(target);

                // Se caiu acima do topo é o primeiro.
                else if (controls[0].Top > target.Top) controls.Insert(0, target);

                // Então caiu no final.
                else controls.Add(target);
            }

            // O controle caiu em cima de alguns outros.
            else
            {
                var next = sameLineControls
                    // Agrupa por linha.
                    .GroupBy(control => control.Top + control.Height / 2)

                    // Ordena as linhas pela mais próxima primeira.
                    .OrderBy(group => Math.Abs(target.Top + target.Height / 2 - group.Key))

                    // Seleciona a primeira linha que é a mais próxima do controle alvo.
                    .First()

                    // Seleciona o primeiro control depois do control alvo.
                    .FirstOrDefault(control => control.Left > target.Left);

                controls.Insert(
                    next != null

                        // Insere na lista no lugar do controle encontrado.
                        ? controls.IndexOf(next)

                        // Se não encontrar fica na última posição
                        : controls.IndexOf(sameLineControls.Last()) + 1,
                    target);
            }

            flowLayoutPanel1.OrganizeChildren(control => controls.IndexOf(control));
            target.MakeHighlight();
        }

        /// <summary>
        ///     Quando clica o botão de fechar a janela.
        /// </summary>
        private void OnButtonCloseClick()
        {
            MessengerBus.Send(new FinalizeApplication());
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
    }
}