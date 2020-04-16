using System;
using System.Collections.Generic;
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
        ///     Lista de ponteiros de mouse do sistema operacional.
        /// </summary>
        private static readonly Dictionary<Cursor, Cursor> OperatingSystemCursors =
            new Dictionary<Cursor, Cursor>
            {
                {
                    Cursors.Hand,
                    new Cursor(WindowsApi.LoadCursor(IntPtr.Zero, 32649 /*IDC_HAND*/))
                }
            };

        /// <summary>
        ///     Corrige o cursor para o valor original do sistema operacional.
        /// </summary>
        /// <param name="cursor">Cursor.</param>
        public static void FixesForTheOperatingSystemCursor(this Cursor cursor)
        {
            if (cursor != Cursors.Hand)
                throw new WrongArgumentException(
                    nameof(WindowsApiExtensions),
                    nameof(FixesForTheOperatingSystemCursor),
                    nameof(cursor));

            var fieldName = cursor.ToString();
            fieldName = fieldName[0].ToString().ToLower() + fieldName.Substring(1);

            typeof(Cursors)
                .GetField(fieldName, BindingFlags.Static | BindingFlags.NonPublic)?
                .SetValue(null, OperatingSystemCursors[cursor]);
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