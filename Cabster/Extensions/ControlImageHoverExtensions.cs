using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using Cabster.Exceptions;

namespace Cabster.Extensions
{
    /// <summary>
    ///     Extensão que aplica em um control o comportamento de hover de imagem,
    ///     quando a imagem troca ao passar o mouse por cima.
    /// </summary>
    public static class ControlImageHoverExtensions
    {
        /// <summary>
        ///     Lista de controles que foram ajustados.
        /// </summary>
        private static readonly Dictionary<int, MakeImageHoverInfo> Controls =
            new Dictionary<int, MakeImageHoverInfo>();

        /// <summary>
        ///     Cria o comportamento de mouse hover para imagem em um controle.
        /// </summary>
        /// <param name="control">Controle.</param>
        /// <param name="propertyName">Nome da propriedade que será definida com a imagem.</param>
        /// <param name="mouseLeave">Imagem quando o mouse está fora.</param>
        /// <param name="mouseEnter">Imagem quando o mouse está em cima.</param>
        public static T MakeImageHover<T>(
            this T control,
            string propertyName,
            Image? mouseLeave = null,
            Image? mouseEnter = null) where T : Control
        {
            var key = GetKey(control, propertyName);
            var containsKey = Controls.ContainsKey(key);

            if (mouseLeave != null || mouseEnter != null)
            {
                mouseLeave ??= mouseEnter;
                mouseEnter ??= mouseLeave;

                MakeImageHoverInfo info;
                if (containsKey)
                {
                    info = Controls[key];
                }
                else
                {
                    info = new MakeImageHoverInfo(
                        control,
                        propertyName,
                        mouseLeave!,
                        mouseEnter!);
                    Controls.Add(key, info);
                }

                info.ImageLeave = mouseLeave!;
                info.ImageEnter = mouseEnter!;
                info.Update();
            }
            else if (containsKey)
            {
                Controls[key].Restore();
                Controls.Remove(key);
            }

            return control;
        }

        /// <summary>
        ///     Gera uma chave única.
        /// </summary>
        /// <param name="control">Controle</param>
        /// <param name="propertyName">Nome da propriedade.</param>
        /// <returns>Valor para chave.</returns>
        private static int GetKey(object control, string propertyName)
        {
            return $"{control.GetHashCode()}{propertyName}".GetHashCode();
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
            private readonly PropertyInfo _propertyInfo;

            /// <summary>
            ///     Valor original da propriedade.
            /// </summary>
            private readonly object? _propertyValueOriginal;

            /// <summary>
            ///     Construtor.
            /// </summary>
            /// <param name="control">Control.</param>
            /// <param name="propertyName">Nome da propriedade que será definida com a imagem.</param>
            /// <param name="imageLeave">Imagem quando mouse está fora.</param>
            /// <param name="imageEnter">Imagem quando mouse está em cima.</param>
            public MakeImageHoverInfo(Control control, string propertyName, Image imageLeave, Image imageEnter)
            {
                _control = control;

                _propertyInfo =
                    _control
                        .GetType()
                        .GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Public)
                    ?? throw new WrongArgumentException(
                        nameof(MakeImageHoverInfo),
                        "constructor",
                        nameof(propertyName));

                _propertyValueOriginal = _propertyInfo.GetValue(control);

                ImageLeave = imageLeave;
                ImageEnter = imageEnter;
                _control.MouseLeave += ControlOnMouseLeave;
                _control.MouseEnter += ControlOnMouseEnter;

                Update();
            }

            /// <summary>
            ///     Imagem quando mouse está fora.
            /// </summary>
            public Image ImageLeave { get; set; }

            /// <summary>
            ///     Imagem quando mouse está em cima.
            /// </summary>
            public Image ImageEnter { get; set; }

            /// <summary>
            ///     Atualiza a exibição.
            /// </summary>
            public void Update()
            {
                ControlOnMouseEnter(_control, null);
                ControlOnMouseLeave(_control, null);
                Application.DoEvents();
            }

            /// <summary>
            ///     Restaura o valor original.
            /// </summary>
            public void Restore()
            {
                _propertyInfo.SetValue(_control, _propertyValueOriginal);
                Application.DoEvents();
            }

            /// <summary>
            ///     Evento para quando o mouse fica fora do controle
            /// </summary>
            /// <param name="sender">Fonte do evento.</param>
            /// <param name="args">Informações do evento.</param>
            private void ControlOnMouseLeave(object sender, EventArgs? args)
            {
                _propertyInfo.SetValue(_control, ImageLeave);
            }

            /// <summary>
            ///     Evento para quando o mouse fica em cima do controle.
            /// </summary>
            /// <param name="sender">Fonte do evento.</param>
            /// <param name="args">Informações do evento.</param>
            private void ControlOnMouseEnter(object sender, EventArgs? args)
            {
                _propertyInfo.SetValue(_control, ImageEnter);
            }
        }
    }
}