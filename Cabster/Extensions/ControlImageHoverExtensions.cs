using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace Cabster.Extensions
{
    /// <summary>
    ///     Utilitários define uma propriedade de imagem com comportamento de hover
    /// </summary>
    public static class ControlImageHoverExtensions
    {
        /// <summary>
        ///     Lista de controles que foram ajustados.
        /// </summary>
        private static readonly Dictionary<Control, MakeImageHoverInfo> Controls =
            new Dictionary<Control, MakeImageHoverInfo>();

        /// <summary>
        ///     Cria o comportamento de mouse hover para imagem em um controle.
        /// </summary>
        /// <param name="control">Controle.</param>
        /// <param name="propertyName">Nome da propriedade que será definida com a imagem.</param>
        /// <param name="mouseLeave">Imagem quando o mouse está fora.</param>
        /// <param name="mouseEnter">Imagem quando o mouse está em cima.</param>
        public static void MakeImageHover(this Control control, string propertyName, Bitmap mouseLeave,
            Bitmap mouseEnter)
        {
            var containsKey = Controls.ContainsKey(control);

            if (mouseLeave != null || mouseEnter != null)
            {
                mouseLeave ??= mouseEnter;
                mouseEnter ??= mouseLeave;

                if (!containsKey)
                {
                    Controls.Add(control, new MakeImageHoverInfo(control, propertyName, mouseLeave, mouseEnter));
                }
                else
                {
                    var info = Controls[control];
                    info.PropertyName = propertyName;
                    info.ImageLeave = mouseLeave;
                    info.ImageEnter = mouseEnter;
                }
            }
            else if (containsKey)
            {
                Controls.Remove(control);
            }
        }

        /// <summary>
        ///     Informações dos forms que foram deixados invisíveis.
        /// </summary>
        private class MakeImageHoverInfo
        {
            /// <summary>
            ///     Controle.
            /// </summary>
            private readonly Control _control;

            /// <summary>
            ///     Propriedade que será definida.
            /// </summary>
            private PropertyInfo? _propertyInfo;

            /// <summary>
            ///     Construtor.
            /// </summary>
            /// <param name="control">Control.</param>
            /// <param name="propertyName">Nome da propriedade que será definida com a imagem.</param>
            /// <param name="imageLeave">Imagem quando mouse está fora.</param>
            /// <param name="imageEnter">Imagem quando mouse está em cima.</param>
            public MakeImageHoverInfo(Control control, string propertyName, Bitmap imageLeave, Bitmap imageEnter)
            {
                _control = control;
                PropertyName = propertyName;
                ImageLeave = imageLeave;
                ImageEnter = imageEnter;
                _control.MouseLeave += ControlOnMouseLeave;
                _control.MouseEnter += ControlOnMouseEnter;
            }

            /// <summary>
            ///     Nome da propriedade que será definida com a imagem.
            /// </summary>
            public string PropertyName { get; set; }

            /// <summary>
            ///     Propriedade que será definida.
            /// </summary>
            private PropertyInfo PropertyInfo =>
                _propertyInfo?.Name == PropertyName
                    ? _propertyInfo
                    : _propertyInfo = _control
                        .GetType()
                        .GetProperty(PropertyName, BindingFlags.Instance | BindingFlags.Public);

            /// <summary>
            ///     Imagem quando mouse está fora.
            /// </summary>
            public Bitmap ImageLeave { get; set; }

            /// <summary>
            ///     Imagem quando mouse está em cima.
            /// </summary>
            public Bitmap ImageEnter { get; set; }

            /// <summary>
            ///     Evento para quando o mouse fica fora do controle
            /// </summary>
            /// <param name="sender">Fonte do evento.</param>
            /// <param name="event">~Informações do evento.</param>
            private void ControlOnMouseLeave(object sender, EventArgs @event)
            {
                PropertyInfo.SetValue(_control, ImageLeave);
            }

            /// <summary>
            ///     Evento para quando o mouse fica em cima do controle.
            /// </summary>
            /// <param name="sender">Fonte do evento.</param>
            /// <param name="event">~Informações do evento.</param>
            private void ControlOnMouseEnter(object sender, EventArgs @event)
            {
                PropertyInfo.SetValue(_control, ImageEnter);
            }
        }
    }
}