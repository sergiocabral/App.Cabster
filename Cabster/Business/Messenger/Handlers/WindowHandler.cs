using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cabster.Business.Enums;
using Cabster.Business.Forms;
using Cabster.Business.Messenger.Notification;
using Cabster.Business.Messenger.Request;
using Cabster.Components;
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
        IRequestHandler<WindowOpenConfiguration>,
        INotificationHandler<DataUpdated>,
        INotificationHandler<DataUpdatedMessage>
    {
        /// <summary>
        ///     Lista de forms abertos.
        /// </summary>
        private static readonly List<int> FormsPositioned = new List<int>();

        /// <summary>
        /// Janela: FormGroupWork
        /// </summary>
        private static FormGroupWork? _formGroupWork;
        
        /// <summary>
        /// Janela: FormGroupWork
        /// </summary>
        private static IFormContainerData FormGroupWork =>
            _formGroupWork ??= Program.DependencyResolver.GetInstanceRequired<FormGroupWork>();

        /// <summary>
        /// Janela: FormConfiguration
        /// </summary>
        private static FormConfiguration? _formConfiguration;

        /// <summary>
        /// Janela: FormConfiguration
        /// </summary>
        private static IFormContainerData FormConfiguration =>
            _formConfiguration ??= Program.DependencyResolver.GetInstanceRequired<FormConfiguration>();

        /// <summary>
        ///     Processa o comando: WindowOpenConfiguration
        /// </summary>
        /// <param name="request">Comando</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Task</returns>
        public Task<Unit> Handle(WindowOpenConfiguration request, CancellationToken cancellationToken)
        {
            OpenWindows(FormConfiguration);
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
            OpenWindows(FormGroupWork);
            return Unit.Task;
        }

        /// <summary>
        ///     Abrir uma janela.
        /// </summary>
        /// <param name="form">Janela.</param>
        private static void OpenWindows(IFormContainerData formContainerData)
        {
            var form = (Form) formContainerData;
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

        /// <summary>
        /// Evento: DataUpdated
        /// </summary>
        /// <param name="notification">Evento.</param>
        /// <param name="cancellationToken">Token de cancelamento.</param>
        /// <returns>Task</returns>
        public Task Handle(DataUpdated notification, CancellationToken cancellationToken)
        {
            if ((notification.Request.Section & DataSection.Application) != 0) _formConfiguration?.UpdateControls();
            if ((notification.Request.Section & DataSection.WorkGroup) != 0) _formGroupWork?.UpdateControls();
            return Unit.Task;
        }

        /// <summary>
        /// Evento: DataUpdatedMessage
        /// </summary>
        /// <param name="notification">Evento.</param>
        /// <param name="cancellationToken">Token de cancelamento.</param>
        /// <returns>Task</returns>
        public Task Handle(DataUpdatedMessage notification, CancellationToken cancellationToken)
        {
            //TODO: Ao ligar tem que carregar os dados para quando não houver arquivos.
            //TODO: Exibir erros de startup.
            if ((notification.Request.Section & DataSection.ApplicationShortcut) != 0)
                _formConfiguration?.SetStatusMessage(notification.Message, notification.Success);

            return Unit.Task;
        }
    }
}