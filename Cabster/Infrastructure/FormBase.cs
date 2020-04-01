using System.Windows.Forms;
using Cabster.Properties;

// ReSharper disable VirtualMemberCallInConstructor

namespace Cabster.Infrastructure
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

            Text = Resources.System_Name;
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