using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cabster.Helpers
{
    /// <summary>
    ///     Funcionalidades relacionadas a API do Windows.
    /// </summary>
    public static class WindowsApi
    {
        /// <summary>
        ///     Curso original do sistema operacional para Hand.
        /// </summary>
        private static readonly Cursor SystemHandCursor =
            new Cursor(LoadCursor(IntPtr.Zero, 32649 /*IDC_HAND*/));

        /// <summary>
        ///     Carrega um curso de mouse do sistema operacional.
        /// </summary>
        /// <param name="hInstance">IntPtr</param>
        /// <param name="lpCursorName">int</param>
        /// <returns>IntPtr</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr LoadCursor(IntPtr hInstance, int lpCursorName);

        /// <summary>
        ///     Corrige o problema do cursor do mouse de tipo Hand que não usa a imagem do sistema operacional.
        /// </summary>
        public static void FixCursorHand()
        {
            // Executa como Task para ignorar uma possível exception. Vai quê...
            Task.Run(() => typeof(Cursors)
                .GetField("hand", BindingFlags.Static | BindingFlags.NonPublic)?
                .SetValue(null, SystemHandCursor));
        }
    }
}