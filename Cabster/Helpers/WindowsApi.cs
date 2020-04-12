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

        /// <summary>
        ///     Envia mensagens via API do Windows.
        /// </summary>
        /// <param name="hWnd">HandleRef</param>
        /// <param name="msg">int</param>
        /// <param name="wParam">IntPtr</param>
        /// <param name="lParam">IntPtr</param>
        /// <returns>IntPtr</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        private static extern IntPtr SendMessage(HandleRef hWnd, int msg, IntPtr wParam, IntPtr lParam);

        /// <summary>
        ///     Ativa ou desativa o desenho do componente.
        /// </summary>
        /// <param name="handle">HandleRef</param>
        /// <param name="enable">Ativa ou desativa.</param>
        public static void EnableRepaint(HandleRef handle, bool enable)
        {
            SendMessage(
                handle, 0x000B /* WM_SETREDRAW */, new IntPtr(enable ? 1 : 0), IntPtr.Zero);
        }

        /// <summary>
        /// Exibe ou esconde uma janela.
        /// </summary>
        /// <param name="hWnd">IntPtr</param>
        /// <param name="nCmdShow">bool</param>
        /// <returns>bool</returns>
        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, bool nCmdShow);
        
        /// <summary>
        /// Registra uma tecla de atalho.
        /// </summary>
        /// <param name="hWnd">IntPtr</param>
        /// <param name="id">int</param>
        /// <param name="fsModifiers">uint</param>
        /// <param name="vk">uint</param>
        /// <returns>bool</returns>
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);
        
        /// <summary>
        /// Remove o registro de uma tecla de atalho
        /// </summary>
        /// <param name="hWnd">IntPtr</param>
        /// <param name="id">id</param>
        /// <returns>bool</returns>
        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

    }
}