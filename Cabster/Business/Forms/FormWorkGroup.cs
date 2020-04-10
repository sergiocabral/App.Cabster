﻿using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
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
        ///     Ao adicionar participante.
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
                    participant = ParticipantInfo.CreateControl(newParticipant);
                    panelParticipants.Controls.Add(participant);
                }
            }
            finally
            {
                textBoxAddParticipant.Text = string.Empty;
            }
        }

        /// <summary>
        ///     Evento ao pressionar uma tecla.
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

        /// <summary>
        ///     Informações sobre o participant.
        /// </summary>
        private class ParticipantInfo
        {
            /// <summary>
            ///     Cor para para participante ativo.
            /// </summary>
            private static readonly Color ColorForActive = Color.FromArgb(250, 180, 20);

            /// <summary>
            ///     Cor para para participante inativo.
            /// </summary>
            private static readonly Color ColorForInactive = Color.FromArgb(127, 127, 127);

            /// <summary>
            ///     Controle.
            /// </summary>
            private readonly MyButton _control;

            /// <summary>
            ///     Sinaliza ativo ou desativo.
            /// </summary>
            private bool _active = true;

            /// <summary>
            ///     Última posição do controle;
            /// </summary>
            private Point _lastPosition;

            /// <summary>
            ///     Construtor.
            /// </summary>
            /// <param name="control">Controle.</param>
            private ParticipantInfo(MyButton control)
            {
                _control = control;
                control.Click += ControlOnClick;
                control.MouseDown += ControlOnMouseDown;
                control.MouseUp += ControlOnMouseUp;
            }

            /// <summary>
            ///     Sinaliza ativo ou desativo.
            /// </summary>
            private bool Active
            {
                get => _active;
                set
                {
                    _active = value;
                    _control.BackColor = _active ? ColorForActive : ColorForInactive;
                    _control.UpdateLayout();
                }
            }

            /// <summary>
            ///     Remove o participant.
            /// </summary>
            private void Remove()
            {
                _control.Parent.Controls.Remove(_control);
                _control.Tag = null;
                _control.Dispose();
            }

            /// <summary>
            ///     Cria um botão para um novo participante.
            /// </summary>
            /// <returns>Controle</returns>
            public static MyButton CreateControl(string name)
            {
                var participant = new MyButton
                {
                    Text = name.Trim(),
                    ForeColor = Color.Black,
                    BackColor = ColorForActive
                };
                participant.Tag = new ParticipantInfo(participant);
                return participant;
            }

            /// <summary>
            ///     Quando pressiona o botão do mouse.
            /// </summary>
            /// <param name="sender">Fonte do evento.</param>
            /// <param name="args">Dados do evento.</param>
            private void ControlOnMouseDown(object sender, MouseEventArgs args)
            {
                _lastPosition = new Point(_control.Left, _control.Top);
            }

            /// <summary>
            ///     Quando solta o botão do mouse.
            /// </summary>
            /// <param name="sender">Fonte do evento.</param>
            /// <param name="args">Dados do evento.</param>
            private void ControlOnMouseUp(object sender, MouseEventArgs args)
            {
                if (args.Button != MouseButtons.Right) return;
                var currentPosition = new Point(_control.Left, _control.Top);
                if (_lastPosition != currentPosition) return;
                Remove();
            }

            /// <summary>
            ///     Quando clica em um botão de participante.
            /// </summary>
            /// <param name="sender">Fonte do evento.</param>
            /// <param name="args">Dados do evento.</param>
            private void ControlOnClick(object sender, EventArgs args)
            {
                var currentPosition = new Point(_control.Left, _control.Top);
                if (_lastPosition != currentPosition) return;
                Active = !Active;
            }
        }
    }
}