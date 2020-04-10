using System;
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
using Cabster.Properties;
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
                var participantName = textBoxAddParticipant.Text;
                if (string.IsNullOrWhiteSpace(participantName))
                {
                    SetStatusMessage(Resources.Text_WorkGroup_ParticipantNameEmpty, false);
                    return;
                }

                var currentParticipants = panelParticipants.Controls.OfType<MyButton>();

                var participant = currentParticipants.SingleOrDefault(c =>
                    string.Equals(c.Text.Trim(), participantName.Trim(), StringComparison.CurrentCultureIgnoreCase));

                if (participant != null)
                {
                    var info = (ParticipantInfo) participant.Tag;
                    info.Name = participantName;
                    info.Active = true;
                }
                else
                {
                    participant = ParticipantInfo.CreateControl(this, participantName);
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
            /// Esta janela.
            /// </summary>
            private readonly FormWorkGroup _form;

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
            /// <param name="form">Esta janela.</param>
            /// <param name="control">Controle.</param>
            private ParticipantInfo(FormWorkGroup form, MyButton control)
            {
                _form = form;
                _control = control;
                control.Click += ControlOnClick;
                control.MouseDown += ControlOnMouseDown;
                control.MouseUp += ControlOnMouseUp;
                UpdateToolTip();
            }

            /// <summary>
            /// Atualiza o ToolTip do controle.
            /// </summary>
            private void UpdateToolTip()
            {
                _form.toolTip.SetToolTip(
                    _control,
                    Resources.Text_WorkGroup_ParticipantRemoveHint
                        .QueryString(
                            Active
                                ? Resources.Text_Common_Active.ToUpper()
                                : Resources.Text_Common_Inactive.ToUpper()));
            }

            /// <summary>
            /// Nome do participante.
            /// </summary>
            public string Name
            {
                get => _control.Text;
                set
                {
                    _control.Text = value.Trim(); 
                    _control.UpdateSizeToText();
                }
            }

            /// <summary>
            ///     Sinaliza ativo ou desativo.
            /// </summary>
            public bool Active
            {
                get => _active;
                set
                {
                    _active = value;
                    _control.BackColor = _active ? ColorForActive : ColorForInactive;
                    _control.UpdateLayout();
                    UpdateToolTip();
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
            /// <param name="form">Esta janela.</param>
            /// <param name="name">Nome do participante.</param>
            /// <returns>Controle</returns>
            public static MyButton CreateControl(FormWorkGroup form, string name)
            {
                var control = new MyButton
                {
                    Text = name.Trim(),
                    ForeColor = Color.Black,
                    BackColor = ColorForActive
                };
                control.Tag = new ParticipantInfo(form, control);;
                return control;
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