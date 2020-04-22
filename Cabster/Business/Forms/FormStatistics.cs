using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Cabster.Business.Entities;
using Cabster.Business.Messenger.Request;
using Cabster.Business.Values;
using Cabster.Components;
using Cabster.Properties;

namespace Cabster.Business.Forms
{
    /// <summary>
    ///     Janela de configuração
    /// </summary>
    public partial class FormStatistics : FormLayout, IFormContainerData
    {
        /// <summary>
        ///     Construtor.
        /// </summary>
        public FormStatistics()
        {
            InitializeComponent();
            InitializeComponent2();
        }

        /// <summary>
        ///     Notifica a atualização dos controles da tela.
        /// </summary>
        /// <param name="data">Dados da aplicação.</param>
        public void UpdateControls(ContainerData? data = null)
        {
            data ??= Program.Data;
            
            Invoke((Action) (() =>
            {
                var history = data.GroupWork.History;
                var roundsWork = history.Where(a => !a.IsBreak).ToArray();
                var timeWork = roundsWork.Sum(a => (int) a.TimeElapsed.TotalSeconds);
                var roundsBreak = history.Where(a => a.IsBreak).ToArray();
                var timeBreak = roundsBreak.Sum(a => (int) a.TimeElapsed.TotalSeconds);

                static string FormatTime(int totalMinutes)
                {
                    var hour = totalMinutes / 60;
                    var minutes = totalMinutes % 60;
                    return $"{hour:00}:{minutes:00}";
                }
                
                labelStartValue.Text = history.Last().Started.ToLocalTime().ToString("g");
                labelRoundWorkValue.Text = roundsWork.Length.ToString();
                labelTimeWorkValue.Text = FormatTime(timeWork);
                labelRoundBreakValue.Text = roundsBreak.Length.ToString();
                labelTimeBreakValue.Text = FormatTime(timeBreak);
            }));
        }

        /// <summary>
        ///     Inicializa controles.
        /// </summary>
        private void InitializeComponent2()
        {
            Shown += (sender, args) =>
            {
                UpdateControls();
            };
        }
    }
}