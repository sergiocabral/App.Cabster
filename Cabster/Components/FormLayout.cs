namespace Cabster.Components
{
    /// <summary>
    ///     Janela invisível.
    /// </summary>
    public partial class FormLayout : FormBase
    {
        /// <summary>
        ///     Construtor.
        /// </summary>
        public FormLayout()
        {
            InitializeComponent();
            InitializeComponent2();
        }

        /// <summary>
        /// Inicializa os componentes da janela.
        /// </summary>
        private void InitializeComponent2()
        {
            labelTitle.Text = Text;
        }
    }
}