using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cabster.Business.Forms;
using Cabster.Business.Messenger.Request;
using Cabster.Extensions;
using Cabster.Infrastructure;
using MediatR;

namespace Cabster.Business.Messenger.Handlers
{
    /// <summary>
    ///     Controlador de abertura de janelas.
    /// </summary>
    public class WindowHandler :
        MessengerHandler,
        IRequestHandler<WindowOpenGroupWork>,
        IRequestHandler<WindowOpenConfiguration>
    {
        /// <summary>
        ///     Lista de forms abertos.
        /// </summary>
        private static readonly List<int> FormsPositioned = new List<int>();

        /// <summary>
        ///     Resolvedor de dependências.
        /// </summary>
        private readonly IDependencyResolver _dependencyResolver;

        /// <summary>
        ///     Construtor.
        /// </summary>
        /// <param name="dependencyResolver">Resolvedor de dependências.</param>
        public WindowHandler(IDependencyResolver dependencyResolver)
        {
            _dependencyResolver = dependencyResolver;
        }

        /// <summary>
        ///     Processa o comando: WindowOpenConfiguration
        /// </summary>
        /// <param name="request">Comando</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Task</returns>
        public Task<Unit> Handle(WindowOpenConfiguration request, CancellationToken cancellationToken)
        {
            OpenWindows(_dependencyResolver.GetInstanceRequired<FormConfiguration>());
            return Unit.Task;
        }

        /// <summary>
        ///     Processa o comando: OpenFormGroupWork
        /// </summary>
        /// <param name="request">Comando</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Task</returns>
        public Task<Unit> Handle(WindowOpenGroupWork request, CancellationToken cancellationToken)
        {
            OpenWindows(_dependencyResolver.GetInstanceRequired<FormGroupWork>());
            return Unit.Task;
        }

        /// <summary>
        ///     Abrir uma janela.
        /// </summary>
        /// <param name="form">Janela.</param>
        private static void OpenWindows(Form form)
        {
            form.WindowState = FormWindowState.Normal;
            form.Show();

            var formHash = form.GetHashCode();
            var formPositioned = FormsPositioned.Contains(formHash);
            if (!formPositioned) FormsPositioned.Add(formHash);
            if (Application.OpenForms.Count > 0 && !formPositioned)
            {
                var mainForm = Application.OpenForms[0];
                var center = new Point(mainForm.Left + mainForm.Width / 2, mainForm.Top + mainForm.Height / 2);
                form.Left = center.X - form.Width / 2;
                form.Top = center.Y - form.Height / 2;
            }

            form.BringToFront();
            form.InvalidadeAll();
        }
    }
}