using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Cabster.Components
{
    /// <summary>
    ///     Botão estilizado para a aplicação.
    /// </summary>
    public partial class MyTextBox : TextBox
    {
        /// <summary>
        ///     Texto no controle.
        /// </summary>
        private Color _foreColor;

        /// <summary>
        ///     Texto de exibição quando vazio.
        /// </summary>
        private string? _placeholder;

        /// <summary>
        ///     Texto no controle.
        /// </summary>
        private string _text = string.Empty;

        /// <summary>
        ///     Sinaliza atualização de texto.
        /// </summary>
        private bool _textUpdating;

        /// <summary>
        ///     Construtor.
        /// </summary>
        public MyTextBox()
        {
            InitializeComponent();
            InitializeComponent2();
        }

        /// <summary>
        ///     Construtor.
        /// </summary>
        /// <param name="container">Container</param>
        public MyTextBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            InitializeComponent2();
        }

        /// <summary>
        ///     Texto de exibição quando vazio.
        /// </summary>
        public string Placeholder
        {
            get => _placeholder ?? string.Empty;
            set => _placeholder = value;
        }

        /// <summary>
        ///     Texto no controle.
        /// </summary>
        public new Color ForeColor
        {
            get => _foreColor;
            set
            {
                _foreColor = value;
                Text = Text;
            }
        }

        /// <summary>
        ///     Texto de exibição quando vazio.
        /// </summary>
        public new string Text
        {
            get => _text;
            set
            {
                _text = value;

                _textUpdating = true;

                if (!string.IsNullOrWhiteSpace(value) || Program.IsDebug == null)
                {
                    base.Text = value;
                    base.ForeColor = ForeColor;
                }
                else
                {
                    base.Text = Placeholder;
                    base.ForeColor = ControlPaint.Light(ForeColor, (float) 1.5);
                }

                _textUpdating = false;
            }
        }

        /// <summary>
        ///     Inicializa o componente.
        /// </summary>
        private void InitializeComponent2()
        {
            _foreColor = base.ForeColor;
            HandleCreated += (sender, args) => { Text = base.Text; };
            Enter += OnEnter;
            Leave += OnLeave;
            TextChanged += OnTextChanged;
        }

        /// <summary>
        ///     Quando recebe o foco.
        /// </summary>
        /// <param name="sender">Fonte do evento.</param>
        /// <param name="args">Dados do evento.</param>
        private void OnTextChanged(object sender, EventArgs args)
        {
            if (_textUpdating) return;
            _text = base.Text;
        }

        /// <summary>
        ///     Quando recebe o foco.
        /// </summary>
        /// <param name="sender">Fonte do evento.</param>
        /// <param name="args">Dados do evento.</param>
        private void OnLeave(object sender, EventArgs args)
        {
            Text = Text;
        }

        /// <summary>
        ///     Quando recebe o foco.
        /// </summary>
        /// <param name="sender">Fonte do evento.</param>
        /// <param name="args">Dados do evento.</param>
        private void OnEnter(object sender, EventArgs args)
        {
            if (!string.IsNullOrWhiteSpace(_text)) return;
            base.Text = string.Empty;
            base.ForeColor = ForeColor;
        }
    }
}