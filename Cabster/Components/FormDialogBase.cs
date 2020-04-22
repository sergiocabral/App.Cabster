using System.Linq;
using System.Windows.Forms;

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

        /// <summary>
        /// Esconde todas as janelas.
        /// </summary>
        public static void HideAll()
        {
            foreach (var form in Application
                .OpenForms
                .OfType<Form>()
                .Where(a => a is FormDialogBase)
                .ToArray())
            {
                form.DialogResult = DialogResult.Abort;
                form.Dispose();
            }
        }
    }
}