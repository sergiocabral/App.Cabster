using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Cabrones.Utils.Text;
using Cabster.Business.Entities;
using Cabster.Business.Enums;
using Cabster.Business.Messenger.Request;
using Cabster.Components;
using Cabster.Properties;
using Serilog;

#pragma warning disable 109

namespace Cabster.Business.Forms
{
    /// <summary>
    ///     Janela de trabalho em grupo.
    /// </summary>
    public partial class FormGroupWork : FormLayout
    {
        /// <summary>
        ///     Sinaliza que a janela já foi carregada.
        /// </summary>
        private bool _loaded;

        /// <summary>
        ///     Construtor.
        /// </summary>
        public FormGroupWork()
        {
            InitializeComponent();
            InitializeComponent2();
        }

        /// <summary>
        ///     Tempos.
        /// </summary>
        private GroupWorkTimesSet Times
        {
            get => new GroupWorkTimesSet
            {
                TimeToWork = (int) numericUpDownDurationOfEachRound.Value,
                TimeToBreak = (int) numericUpDownDurationOfEachBreak.Value,
                RoundsUpToBreak = (int) numericUpDownBreakStartsAfterHowManyRounds.Value
            };
            set
            {
                numericUpDownDurationOfEachRound.Value = value.TimeToWork;
                numericUpDownDurationOfEachBreak.Value = value.TimeToBreak;
                numericUpDownBreakStartsAfterHowManyRounds.Value = value.RoundsUpToBreak;
            }
        }

        /// <summary>
        ///     Lista de participantes.
        /// </summary>
        private IEnumerable<GroupWorkParticipantSet> Participants
        {
            get
            {
                var index = 0;
                return panelParticipants
                    .ControlsSorted
                    .Select(myButton => new GroupWorkParticipantSet
                    {
                        Name = ((ParticipantInfo) myButton.Tag).Name,
                        Active = ((ParticipantInfo) myButton.Tag).Active,
                        IsDriver = ++index == 1,
                        IsNavigator = index == 2
                    });
            }
            set
            {
                foreach (var myButton in panelParticipants.Controls.OfType<MyButton>())
                {
                    var participantInfo = (ParticipantInfo) myButton.Tag;
                    participantInfo.Remove();
                }

                foreach (var participantSet in value)
                    panelParticipants.Controls.Add(
                        ParticipantInfo.CreateControl(this, SaveParticipants, participantSet.Name,
                            participantSet.Active));
            }
        }

        /// <summary>
        ///     Inicializa os componentes da janela.
        /// </summary>
        [ExcludeFromCodeCoverage]
        private void InitializeComponent2()
        {
            ShowLogo = true;
            Load += numericUpDownTimes_Change;
            ButtonCloseClick += OnButtonCloseClick;
            panelParticipants.ControlAdded += PanelParticipantsOnControlAddedOrRemoved;
            panelParticipants.ControlRemoved += PanelParticipantsOnControlAddedOrRemoved;
            panelParticipants.OrderChanged += PanelParticipantsOnOrderChanged;
            PanelParticipantsOnControlAddedOrRemoved(panelParticipants, null);
            VisibleChanged += OnVisibleChanged;

            var minScreen = Screen.AllScreens.First(a =>
                a.Bounds.Width == Screen.AllScreens.Min(b => b.Bounds.Width));
            Width = (int) (minScreen.Bounds.Width * 0.8);
            Height = (int) (minScreen.Bounds.Height * 0.8);

            var currentScreen = Screen.FromControl(this);
            Left = currentScreen.Bounds.Left + (currentScreen.Bounds.Width - Width) / 2;
            Top = currentScreen.Bounds.Top + (currentScreen.Bounds.Height - Height) / 2;

            Shown += (sender, args) =>
            {
                LoadData();
                buttonStart.Focus();

                _loaded = true;
            };

            labelTips.Text = string.Empty;
        }

        /// <summary>
        /// Evento quando a ordem dos nomes é alterada.
        /// </summary>
        private void PanelParticipantsOnOrderChanged()
        {
            SaveParticipants();
        }

        /// <summary>
        ///     Carrega os dados da aplicação.
        /// </summary>
        public void LoadData()
        {
            var data = Program.Data;
            Participants = data.GroupWork.Participants;
            Times = data.GroupWork.Times;
        }

        /// <summary>
        ///     Quando a janela é exibida ou escondida.
        /// </summary>
        /// <param name="sender">Fonte do evento.</param>
        /// <param name="args">Dados do evento.</param>
        private void OnVisibleChanged(object sender, EventArgs args)
        {
            if (Visible) LoadTip();
        }

        /// <summary>
        ///     Evento ao atualizar controles dos participantes.
        /// </summary>
        /// <param name="sender">Fonte do evento.</param>
        /// <param name="args">Dados do evento.</param>
        private void PanelParticipantsOnControlAddedOrRemoved(object sender, ControlEventArgs? args)
        {
            buttonParticipantSort.Visible = panelParticipants.Controls.Count > 1;
            SaveParticipants();
        }

        /// <summary>
        ///     Grava os participants.
        /// </summary>
        private void SaveParticipants()
        {
            if (!_loaded) return;
            timerToSaveParticipants.Enabled = false;
            timerToSaveParticipants.Enabled = true;
            _pendingToSave |= DataSection.WorkGroupParticipants;
        }

        /// <summary>
        /// Dados pendentes de gravação.
        /// </summary>
        private DataSection _pendingToSave;

        /// <summary>
        ///     Grava os tempos.
        /// </summary>
        private void SaveTimes()
        {
            if (!_loaded) return;
            timerToSaveTimes.Enabled = false;
            timerToSaveTimes.Enabled = true;
            _pendingToSave |= DataSection.WorkGroupTimes;
        }

        /// <summary>
        ///     Timer para gravar os dados dos participantes.
        /// </summary>
        /// <param name="sender">Fonte do evento.</param>
        /// <param name="args">Dados do evento.</param>
        private void timerToSaveParticipants_Tick(object sender, EventArgs args)
        {
            ((Timer) sender).Enabled = false;
            var data = Program.Data;
            data.GroupWork.Participants = Participants.ToList();
            MessageBus.Send(new DataUpdate(data, DataSection.WorkGroupParticipants));
            _pendingToSave ^= DataSection.WorkGroupParticipants;
        }

        /// <summary>
        ///     Timer para gravar os dados dos participantes.
        /// </summary>
        /// <param name="sender">Fonte do evento.</param>
        /// <param name="args">Dados do evento.</param>
        private void timerToSaveTimes_Tick(object sender, EventArgs args)
        {
            ((Timer) sender).Enabled = false;
            var data = Program.Data;
            data.GroupWork.Times = Times;
            MessageBus.Send(new DataUpdate(data, DataSection.WorkGroupTimes));
            _pendingToSave ^= DataSection.WorkGroupTimes;
        }

        /// <summary>
        ///     Quando clica o botão de fechar a janela.
        /// </summary>
        private async void OnButtonCloseClick()
        {
            if (_pendingToSave != 0)
            {
                var data = Program.Data;
                data.GroupWork.Times = Times;
                data.GroupWork.Participants = Participants.ToList();
                await MessageBus.Send(new DataUpdate(data, DataSection.WorkGroup));
            }

            await MessageBus.Send(new ApplicationFinalize());
        }

        /// <summary>
        ///     Evento para atualiza a exibição dos controles.
        /// </summary>
        /// <param name="sender">Fonte do evento.</param>
        /// <param name="args">Dados do evento.</param>
        private void numericUpDownTimes_Change(object sender, EventArgs args)
        {
            if (labelBreakStartsAfterHowManyRounds_Part2.Tag == null)
                labelBreakStartsAfterHowManyRounds_Part2.Tag = labelBreakStartsAfterHowManyRounds_Part2.Text;

            var textTemplate = (string) labelBreakStartsAfterHowManyRounds_Part2.Tag;
            var minutes = (int)
                (numericUpDownBreakStartsAfterHowManyRounds.Value * numericUpDownDurationOfEachRound.Value);

            labelBreakStartsAfterHowManyRounds_Part2.Text = textTemplate.QueryString(minutes);

            SaveTimes();
        }

        /// <summary>
        ///     Ao adicionar participante.
        /// </summary>
        /// <param name="sender">Fonte do evento.</param>
        /// <param name="args">Dados do evento.</param>
        private void buttonParticipantAdd_Click(object sender, EventArgs args)
        {
            try
            {
                var participantName = textBoxAddParticipant.Text;
                if (string.IsNullOrWhiteSpace(participantName))
                {
                    SetStatusMessage(Resources.Text_GroupWork_ParticipantNameEmpty, false);
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
                    participant = ParticipantInfo.CreateControl(this, SaveParticipants, participantName);
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
            buttonParticipantAdd.Focus();
            buttonParticipantAdd.PerformClick();
            ((Control) sender).Focus();
        }

        /// <summary>
        ///     Evento de clique no botão de sortear participantes.
        /// </summary>
        /// <param name="sender">Fonte do evento.</param>
        /// <param name="args">Dados do evento.</param>
        private void buttonParticipantSort_Click(object sender, EventArgs args)
        {
            panelParticipants.Sort();
        }

        /// <summary>
        ///     Evento ao clicar duas vezes na frase de dica.
        /// </summary>
        /// <param name="sender">Fonte do evento.</param>
        /// <param name="args">Dados do evento.</param>
        private void labelTips_Click(object sender, EventArgs args)
        {
            SetStatusMessage(Resources.Text_GroupWork_TipsLoading);
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
        ///     Evento: botão começar.
        /// </summary>
        /// <param name="sender">Fonte do evento.</param>
        /// <param name="args">Dados do evento.</param>
        private void buttonStart_Click(object sender, EventArgs args)
        {
            Log.Information("Resposta: {value}", FormDialogConfirm.Show("Teste de mensagem."));
        }

        /// <summary>
        ///     Evento: botão configurações.
        /// </summary>
        /// <param name="sender">Fonte do evento.</param>
        /// <param name="args">Dados do evento.</param>
        private void buttonConfiguration_Click(object sender, EventArgs args)
        {
            MessageBus.Send(new WindowOpenConfiguration());
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
            ///     Esta janela.
            /// </summary>
            private readonly FormGroupWork _form;

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
            private ParticipantInfo(FormGroupWork form, MyButton control)
            {
                _form = form;
                _control = control;
                control.Click += ControlOnClick;
                control.MouseDown += ControlOnMouseDown;
                control.MouseUp += ControlOnMouseUp;
                UpdateToolTip();
            }

            /// <summary>
            ///     Nome do participante.
            /// </summary>
            public string Name
            {
                get => _control.Text;
                set
                {
                    _control.Text = value.Trim();
                    _control.UpdateSizeToText();
                    Updated?.Invoke();
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
                    Updated?.Invoke();
                }
            }

            /// <summary>
            ///     Evento disparado quando ocorre alguma alteração.
            /// </summary>
            public event Action? Updated;

            /// <summary>
            ///     Atualiza o ToolTip do controle.
            /// </summary>
            private void UpdateToolTip()
            {
                _form.toolTip.SetToolTip(
                    _control,
                    Resources.Text_GroupWork_ParticipantRemoveHint
                        .QueryString(
                            Active
                                ? Resources.Text_Common_Active.ToUpper()
                                : Resources.Text_Common_Inactive.ToUpper()));
            }

            /// <summary>
            ///     Remove o participant.
            /// </summary>
            public void Remove()
            {
                _control.Parent.Controls.Remove(_control);
                _control.Tag = null;
                _control.Dispose();
            }

            /// <summary>
            ///     Cria um botão para um novo participante.
            /// </summary>
            /// <param name="form">Esta janela.</param>
            /// <param name="onUpdate">Evento quando o participante é alterado.</param>
            /// <param name="name">Nome do participante.</param>
            /// <param name="active">Ativo ou não.</param>
            /// <returns>Controle</returns>
            public static MyButton CreateControl(FormGroupWork form, Action onUpdate, string name, bool active = true)
            {
                var control = new MyButton
                {
                    Text = name.Trim(),
                    ForeColor = Color.Black,
                    BackColor = ColorForActive,
                    AutoSize = true
                };
                control.Font = new Font(control.Font.FontFamily, 20);
                var info = new ParticipantInfo(form, control) {Active = active};
                info.Updated += onUpdate;
                control.Tag = info;
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