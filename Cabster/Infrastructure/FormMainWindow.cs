using System.Windows.Forms;

namespace Cabster.Infrastructure
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

            TurnInvisible();
        }

        /// <summary>
        ///     Torna a janela invisível.
        /// </summary>
        private void TurnInvisible()
        {
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            Width = 0;
            Height = 0;
            Left = int.MaxValue;
            Top = int.MaxValue;
            Shown += (sender, args) => Hide();
        }
    }
}