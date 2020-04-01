using Cabster.Extensions;

namespace Cabster.Components
{
    /// <summary>
    ///     Janela invisível.
    /// </summary>
    public partial class FormMainWindow : FormBase
    {
        /// <summary>
        ///     Construtor.
        /// </summary>
        public FormMainWindow()
        {
            InitializeComponent();

            this.MakeInvisible();
        }
    }
}