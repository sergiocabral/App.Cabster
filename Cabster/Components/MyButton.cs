using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Cabster.Extensions;
using Cabster.Properties;

namespace Cabster.Components
{
    /// <summary>
    ///     Botão estilizado para a aplicação.
    /// </summary>
    public partial class MyButton : Button
    {
        /// <summary>
        ///     Lista de imagens disponíveis. A consulta é feita nas imagens nos recursos
        ///     que finalizam com *Leave ou *Enter para os evento MouseEnter e MouseLeave.
        /// </summary>
        private static readonly Dictionary<string, (Bitmap, Bitmap)> Images = typeof(Resources)
            .GetProperties(BindingFlags.Static | BindingFlags.Public)
            .Where(a =>
                a.Name.EndsWith("Leave") ||
                a.Name.EndsWith("Enter"))
            .OrderByDescending(a => a.Name)
            .GroupBy(a =>
                Regex.Replace(a.Name, @"(Leave$|Enter$)", string.Empty))
            .ToDictionary(
                key =>
                    key.Key,
                value =>
                    ((Bitmap) value.First().GetValue(null), (Bitmap) value.Last().GetValue(null)));

        /// <summary>
        ///     Construtor.
        /// </summary>
        public MyButton()
        {
            InitializeComponent();
            InitializeComponent2();
        }

        /// <summary>
        ///     Construtor.
        /// </summary>
        /// <param name="container">Container</param>
        public MyButton(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            InitializeComponent2();
        }

        /// <summary>
        ///     Texto do controle.
        /// </summary>
        public override string Text
        {
            get => base.Text;
            set
            {
                UpdateSizeToText(value);
                base.Text = value;
            }
        }

        /// <summary>
        ///     Atualiza o tamanho do controle com base no texto.
        /// </summary>
        public void UpdateSizeToText()
        {
            UpdateSizeToText(Text);
        }

        /// <summary>
        ///     Atualiza o tamanho do controle com base no texto.
        /// </summary>
        private void UpdateSizeToText(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return;
            const int padding = 20;
            var measureText = TextRenderer.MeasureText(text, Font);
            Size = new Size(
                measureText.Width + padding,
                measureText.Height + padding);
        }

        /// <summary>
        ///     Inicializa o componente.
        /// </summary>
        private void InitializeComponent2()
        {
            FlatStyle = FlatStyle.Flat;
            Cursor = Cursors.Hand;
            HandleCreated += (sender, args) => UpdateLayout();
        }

        /// <summary>
        ///     Atualiza a exibição do controle.
        /// </summary>
        public void UpdateLayout()
        {
            if (Images.ContainsKey(Name))
            {
                var (bitmapLeave, bitmapEnter) = Images[Name];
                this.MakeImageHover("Image", bitmapLeave, bitmapEnter);

                Text = string.Empty;

                FlatAppearance.BorderSize = 0;
                FlatAppearance.CheckedBackColor = Color.Transparent;
                FlatAppearance.MouseDownBackColor = Color.Transparent;
                FlatAppearance.MouseOverBackColor = Color.Transparent;
                try
                {
                    BackColor = Color.Transparent;
                }
                catch { /* Ignora em caso de erro. */ }
            }
            else
            {
                FlatAppearance.BorderSize = 3;
                FlatAppearance.BorderColor = ControlPaint.Light(BackColor, (float) 0.8);
                FlatAppearance.MouseOverBackColor = ControlPaint.Dark(BackColor, (float) 0.2);
                FlatAppearance.MouseDownBackColor = ControlPaint.Dark(BackColor, (float) 0.3);
                FlatAppearance.CheckedBackColor = ControlPaint.Dark(BackColor, (float) 0.3);
            }
        }
    }
}