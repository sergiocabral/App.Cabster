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
        ///     Lista de imagens disponíveis.
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
        ///     Inicializa o componente.
        /// </summary>
        private void InitializeComponent2()
        {
            FlatStyle = FlatStyle.Flat;

            HandleCreated += (sender, args) =>
            {
                if (!Images.ContainsKey(Name)) return;
                Text = string.Empty;
                var (bitmapLeave, bitmapEnter) = Images[Name];
                this.MakeImageHover("Image", bitmapLeave, bitmapEnter);
            };
        }
    }
}