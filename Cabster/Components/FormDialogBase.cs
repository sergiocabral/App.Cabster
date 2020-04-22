namespace Cabster.Components
{
    /// <summary>
    ///     Form base para dialogos de mensagens.
    /// </summary>
    public partial class FormDialogBase : FormBase, IFormTopMost
    {
        /// <summary>
        ///     Construtor.
        /// </summary>
        protected FormDialogBase()
        {
            InitializeComponent();
        }
    }
}