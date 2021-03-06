﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using Cabster.Business.Entities;
using Cabster.Business.Messenger.Request;
using Cabster.Components;
using Cabster.Exceptions;
using Color = Cabster.Business.Values.Color;

namespace Cabster.Business.Forms
{
    /// <summary>
    ///     Janela de configuração
    /// </summary>
    public partial class FormNotification : FormLayout, IFormContainerData
    {
        /// <summary>
        ///     Filtro da consulta de mensagens.
        /// </summary>
        private DateTimeOffset _lastFilter = DateTimeOffset.MinValue;

        /// <summary>
        ///     Construtor.
        /// </summary>
        public FormNotification()
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
            Invoke((Action) (async () =>
            {
                if (data != null) throw new ThisWillNeverOccurException();

                var messages = await MessageBus.Send<IEnumerable<NotificationMessage>>(
                    new UserNotificationRequestList(_lastFilter));

                foreach (var message in messages)
                {
                    AddMessage(message);
                    if (_lastFilter < message.Time) _lastFilter = message.Time;
                }
            }));
        }

        /// <summary>
        ///     Inicializa controles.
        /// </summary>
        private void InitializeComponent2()
        {
            panelMessages
                .GetType()
                .GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic)?
                .SetValue(panelMessages, true);
            panelMessages.Width = Width - panelMessages.Left * 2;
            panelMessages.Height = Height - (panelMessages.Top + panelMessages.Left);

            HandleCreated += (sender, args) => HideStatusBar = true;
            Resize += (sender, args) =>
            {
                foreach (Label label in panelMessages.Controls) AdjustLabelSize(label);
            };
            Load += (sender, args) => UpdateControls();
        }

        /// <summary>
        ///     Adiciona uma mensagem na janela.
        /// </summary>
        /// <param name="message">Mensagem.</param>
        private void AddMessage(NotificationMessage message)
        {
            var label = new Label
            {
                ForeColor = message.Success ? Color.NotificationSuccess : Color.NotificationError,
                Text = message + Environment.NewLine + ' ',
                Dock = DockStyle.Top
            };
            if (labelNoNotification.Visible) labelNoNotification.Visible = false;
            panelMessages.Controls.Add(label);
            AdjustLabelSize(label).SendToBack();
        }

        /// <summary>
        ///     Ajusta o tamanho dos controles.
        /// </summary>
        /// <param name="label">Label</param>
        /// <returns>Mesma instância de entrada.</returns>
        private static Label AdjustLabelSize(Label label)
        {
            label.AutoSize = true;
            label.MaximumSize = new Size(label.Parent.Width, 0);
            return label;
        }
    }
}