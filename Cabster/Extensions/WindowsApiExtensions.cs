using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Cabster.Exceptions;
using Cabster.Helpers;

namespace Cabster.Extensions
{
    /// <summary>
    ///     Funcionalidades relacionadas a API do Windows.
    /// </summary>
    public static class WindowsApiExtensions
    {
        /// <summary>
        ///     Lista de correspondência de ponteiros de mouse com o sistema operacional.
        /// </summary>
        private static readonly Dictionary<Cursor, WindowsApi.IDC_STANDARD_CURSORS> CursorsMatchingValues =
            new Dictionary<Cursor, WindowsApi.IDC_STANDARD_CURSORS>
            {
                {Cursors.No, WindowsApi.IDC_STANDARD_CURSORS.IDC_NO},
                {Cursors.Hand, WindowsApi.IDC_STANDARD_CURSORS.IDC_HAND},
                {Cursors.Help, WindowsApi.IDC_STANDARD_CURSORS.IDC_HELP},
                {Cursors.WaitCursor, WindowsApi.IDC_STANDARD_CURSORS.IDC_WAIT},
                {Cursors.Arrow, WindowsApi.IDC_STANDARD_CURSORS.IDC_ARROW},
                {Cursors.Cross, WindowsApi.IDC_STANDARD_CURSORS.IDC_CROSS},
                {Cursors.IBeam, WindowsApi.IDC_STANDARD_CURSORS.IDC_IBEAM},
                {Cursors.SizeNS, WindowsApi.IDC_STANDARD_CURSORS.IDC_SIZENS},
                {Cursors.SizeWE, WindowsApi.IDC_STANDARD_CURSORS.IDC_SIZEWE},
                {Cursors.SizeAll, WindowsApi.IDC_STANDARD_CURSORS.IDC_SIZEALL},
                {Cursors.UpArrow, WindowsApi.IDC_STANDARD_CURSORS.IDC_UPARROW},
                {Cursors.SizeNESW, WindowsApi.IDC_STANDARD_CURSORS.IDC_SIZENESW},
                {Cursors.SizeNWSE, WindowsApi.IDC_STANDARD_CURSORS.IDC_SIZENWSE},
                {Cursors.AppStarting, WindowsApi.IDC_STANDARD_CURSORS.IDC_APPSTARTING}
            };

        /// <summary>
        ///     Corrige o cursor para o valor original do sistema operacional.
        /// </summary>
        /// <param name="cursor">Cursor.</param>
        public static void FixesForTheOperatingSystemCursor(this Cursor cursor)
        {
            if (!CursorsMatchingValues.ContainsKey(cursor))
                throw new WrongArgumentException(
                    nameof(WindowsApiExtensions),
                    nameof(FixesForTheOperatingSystemCursor),
                    nameof(cursor));

            var cursorsType = typeof(Cursors);

            var cursorsProperty = cursorsType
                .GetProperties(BindingFlags.Static | BindingFlags.Public)
                .Single(a => a.GetValue(null).Equals(cursor));

            var cursorsFieldName = cursorsProperty.Name[0].ToString().ToLower() + cursorsProperty.Name.Substring(1);

            var cursorsField = cursorsType.GetField(cursorsFieldName, BindingFlags.Static | BindingFlags.NonPublic)
                               ?? throw new ThisWillNeverOccurException();

            var operatingSystemCursorName = CursorsMatchingValues[cursor];
            var operatingSystemCursorHandle = WindowsApi.LoadCursor(IntPtr.Zero, operatingSystemCursorName);
            var operatingSystemCursor = new Cursor(operatingSystemCursorHandle);

            cursorsField.SetValue(null, operatingSystemCursor);
        }

        /// <summary>
        ///     Ativa ou desativa o desenho do componente.
        /// </summary>
        /// <param name="handle">Handle do componente.</param>
        /// <param name="enable">Ativa ou desativa.</param>
        public static void SetRedraw(this HandleRef handle, bool enable)
        {
            WindowsApi.SendMessage(
                handle,
                0x000B /* WM_SETREDRAW */,
                new IntPtr(enable ? 1 : 0),
                IntPtr.Zero);
        }

        /// <summary>
        ///     Obtem o nome da janela.
        /// </summary>
        /// <param name="hWnd">Handle da janela.</param>
        /// <returns>Texto.</returns>
        public static string GetWindowText(this IntPtr hWnd)
        {
            var text = new StringBuilder(255);
            WindowsApi.GetWindowText(hWnd, text, text.Capacity);
            return text.ToString();
        }

        /// <summary>
        ///     Obtem o Z-Order de uma janela.
        /// </summary>
        /// <param name="hWnd">Handle da janela.</param>
        /// <returns>Z-Order</returns>
        public static int GetWindowZOrder(this IntPtr hWnd)
        {
            var zOrder = -1;
            while ((hWnd = WindowsApi.GetWindow(hWnd, WindowsApi.GetWindowType.GW_HWNDNEXT))
                   != IntPtr.Zero) zOrder++;
            return zOrder;
        }

        /// <summary>
        ///     Exibe ou esconde uma janela do sistema operacional.
        /// </summary>
        /// <param name="hWnd">Handle da janela.</param>
        /// <param name="mode">Exibe ou esconde.</param>
        /// <returns>Sinaliza sucesso na execução da ação.</returns>
        public static bool ShowWindow(this IntPtr hWnd, bool mode)
        {
            return WindowsApi.ShowWindow(
                hWnd,
                mode
                    ? WindowsApi.ShowWindowCommands.Show
                    : WindowsApi.ShowWindowCommands.Hide);
        }

        /// <summary>
        ///     Registra uma tecla de atalho no sistema operacional para uma janela.
        /// </summary>
        /// <param name="hWnd">Handle da janela.</param>
        /// <param name="id">Identificador da tecla de atalho.</param>
        /// <param name="modifiers">Modificador</param>
        /// <param name="key">Tecla</param>
        /// <returns>Sinaliza sucesso na execução da ação.</returns>
        public static bool RegisterHotKey(this IntPtr hWnd, int id, WindowsApi.KeyModifiers modifiers, Keys key)
        {
            return WindowsApi.RegisterHotKey(hWnd, id, modifiers, key);
        }

        /// <summary>
        ///     Remove o registro de uma tecla de atalho no sistema operacional para uma janela
        /// </summary>
        /// <param name="hWnd">Handle da janela.</param>
        /// <param name="id">Identificador da tecla de atalho.</param>
        /// <returns>Sinaliza sucesso na execução da ação.</returns>
        public static bool UnregisterHotKey(this IntPtr hWnd, int id)
        {
            return WindowsApi.UnregisterHotKey(hWnd, id);
        }
    }
}