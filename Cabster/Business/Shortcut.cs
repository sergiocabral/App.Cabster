using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Cabster.Exceptions;
using Cabster.Helpers;
using Cabster.Infrastructure;
using Cabster.Properties;
using Serilog;

namespace Cabster.Business
{
    /// <summary>
    ///     Configurações de teclas de atalho.
    /// </summary>
    // ReSharper disable once ClassNeverInstantiated.Global
    public class Shortcut : IShortcut, IDisposable
    {
        /// <summary>
        ///     Identificador da tecla de atalho utilizada.
        /// </summary>
        private const int ShortcutId = 0;

        /// <summary>
        ///     Janela do sistema operacional para registrar teclas de atalho.
        /// </summary>
        private readonly NativeWindow _nativeWindow;

        /// <summary>
        ///     Sinaliza que o atalho foi registrado.
        /// </summary>
        private bool _registered;

        /// <summary>
        ///     Construtor.
        /// </summary>
        public Shortcut()
        {
            this.LogClassInstantiate();

            _nativeWindow = new NativeWindow();
            _nativeWindow.KeyPressed += NativeWindowOnKeyPressed;
        }

        /// <summary>
        ///     Liberação de recursos.
        /// </summary>
        public void Dispose()
        {
            _nativeWindow.Dispose();
            this.LogClassDispose();
        }

        /// <summary>
        ///     Registra uma tecla de atalho.
        /// </summary>
        /// <param name="shortcut">Tecla de atalho</param>
        /// <returns>True quando algum atalho é registrado.</returns>
        public bool Register(Keys shortcut)
        {
            if (_registered)
            {
                if (!WindowsApi.UnregisterHotKey(_nativeWindow.Handle, ShortcutId))
                    throw new ThisWillNeverOccurException();
                _registered = false;
            }

            if (shortcut == Keys.None) return _registered;

            var modifier = ModifierKeys.None;
            if ((shortcut & Keys.Alt) == Keys.Alt) modifier |= ModifierKeys.Alt;
            if ((shortcut & Keys.Control) == Keys.Control) modifier |= ModifierKeys.Control;
            if ((shortcut & Keys.Shift) == Keys.Shift) modifier |= ModifierKeys.Shift;

            var key = shortcut & ~Keys.Alt & ~Keys.Control & ~Keys.Shift;

            if (modifier == ModifierKeys.None ||
                !Regex.IsMatch($"{key}", @"^([A-Z]|D[0-9])$")) return _registered;

            if (!WindowsApi.RegisterHotKey(_nativeWindow.Handle, ShortcutId, (uint) modifier, (uint) key))
                throw new WrongOperationException(Resources.Exception_Application_ShortcutAlreadyUsed);

            _registered = true;

            return _registered;
        }

        /// <summary>
        ///     Evento quando a tecla de atalho é pressionada.
        /// </summary>
        /// <param name="modifiers">Teclas de acesso.</param>
        /// <param name="key">Tecla.</param>
        private static void NativeWindowOnKeyPressed(ModifierKeys modifiers, Keys key)
        {
            // TODO: Implementar tecla de atalho.
            Log.Information("Shortcut {Modifiers} + {Key}", modifiers, key);
        }

        /// <summary>
        ///     Janela do sistema operacional para registrar teclas de atalho.
        /// </summary>
        private class NativeWindow : System.Windows.Forms.NativeWindow, IDisposable
        {
            /// <summary>
            ///     Construtor.
            /// </summary>
            public NativeWindow()
            {
                this.LogClassInstantiate();
                CreateHandle();
            }

            /// <summary>
            ///     Liberação de recursos.
            /// </summary>
            public void Dispose()
            {
                DestroyHandle();
                this.LogClassDispose();
            }

            /// <summary>
            ///     Cria a janela para o sistema operacional.
            /// </summary>
            private void CreateHandle()
            {
                CreateHandle(new CreateParams());
            }

            /// <summary>
            ///     Procedure associada a esta janela.
            /// </summary>
            /// <param name="message">Mensagem do sistema operacional.</param>
            protected override void WndProc(ref Message message)
            {
                base.WndProc(ref message);

                if (message.Msg != 0x0312 /* WM_HOTKEY */) return;

                var key = (Keys) (((int) message.LParam >> 16) & 0xFFFF);
                var modifier = (ModifierKeys) ((int) message.LParam & 0xFFFF);

                KeyPressed?.Invoke(modifier, key);
            }

            /// <summary>
            ///     Evento para quando a tecla é acionada.
            /// </summary>
            public event Action<ModifierKeys, Keys>? KeyPressed;
        }

        /// <summary>
        ///     Teclas de atalho de acesso.
        /// </summary>
        [Flags]
        private enum ModifierKeys : uint
        {
            /// <summary>
            ///     Nenhum
            /// </summary>
            None = 0,

            /// <summary>
            ///     Alt
            /// </summary>
            Alt = 1,

            /// <summary>
            ///     Control
            /// </summary>
            Control = 2,

            /// <summary>
            ///     Shift
            /// </summary>
            Shift = 4,

            /// <summary>
            ///     WinKey
            /// </summary>
            // ReSharper disable once UnusedMember.Local
            Win = 8
        }
    }
}