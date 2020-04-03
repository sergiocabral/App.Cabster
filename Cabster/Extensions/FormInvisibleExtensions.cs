using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Cabster.Extensions
{
    /// <summary>
    ///     Extensão para esconde totalmente uma janela.
    ///     Usar com FormBase para melhor resultado.
    /// </summary>
    public static class FormInvisibleExtensions
    {
        /// <summary>
        ///     Lista de forms que foram ajustados.
        /// </summary>
        private static readonly Dictionary<Form, MakeInvisibleInfo> Forms =
            new Dictionary<Form, MakeInvisibleInfo>();

        /// <summary>
        ///     Torna um form invisível.
        /// </summary>
        /// <param name="form">Form.</param>
        /// <param name="invisible">Modo.</param>
        public static Form MakeInvisible(this Form form, bool invisible = true)
        {
            var containsKey = Forms.ContainsKey(form);

            if (!containsKey && !invisible) return form;

            if (!containsKey) Forms.Add(form, new MakeInvisibleInfo(form));

            Forms[form].Visible(!invisible);

            if (!invisible) Forms.Remove(form);

            return form;
        }

        /// <summary>
        ///     Informações dos forms que foram deixados invisíveis.
        /// </summary>
        private class MakeInvisibleInfo
        {
            /// <summary>
            ///     Valor original da propriedade: Height
            /// </summary>
            private readonly int _backupHeight;

            /// <summary>
            ///     Valor original da propriedade: Left
            /// </summary>
            private readonly int _backupLeft;

            /// <summary>
            ///     Valor original da propriedade:
            /// </summary>
            private readonly bool _backupShowInTaskbar;

            /// <summary>
            ///     Valor original da propriedade: StartPosition
            /// </summary>
            private readonly FormStartPosition _backupStartPosition;

            /// <summary>
            ///     Valor original da propriedade: Top
            /// </summary>
            private readonly int _backupTop;

            /// <summary>
            ///     Valor original da propriedade: Visible
            /// </summary>
            private readonly bool _backupVisible;

            /// <summary>
            ///     Valor original da propriedade: Width
            /// </summary>
            private readonly int _backupWidth;

            /// <summary>
            ///     Form.
            /// </summary>
            private readonly Form _form;

            /// <summary>
            ///     Construtor.
            /// </summary>
            /// <param name="form">Form.</param>
            public MakeInvisibleInfo(Form form)
            {
                _form = form;
                _backupVisible = form.Visible;
                _backupShowInTaskbar = form.ShowInTaskbar;
                _backupStartPosition = form.StartPosition;
                _backupWidth = form.Width;
                _backupHeight = form.Height;
                _backupLeft = form.Left;
                _backupTop = form.Top;
            }

            /// <summary>
            ///     Deixa visível ou não.
            /// </summary>
            /// <param name="visible">Modo.</param>
            public void Visible(bool visible)
            {
                if (visible)
                {
                    _form.SetRedraw(true);
                    _form.ShowInTaskbar = _backupShowInTaskbar;
                    _form.Visible = _backupVisible;
                    _form.StartPosition = _backupStartPosition;
                    _form.Width = _backupWidth;
                    _form.Height = _backupHeight;
                    _form.Left = _backupLeft;
                    _form.Top = _backupTop;
                    _form.Shown -= HideForm;
                    _form.Activate();
                }
                else
                {
                    _form.ShowInTaskbar = false;
                    _form.Visible = false;
                    _form.StartPosition = FormStartPosition.Manual;
                    _form.Width = 0;
                    _form.Height = 0;
                    _form.Left = int.MaxValue;
                    _form.Top = int.MaxValue;
                    _form.Shown += HideForm;
                    _form.SetRedraw(false);
                }

                Application.DoEvents();
            }

            /// <summary>
            ///     Evento usado para esconder o form.
            /// </summary>
            /// <param name="sender">Fonte do evento.</param>
            /// <param name="args">Informações do evento.</param>
            private static void HideForm(object sender, EventArgs args)
            {
                ((Form) sender).Hide();
            }
        }
    }
}