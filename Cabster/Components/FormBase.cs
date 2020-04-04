using System.Windows.Forms;
using Cabster.Extensions;
using Merq;

// ReSharper disable VirtualMemberCallInConstructor

namespace Cabster.Components
{
    /// <summary>
    ///     Form base do sistema.
    /// </summary>
    public partial class FormBase : Form
    {
        /// <summary>
        ///     ICommandBus.
        /// </summary>
        private ICommandBus? _commandBus;

        /// <summary>
        ///     IEventStream.
        /// </summary>
        private IEventStream? _eventStream;

        /// <summary>
        ///     Construtor.
        /// </summary>
        public FormBase()
        {
            InitializeComponent();
            InitializeComponent2();
        }

        /// <summary>
        ///     ICommandBus.
        /// </summary>
        protected ICommandBus CommandBus =>
            _commandBus ??= Program.DependencyResolver.GetInstanceRequired<ICommandBus>();

        /// <summary>
        ///     IEventStream.
        /// </summary>
        protected IEventStream EventStream =>
            _eventStream ??= Program.DependencyResolver.GetInstanceRequired<IEventStream>();

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
                return createParams;
            }
        }

        /// <summary>
        ///     Inicializa os componentes da janela.
        /// </summary>
        private void InitializeComponent2()
        {
            HandleCreated += (sender, args) => this.Translate();
        }
    }
}