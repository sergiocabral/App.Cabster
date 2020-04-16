using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Cabster.Components;
using Cabster.Extensions;
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

            _timer = new Timer
            {
                Interval = 1,
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
            IsLocked = true;

            foreach (var screen in Screen.AllScreens)
                CreateForm(screen);

            foreach (var form in Application.OpenForms.Cast<Form>().Where(a => a is IFormLayout))
                form.TopMost = true;
        }

        /// <summary>
        ///     Desbloqueia todas as telas.
        /// </summary>
        public void Unlock()
        {
            if (!IsLocked) return;
            IsLocked = false;

            foreach (var form in Application.OpenForms.Cast<Form>().ToArray())
            {
                form.TopMost = false;
                if (form.Tag != _markToFormLockScreen) continue;
                form.Hide();
                form.Close();
                Application.DoEvents();
            }
        }

        /// <summary>
        ///     Temporizador para manter as janelas no topo.
        /// </summary>
        /// <param name="sender">Fonte do evento.</param>
        /// <param name="args">Informações sobre o evento.</param>
        private static void TimerOnTick(object sender, EventArgs args)
        {
            var timer = (Timer) sender;
            timer.Enabled = false;
            try
            {
                var forms = Application.OpenForms.Cast<Form>().ToArray();

                if (forms.Length == 0 || forms.Any(a => a.ContainsFocus)) return;

                foreach (var form in forms.OrderBy(a => a.Handle.GetWindowZOrder()))
                {
                    form.Activate();
                    form.BringToFront();
                }

                Log.Verbose("Lock screen activated.");
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
                TopMost = false,
                StartPosition = FormStartPosition.Manual,
                Text = Resources.Name_Application,
                FormBorderStyle = FormBorderStyle.None,
                BackColor = Color.Black,
                BackgroundImage = Resources.FormLockScreenBackground,
                Opacity = 0.02
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
    }
}