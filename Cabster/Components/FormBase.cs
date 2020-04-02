using System.Windows.Forms;
using Cabster.Extensions;
using Cabster.Properties;

// ReSharper disable VirtualMemberCallInConstructor

namespace Cabster.Components
{
    /// <summary>
    ///     Form base do sistema.
    /// </summary>
    public partial class FormBase : Form
    {
        /// <summary>
        ///     Construtor.
        /// </summary>
        public FormBase()
        {
            InitializeComponent();
            InitializeComponent2();
        }

        /// <summary>
        ///     Inicializa os componentes da janela.
        /// </summary>
        private void InitializeComponent2()
        {
            HandleCreated += (sender, args) => this.Translate();
        }
        
        /// <summary>
        ///     Atributos para criação da janela.
        ///     Necessário para esconder a janela da barra de tarefas quando ShowInTaskbar=False .
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                var createParams = base.CreateParams;
                if (!ShowInTaskbar) createParams.ExStyle |= 0x80; // Ativa o atributo WS_EX_TOOLWINDOW
                return createParams;
            }
        }
    }
}