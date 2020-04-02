using System.Diagnostics.CodeAnalysis;
using Cabster.Components;

namespace Cabster.Business.Forms
{
    /// <summary>
    ///     Janela de configuração.
    /// </summary>
    public partial class FormConfiguration : FormLayout
    {
        /// <summary>
        ///     Construtor.
        /// </summary>
        public FormConfiguration()
        {
            InitializeComponent();
            InitializeComponent2();
        }

        /// <summary>
        ///     Inicializa os componentes da janela.
        /// </summary>
        [ExcludeFromCodeCoverage]
        private void InitializeComponent2()
        {
            ButtonCloseClick += () => Program.SignalToTerminate = true;
        }
    }
}