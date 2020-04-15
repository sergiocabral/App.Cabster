using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Cabster.Business.Forms;
using Cabster.Components;
using Cabster.Helpers;
using Cabster.Infrastructure;
using Cabster.Properties;
using Serilog;

namespace Cabster.Business
{
    /// <summary>
    ///     Bloqueador de telas.
    /// </summary>
    // ReSharper disable once ClassNeverInstantiated.Global
    public class LockScreen : ILockScreen, IDisposable
    {
        /// <summary>
        ///     Informações sobre as janelas da aplicação.
        /// </summary>
        private readonly FormsInfo _forms;

        /// <summary>
        ///     Marca para sinalizar que um form é um bloqueador de telas.
        /// </summary>
        private readonly object _markToFormLockScreen = new object();

        /// <summary>
        ///     Temporizador para manter as janelas no topo.
        /// </summary>
        private readonly Timer _timer;

        /// <summary>
        ///     Construtor.
        /// </summary>
        public LockScreen()
        {
            this.LogClassInstantiate();

            _forms = new FormsInfo(_markToFormLockScreen);
            _timer = new Timer
            {
                Interval = 5000,
                Enabled = false
            };
            _timer.Tick += TimerOnTick;
        }

        /// <summary>
        ///     Liberar recursos.
        /// </summary>
        public void Dispose()
        {
            _timer.Dispose();

            this.LogClassDispose();
        }

        /// <summary>
        ///     Determina se as telas estão bloqueada.
        /// </summary>
        public bool IsLocked
        {
            get => _timer.Enabled;
            private set => _timer.Enabled = value;
        }

        /// <summary>
        ///     Bloqueia todas as telas.
        /// </summary>
        public void Lock()
        {
            if (IsLocked) return;

            foreach (var screen in Screen.AllScreens) CreateForm(screen);

            var formsLayout = Application
                .OpenForms
                .Cast<Form>()
                .Where(a => a is IFormLayout)
                .ToArray();

            //foreach (var form in formsLayout) form.TopMost = true;

            IsLocked = true;
        }

        /// <summary>
        ///     Desbloqueia todas as telas.
        /// </summary>
        public void Unlock()
        {
            if (!IsLocked) return;

            foreach (var form in Application.OpenForms.Cast<Form>().ToArray())
            {
                form.TopMost = false;
                if (form.Tag != _markToFormLockScreen) continue;
                form.Hide();
                form.Close();
                Application.DoEvents();
            }

            IsLocked = false;
        }

        /// <summary>
        ///     Temporizador para manter as janelas no topo.
        /// </summary>
        /// <param name="sender">Fonte do evento.</param>
        /// <param name="args">Informações sobre o evento.</param>
        private void TimerOnTick(object sender, EventArgs args)
        {
            var timer = (Timer) sender;
            timer.Enabled = false;
            try
            {
                var windowsInternal = _forms.Internal;

                if (windowsInternal.Any(a => a.ContainsFocus) || !windowsInternal.Any()) return;

                var forms = _forms
                    .LockScreen
                    .Concat(_forms
                        .Layout
                        .OrderBy(a => a.Handle.GetWindowZOrder()))
                    .ToArray();

                foreach (var form in forms)
                {
                    form.Activate();
                    form.BringToFront();
                }
                
                Log.Verbose("Ops");
            }
            finally
            {
                timer.Enabled = true;
            }
        }

        /// <summary>
        ///     Cria uma janela que bloqueia a tela.
        /// </summary>
        /// <param name="screen">Tela.</param>
        private void CreateForm(Screen screen)
        {
            var form = CreateForm();
            form.Left = screen.Bounds.X;
            form.Top = screen.Bounds.Y;
            form.Width = screen.Bounds.Width;
            form.Height = screen.Bounds.Height;
            form.Show();

            Log.Debug(
                "Lock screen created for area: Left: {Left}, Top: {Top}, Width: {Width}, Height: {Height}.",
                form.Left, form.Top, form.Width, form.Height);
        }

        /// <summary>
        ///     Cria uma janela padrão.
        /// </summary>
        /// <returns></returns>
        private Form CreateForm()
        {
            var form = new FormBase
            {
                Tag = _markToFormLockScreen,
                ShowInTaskbar = false,
                //TopMost = true,
                StartPosition = FormStartPosition.Manual,
                Text = Resources.Name_Application,
                FormBorderStyle = FormBorderStyle.None,
                BackColor = Color.Black,
                BackgroundImage = Resources.FormLockScreenBackground,
                Opacity = 0.015
            };
            form.Closing += FormOnClosing;
            return form;
        }

        /// <summary>
        ///     Evento ao fechar a janela.
        /// </summary>
        /// <param name="sender">Fonte do evento.</param>
        /// <param name="args">Informações do evento.</param>
        private static void FormOnClosing(object sender, CancelEventArgs args)
        {
            var form = (Form) sender;
            args.Cancel = form.Visible;
        }

        /// <summary>
        ///     Informações sobre as janelas da aplicação.
        /// </summary>
        private class FormsInfo
        {
            /// <summary>
            ///     Lista de janelas.
            /// </summary>
            private readonly Dictionary<FormType, object> _forms = new Dictionary<FormType, object>();

            /// <summary>
            ///     Marca para sinalizar que um form é um bloqueador de telas.
            /// </summary>
            private readonly object _markToFormLockScreen;

            /// <summary>
            ///     Cronômetro.
            /// </summary>
            private readonly Stopwatch _stopwatch = new Stopwatch();

            /// <summary>
            ///     Última contagem de janelas.
            /// </summary>
            private int _lastApplicationFormCount;

            /// <summary>
            ///     Construtor
            /// </summary>
            /// <param name="markToFormLockScreen">Marca para sinalizar que um form é um bloqueador de telas.</param>
            public FormsInfo(object markToFormLockScreen)
            {
                this.LogClassInstantiate();

                _markToFormLockScreen = markToFormLockScreen;
                _stopwatch.Start();
            }

            /// <summary>
            ///     Todas as janelas.
            /// </summary>
            public Form[] Internal => (Form[]) GetFormList(FormType.Internal);

            /// <summary>
            ///     Janelas de bloqueio de tela.
            /// </summary>
            public Form[] LockScreen => (Form[]) GetFormList(FormType.LockScreen);

            /// <summary>
            ///     Janela da aplicação.
            /// </summary>
            public Form[] Layout => (Form[]) GetFormList(FormType.Layout);

            /// <summary>
            ///     Janela da aplicação.
            /// </summary>
            public Process[] External => (Process[]) GetFormList(FormType.External);

            /// <summary>
            ///     Obtem a lista de janela.
            /// </summary>
            /// <param name="type">Tipo da janela.</param>
            /// <returns>Lista das janelas.</returns>
            private object GetFormList(FormType type)
            {
                UpdateFormList();
                UpdateExternalList();
                return _forms[type];
            }

            /// <summary>
            ///     Atualiza a lista de janelas.
            /// </summary>
            private void UpdateFormList()
            {
                if (_lastApplicationFormCount == Application.OpenForms.Count) return;
                _lastApplicationFormCount = Application.OpenForms.Count;

                var forms = Application.OpenForms.Cast<Form>().ToArray();
                var lockScreen = forms.Where(a => a.Tag == _markToFormLockScreen).ToArray();
                var layout = forms.Where(a => a is IFormLayout).ToArray();

                _forms[FormType.Internal] = forms;
                _forms[FormType.LockScreen] = lockScreen;
                _forms[FormType.Layout] = layout;
            }

            /// <summary>
            ///     Atualiza a lista de processos.
            /// </summary>
            private void UpdateExternalList()
            {
                const int intervalMilliseconds = 1000;
                if (_stopwatch.ElapsedMilliseconds % intervalMilliseconds != 0 &&
                    _forms.ContainsKey(FormType.External)) return;

                _forms[FormType.External] = Process
                    .GetProcesses()
                    .Where(process => process.MainWindowHandle != IntPtr.Zero)
                    .OrderBy(process => process.MainWindowHandle.GetWindowZOrder())
                    .ToArray();
            }

            /// <summary>
            ///     Tipos de janelas.
            /// </summary>
            private enum FormType
            {
                /// <summary>
                /// Todas as janelas.
                /// </summary>
                Internal,
                
                /// <summary>
                ///     Janela de bloqueio.
                /// </summary>
                LockScreen,

                /// <summary>
                ///     Janelas de layout.
                /// </summary>
                Layout,

                /// <summary>
                ///     Janelas externas.
                /// </summary>
                External
            }
        }
    }
}