using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
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
    public class LockScreen : ILockScreen
    {
        /// <summary>
        ///     Marca para sinalizar que um form é um bloqueador de telas.
        /// </summary>
        private static readonly object MarkToFormLockScreen = new object();

        /// <summary>
        ///     Sinaliza que as janelas estão tendo suas posições calculadas.
        /// </summary>
        private static bool _formsCalculating;

        /// <summary>
        ///     Lista de forms configurados.
        /// </summary>
        private static readonly List<int> FormsConfigured = new List<int>();

        /// <summary>
        ///     Construtor.
        /// </summary>
        public LockScreen()
        {
            this.LogClassInstantiate();
        }

        /// <summary>
        ///     Determina se as telas estão bloqueada.
        /// </summary>
        public bool IsLocked { get; private set; }

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

            foreach (var form in formsLayout) form.TopMost = true;
            SetFormEventHandlers(true);

            IsLocked = true;
        }

        /// <summary>
        ///     Desbloqueia todas as telas.
        /// </summary>
        public void Unlock()
        {
            if (!IsLocked) return;
            
            SetFormEventHandlers(false);
            foreach (var form in Application.OpenForms.Cast<Form>().ToArray())
            {
                form.TopMost = false;
                if (form.Tag != MarkToFormLockScreen) continue;
                form.Hide();
                form.Close();
                Application.DoEvents();
            }

            IsLocked = false;
        }

        /// <summary>
        ///     Define os handlers para os eventos das janelas.
        /// </summary>
        /// <param name="mode">Ativar ou desativar</param>
        private static void SetFormEventHandlers(bool mode)
        {
            foreach (Form form in Application.OpenForms)
            {
                var hash = form.GetHashCode();
                if (mode && !FormsConfigured.Contains(hash))
                {
                    FormsConfigured.Add(hash);
                    
                    // TODO: Melhorar usabilidade
                    
                    form.Activated += FormLayoutOnDeactivate;
                    form.Deactivate += FormLayoutOnDeactivate;
                    form.GotFocus += FormLayoutOnDeactivate;
                    form.LostFocus += FormLayoutOnDeactivate;
                }
                else if (!mode && FormsConfigured.Contains(hash))
                {
                    form.Activated -= FormLayoutOnDeactivate;
                    form.Deactivate -= FormLayoutOnDeactivate;
                    form.GotFocus -= FormLayoutOnDeactivate;
                    form.LostFocus -= FormLayoutOnDeactivate;
                    FormsConfigured.Remove(hash);
                }
            }
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

            Log.Debug(
                "Lock screen created for area: Left: {Left}, Top: {Top}, Width: {Width}, Height: {Height}.",
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
                Tag = MarkToFormLockScreen,
                ShowInTaskbar = false,
                TopMost = true,
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
        ///     Ao sair da janela.
        /// </summary>
        /// <param name="sender">Fonte do evento.</param>
        /// <param name="args">Informações do evento.</param>
        private static void FormLayoutOnDeactivate(object sender, EventArgs args)
        {
            if (_formsCalculating) return;
            _formsCalculating = true;
            Application.DoEvents();

            SetFormEventHandlers(true);

            new Timer
            {
                Interval = 1,
                Enabled = true
            }.Tick += (sender2, args2) =>
            {
                ((Timer) sender2).Enabled = false;
                ((Timer) sender2).Dispose();

                var forms = Application.OpenForms.Cast<Form>().ToArray();

                foreach (var formLockerScreen in forms
                    .Where(a => a.Tag == MarkToFormLockScreen))
                    formLockerScreen.BringToFront();

                var formsLayout = forms
                    .Where(a => a is IFormLayout)
                    .OrderBy(a => ((IFormLayout) a).ZOrder)
                    .ToArray();

                foreach (var formLayout in formsLayout)
                {
                    formLayout.BringToFront();
                    Application.DoEvents();
                }

                formsLayout.LastOrDefault()?.Activate();

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
            args.Cancel = form.Visible;
        }
    }
}