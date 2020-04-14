using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cabster.Components;
using Cabster.Infrastructure;
using Cabster.Properties;
using Serilog;

namespace Cabster.Business
{
    /// <summary>
    ///     Bloqueador de telas.
    /// </summary>
    // ReSharper disable once ClassNeverInstantiated.Global
    public class ScreenBlocker : IScreenBlocker
    {
        /// <summary>
        ///     Marca para sinalizar que um form é um bloqueador de telas.
        /// </summary>
        private static readonly object MarkToFormBlocker = new object();

        /// <summary>
        ///     Construtor.
        /// </summary>
        public ScreenBlocker()
        {
            this.LogClassInstantiate();
        }

        /// <summary>
        ///     Determina se as telas estão bloqueada.
        /// </summary>
        public bool IsBlocked { get; private set; }

        /// <summary>
        ///     Bloqueia todas as telas.
        /// </summary>
        public void Block()
        {
            foreach (var screen in Screen.AllScreens) CreateForm(screen);

            var formsLayout = Application
                .OpenForms
                .Cast<Form>()
                .Where(a => a is IFormLayout)
                .ToArray();

            foreach (var form in formsLayout) form.TopMost = true;
            foreach (var form in formsLayout) form.Deactivate += FormLayoutOnDeactivate;

            IsBlocked = true;
        }

        /// <summary>
        ///     Desbloqueia todas as telas.
        /// </summary>
        public void Unblock()
        {
            foreach (Form form in Application.OpenForms)
            {
                form.Activated -= FormLayoutOnDeactivate;
                form.Deactivate -= FormLayoutOnDeactivate;
                form.TopMost = false;
                if (form.Tag != MarkToFormBlocker) continue;
                form.Hide();
                form.Close();
                Application.DoEvents();
            }

            IsBlocked = false;
        }

        /// <summary>
        ///     Cria uma janela que bloqueia a tela.
        /// </summary>
        /// <param name="screen">Tela.</param>
        private static void CreateForm(Screen screen)
        {
            var form = CreateForm();
            form.Left = screen.Bounds.X;
            form.Top = screen.Bounds.Y;
            form.Width = screen.Bounds.Width;
            form.Height = screen.Bounds.Height;
            form.Show();
            Application.DoEvents();
            
            Log.Debug(
                "Showing screen blocker (Left: {Left}, Top: {Top}, Width: {Width}, Height: {Height}).",
                form.Left, form.Top, form.Width, form.Height);
        }

        /// <summary>
        ///     Cria uma janela padrão.
        /// </summary>
        /// <returns></returns>
        private static Form CreateForm()
        {
            var form = new FormBase
            {
                Tag = MarkToFormBlocker,
                ShowInTaskbar = false,
                TopMost = true,
                StartPosition = FormStartPosition.Manual,
                Text = Resources.Name_Application,
                FormBorderStyle = FormBorderStyle.None,
                BackColor = Color.Black,
                BackgroundImage = Resources.FormBlockBackground,
                Opacity = 0.015
            };
            form.Activated += FormLayoutOnDeactivate;
            form.Deactivate += FormLayoutOnDeactivate;
            form.Closing += FormOnClosing;
            return form;
        }

        /// <summary>
        /// Sinaliza que as janelas estão tendo suas posições calculadas.
        /// </summary>
        private static bool _formsCalculating;

        /// <summary>
        /// Ao sair da janela.
        /// </summary>
        /// <param name="sender">Fonte do evento.</param>
        /// <param name="args">Informações do evento.</param>
        private static void FormLayoutOnDeactivate(object sender, EventArgs args)
        {
            if (_formsCalculating) return;
            _formsCalculating = true;
            Application.DoEvents();

            new Timer
            {
                Interval = 1,
                Enabled = true
            }.Tick += (sender2, args2) =>
            {
                ((Timer) sender2).Enabled = false;
                ((Timer) sender2).Dispose();

                var forms = Application.OpenForms.Cast<Form>().ToArray();

                foreach (var formBlocker in forms
                    .Where(a => a.Tag == MarkToFormBlocker))
                    formBlocker.BringToFront();

                var formsLayout = forms
                    .Where(a => a is IFormLayout)
                    .OrderBy(a => ((IFormLayout) a).ZOrder)
                    .ToArray();
                
                foreach (var formLayout in formsLayout)
                {
                    formLayout.BringToFront();
                    Application.DoEvents();
                }
                
                formsLayout.Last().Activate();

                _formsCalculating = false;
            };
        }

        /// <summary>
        ///     Evento ao fechar a janela.
        /// </summary>
        /// <param name="sender">Fonte do evento.</param>
        /// <param name="args">Informações do evento.</param>
        private static void FormOnClosing(object sender, CancelEventArgs args)
        {
            var form = (Form) sender;
            args.Cancel = !form.Visible;
        }
    }
}