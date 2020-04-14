using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Cabster.Business.Entities;
using Cabster.Business.Enums;
using Cabster.Business.Messenger.Request;
using Cabster.Components;
using Cabster.Properties;
using Serilog;
using Label = System.Windows.Forms.Label;
using Panel = System.Windows.Forms.Panel;

namespace Cabster.Business.Forms
{
    /// <summary>
    ///     Janela de configuração
    /// </summary>
    public partial class FormNotification : FormLayout, IFormContainerData
    {
        /// <summary>
        ///     Construtor.
        /// </summary>
        public FormNotification()
        {
            InitializeComponent();
            InitializeComponent2();
        }
        
        /// <summary>
        /// Filtro da consulta de mensagens.
        /// </summary>
        private DateTimeOffset _lastFilter = DateTimeOffset.MinValue;

        /// <summary>
        ///     Inicializa controles.
        /// </summary>
        private void InitializeComponent2()
        {
            HandleCreated += (sender, args) => HideStatusBar = true;
            Resize += (sender, args) =>
            {
                panelMessages.Width = Width - (panelMessages.Left * 2);
                panelMessages.Height = Height - (panelMessages.Top + panelMessages.Left);
                foreach (Control control in panelMessages.Controls) AdjustSize(control);
            };
            Load += (sender, args) => UpdateControls();
        }

        /// <summary>
        /// Adiciona uma mensagem na janela.
        /// </summary>
        /// <param name="message">Mensagem.</param>
        private void AddMessage(NotificationMessage message)
        {
            var panel = new Panel
            {
                Height = 10,
                Dock = DockStyle.Top
            };
            var label = new Label
            {
                BackColor = Color.Transparent,
                ForeColor = message.Success ? Color.RoyalBlue : Color.Brown,
                Text = message.ToString(),
                Dock = DockStyle.Top,
                AutoSize = true
            };
            panelMessages.Controls.Add(panel);
            panelMessages.Controls.Add(label);
            AdjustSize(panel).SendToBack();
            AdjustSize(label).SendToBack();
        }

        /// <summary>
        /// Ajusta otamanho dos controles.
        /// </summary>
        /// <param name="control">Controle</param>
        /// <returns>Mesma instância de entrada.</returns>
        private Control AdjustSize(Control control)
        {
            if (control is Label label) label.MaximumSize = new Size(label.Parent.Width, 0);
            return control;
        }

        /// <summary>
        /// Notifica a atualização dos controles da tela.
        /// </summary>
        public async void UpdateControls()
        {
            var messages = await MessageBus.Send<IEnumerable<NotificationMessage>>(
                new UserNotificationRequestList(_lastFilter));
            
            foreach (var message in messages)
            {
                AddMessage(message);
                if (_lastFilter < message.Time) _lastFilter = message.Time;
            }
        }
    }
}