using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Cabster.Extensions
{
    /// <summary>
    ///     Extensão que ativa ou desativa o desenho do componente usando API do Windows.
    /// </summary>
    public static class ControlSetRedrawExtensions
    {
        /// <summary>
        ///     Lista de controles que foram ajustados.
        /// </summary>
        private static readonly Dictionary<IWin32Window, SetRedrawInfo> Controls =
            new Dictionary<IWin32Window, SetRedrawInfo>();

        /// <summary>
        ///     Ativa ou desativa o desenho do componente pelo sistema operacional
        /// </summary>
        /// <param name="control">Controle.</param>
        /// <param name="enable">Ativa ou desativa.</param>
        public static T SetRedraw<T>(this T control, bool enable) where T : IWin32Window
        {
            var containsKey = Controls.ContainsKey(control);

            if (!containsKey && enable) return control;

            if (!containsKey) Controls.Add(control, new SetRedrawInfo(control));

            Controls[control].SetRedraw(enable);

            if (enable) Controls.Remove(control);

            return control;
        }

        /// <summary>
        ///     Informações dos forms que foram deixados invisíveis.
        /// </summary>
        private class SetRedrawInfo
        {
            /// <summary>
            ///     Handle do sistema operacional para o controle.
            /// </summary>
            private readonly HandleRef _controlHandleRef;

            /// <summary>
            ///     Construtor.
            /// </summary>
            /// <param name="control">Control.</param>
            public SetRedrawInfo(IWin32Window control)
            {
                _controlHandleRef = new HandleRef(control, control.Handle);
            }

            /// <summary>
            ///     Ativa ou desativa o redesenho.
            /// </summary>
            /// <param name="enable">Ativa ou desativa.</param>
            public void SetRedraw(bool enable)
            {
                _controlHandleRef.SetRedraw(enable);
            }
        }
    }
}