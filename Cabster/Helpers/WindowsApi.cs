using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Cabster.Helpers
{
    /// <summary>
    ///     Referências para APIs do Windows.
    ///     Consulte a documentação na internet em http://www.pinvoke.net/
    /// </summary>
    public static class WindowsApi
    {
        /// <summary>
        ///     http://www.pinvoke.net/default.aspx/user32/GetWindow.html
        /// </summary>
        public enum GetWindowType : uint
        {
            /// <summary>
            ///     The retrieved handle identifies the window of the same type that is highest in the Z order.
            ///     If the specified window is a topmost window, the handle identifies a topmost window.
            ///     If the specified window is a top-level window, the handle identifies a top-level window.
            ///     If the specified window is a child window, the handle identifies a sibling window.
            /// </summary>
            GW_HWNDFIRST = 0,

            /// <summary>
            ///     The retrieved handle identifies the window of the same type that is lowest in the Z order.
            ///     If the specified window is a topmost window, the handle identifies a topmost window.
            ///     If the specified window is a top-level window, the handle identifies a top-level window.
            ///     If the specified window is a child window, the handle identifies a sibling window.
            /// </summary>
            GW_HWNDLAST = 1,

            /// <summary>
            ///     The retrieved handle identifies the window below the specified window in the Z order.
            ///     If the specified window is a topmost window, the handle identifies a topmost window.
            ///     If the specified window is a top-level window, the handle identifies a top-level window.
            ///     If the specified window is a child window, the handle identifies a sibling window.
            /// </summary>
            GW_HWNDNEXT = 2,

            /// <summary>
            ///     The retrieved handle identifies the window above the specified window in the Z order.
            ///     If the specified window is a topmost window, the handle identifies a topmost window.
            ///     If the specified window is a top-level window, the handle identifies a top-level window.
            ///     If the specified window is a child window, the handle identifies a sibling window.
            /// </summary>
            GW_HWNDPREV = 3,

            /// <summary>
            ///     The retrieved handle identifies the specified window's owner window, if any.
            /// </summary>
            GW_OWNER = 4,

            /// <summary>
            ///     The retrieved handle identifies the child window at the top of the Z order,
            ///     if the specified window is a parent window; otherwise, the retrieved handle is NULL.
            ///     The function examines only child windows of the specified window. It does not examine descendant windows.
            /// </summary>
            GW_CHILD = 5,

            /// <summary>
            ///     The retrieved handle identifies the enabled popup window owned by the specified window (the
            ///     search uses the first such window found using GW_HWNDNEXT); otherwise, if there are no enabled
            ///     popup windows, the retrieved handle is that of the specified window.
            /// </summary>
            GW_ENABLEDPOPUP = 6
        }

        /// <summary>
        ///     http://www.pinvoke.net/default.aspx/user32/RegisterHotKey.html
        /// </summary>
        [Flags]
        public enum KeyModifiers
        {
            None = 0,
            Alt = 1,
            Control = 2,
            Shift = 4,

            // Either WINDOWS key was held down. These keys are labeled with the Windows logo.
            // Keyboard shortcuts that involve the WINDOWS key are reserved for use by the
            // operating system.
            Windows = 8
        }

        /// <summary>
        ///     http://www.pinvoke.net/default.aspx/Enums/ShowWindowCommand.html
        /// </summary>
        public enum ShowWindowCommands : uint
        {
            /// <summary>
            ///     Hides the window and activates another window.
            /// </summary>
            Hide = 0,

            /// <summary>
            ///     Activates and displays a window. If the window is minimized or
            ///     maximized, the system restores it to its original size and position.
            ///     An application should specify this flag when displaying the window
            ///     for the first time.
            /// </summary>
            Normal = 1,

            /// <summary>
            ///     Activates the window and displays it as a minimized window.
            /// </summary>
            ShowMinimized = 2,

            /// <summary>
            ///     Maximizes the specified window.
            /// </summary>
            Maximize = 3, // is this the right value?

            /// <summary>
            ///     Activates the window and displays it as a maximized window.
            /// </summary>
            ShowMaximized = 3,

            /// <summary>
            ///     Displays a window in its most recent size and position. This value
            ///     is similar to <see cref="Win32.ShowWindowCommand.Normal" />, except
            ///     the window is not activated.
            /// </summary>
            ShowNoActivate = 4,

            /// <summary>
            ///     Activates the window and displays it in its current size and position.
            /// </summary>
            Show = 5,

            /// <summary>
            ///     Minimizes the specified window and activates the next top-level
            ///     window in the Z order.
            /// </summary>
            Minimize = 6,

            /// <summary>
            ///     Displays the window as a minimized window. This value is similar to
            ///     <see cref="Win32.ShowWindowCommand.ShowMinimized" />, except the
            ///     window is not activated.
            /// </summary>
            ShowMinNoActive = 7,

            /// <summary>
            ///     Displays the window in its current size and position. This value is
            ///     similar to <see cref="Win32.ShowWindowCommand.Show" />, except the
            ///     window is not activated.
            /// </summary>
            ShowNA = 8,

            /// <summary>
            ///     Activates and displays the window. If the window is minimized or
            ///     maximized, the system restores it to its original size and position.
            ///     An application should specify this flag when restoring a minimized window.
            /// </summary>
            Restore = 9,

            /// <summary>
            ///     Sets the show state based on the SW_* value specified in the
            ///     STARTUPINFO structure passed to the CreateProcess function by the
            ///     program that started the application.
            /// </summary>
            ShowDefault = 10,

            /// <summary>
            ///     <b>Windows 2000/XP:</b> Minimizes a window, even if the thread
            ///     that owns the window is not responding. This flag should only be
            ///     used when minimizing windows from a different thread.
            /// </summary>
            ForceMinimize = 11
        }

        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, KeyModifiers fsModifiers, Keys vk);

        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, ShowWindowCommands nCmdShow);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr LoadCursor(IntPtr hInstance, int lpCursorName);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.None, SetLastError = true)]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr GetWindow(IntPtr hWnd, GetWindowType uCmd);
    }
}