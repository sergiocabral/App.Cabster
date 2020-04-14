﻿using System.Windows.Forms;
using Cabster.Extensions;
using Cabster.Infrastructure;
using Cabster.Properties;
using MediatR;

// ReSharper disable VirtualMemberCallInConstructor

namespace Cabster.Components
{
    /// <summary>
    ///     Form base do sistema.
    /// </summary>
    public partial class FormBase : Form
    {
        /// <summary>
        ///     Barramento de mensagens.
        /// </summary>
        private IMediator? _messageBus;

        /// <summary>
        ///     Construtor.
        /// </summary>
        public FormBase()
        {
            this.LogClassInstantiate();

            InitializeComponent();
            InitializeComponent2();
        }

        /// <summary>
        ///     Barramento de mensagens.
        /// </summary>
        protected IMediator MessageBus =>
            _messageBus ??= Program.DependencyResolver.GetInstanceRequired<IMediator>();

        /// <summary>
        ///     Atributos para criação da janela.
        ///     Necessário para esconder a janela da barra de tarefas quando ShowInTaskbar=False .
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                var createParams = base.CreateParams;
                if (!ShowInTaskbar) createParams.ExStyle |= 0x80 /* WS_EX_TOOLWINDOW */;
                if (!Environment.IsDesign) createParams.ExStyle |= 0x02000000 /* WS_EX_COMPOSITED */;
                return createParams;
            }
        }

        /// <summary>
        ///     Inicializa os componentes da janela.
        /// </summary>
        private void InitializeComponent2()
        {
            HandleCreated += (sender, args) => this.Translate();
            Load += (sender, args) =>
            {
                if (Text == GetType().Name ||
                    Text == typeof(FormLayout).Name ||
                    Text == typeof(FormBase).Name) Text = Resources.Name_Application;
            };
        }
    }
}