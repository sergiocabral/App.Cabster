using System.Diagnostics.CodeAnalysis;
using Cabster.Components;

namespace Cabster.Business.Forms
{
    /// <summary>
    ///     Janela de trabalho em grupo.
    /// </summary>
    public partial class FormWorkGroup : FormLayout
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
        ///     Inicializa os componentes da janela.
        /// </summary>
        [ExcludeFromCodeCoverage]
        private void InitializeComponent2()
        {
        }
    }
}