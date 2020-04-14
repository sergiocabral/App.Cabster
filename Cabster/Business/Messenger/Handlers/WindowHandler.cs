using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cabster.Business.Forms;
using Cabster.Business.Messenger.Notification;
using Cabster.Business.Messenger.Request;
using Cabster.Business.Values;
using Cabster.Components;
using Cabster.Extensions;
using Cabster.Infrastructure;
using MediatR;

namespace Cabster.Business.Messenger.Handlers
{
    /// <summary>
    ///     Controlador de abertura de janelas.
    /// </summary>
    // ReSharper disable once UnusedType.Global
    public class WindowHandler :
        MessengerHandler,
        IRequestHandler<WindowOpenMain, Form>,
        IRequestHandler<WindowOpenGroupWork>,
        IRequestHandler<WindowOpenConfiguration>,
        IRequestHandler<WindowOpenNotification>,
        INotificationHandler<ApplicationInitialized>,
        INotificationHandler<ApplicationFinalized>,
        INotificationHandler<DataUpdated>,
        INotificationHandler<UserNotificationPosted>
    {
        /// <summary>
        ///     Lista de forms abertos.
        /// </summary>
        private static List<int>? _formsPositioned;

        /// <summary>
        ///     Janela: FormMain
        /// </summary>
        private static Form? _formMainWindow;

        /// <summary>
        ///     Janela: FormGroupWork
        /// </summary>
        private static Form? _formGroupWork;

        /// <summary>
        ///     Janela: FormConfiguration
        /// </summary>
        private static Form? _formConfiguration;

        /// <summary>
        ///     Janela: FormNotification
        /// </summary>
        private static Form? _formNotification;

        /// <summary>
        ///     Barramento de mensagens.
        /// </summary>
        private readonly IMediator _messageBus;

        /// <summary>
        ///     Construtor.
        /// </summary>
        /// <param name="messageBus">Barramento de mensagens.</param>
        public WindowHandler(IMediator messageBus)
        {
            _messageBus = messageBus;
        }

        /// <summary>
        ///     Janela: FormMain
        /// </summary>
        private static Form FormMain =>
            _formMainWindow ??= Program.DependencyResolver.GetInstanceRequired<FormMain>();

        /// <summary>
        ///     Janela: FormGroupWork
        /// </summary>
        private static Form FormGroupWork =>
            _formGroupWork ??= Program.DependencyResolver.GetInstanceRequired<FormGroupWork>();

        /// <summary>
        ///     Janela: FormConfiguration
        /// </summary>
        private static Form FormConfiguration =>
            _formConfiguration ??= Program.DependencyResolver.GetInstanceRequired<FormConfiguration>();

        /// <summary>
        ///     Janela: FormNotification
        /// </summary>
        private static Form FormNotification =>
            _formNotification ??= Program.DependencyResolver.GetInstanceRequired<FormNotification>();

        /// <summary>
        ///     Evento: ApplicationFinalized
        /// </summary>
        /// <param name="notification">Evento.</param>
        /// <param name="cancellationToken">Token de cancelamento.</param>
        /// <returns>Task</returns>
        public Task Handle(ApplicationFinalized notification, CancellationToken cancellationToken)
        {
            FormMain.Close();

            var fields = GetType().GetFields(BindingFlags.Static | BindingFlags.NonPublic);
            foreach (var field in fields) field.SetValue(null, null);

            return Unit.Task;
        }

        /// <summary>
        ///     Evento: ApplicationInitialized
        /// </summary>
        /// <param name="notification">Evento.</param>
        /// <param name="cancellationToken">Token de cancelamento.</param>
        /// <returns>Task</returns>
        public Task Handle(ApplicationInitialized notification, CancellationToken cancellationToken)
        {
            _messageBus.Send(new WindowOpenGroupWork(), cancellationToken);
            return Unit.Task;
        }

        /// <summary>
        ///     Evento: DataUpdated
        /// </summary>
        /// <param name="notification">Evento.</param>
        /// <param name="cancellationToken">Token de cancelamento.</param>
        /// <returns>Task</returns>
        public Task Handle(DataUpdated notification, CancellationToken cancellationToken)
        {
            if ((notification.Request.Section & DataSection.Application) != 0)
                ((IFormContainerData?) _formConfiguration)?.UpdateControls();
            if ((notification.Request.Section & DataSection.WorkGroup) != 0)
                ((IFormContainerData?) _formGroupWork)?
                    .UpdateControls();
            return Unit.Task;
        }

        /// <summary>
        ///     Evento: DataUpdatedMessage
        /// </summary>
        /// <param name="notification">Evento.</param>
        /// <param name="cancellationToken">Token de cancelamento.</param>
        /// <returns>Task</returns>
        public Task Handle(UserNotificationPosted notification, CancellationToken cancellationToken)
        {
            if (notification.Request.SourceRequest is DataUpdate dataUpdate &&
                (dataUpdate.Section & DataSection.ApplicationShortcut) != 0)
                ((IFormLayout?) _formConfiguration)?
                    .SetStatusMessage(notification.Request.Message.Text, notification.Request.Message.Success);

            ((IFormContainerData?) _formNotification)?.UpdateControls();

            return Unit.Task;
        }

        /// <summary>
        ///     Processa o comando: WindowOpenConfiguration
        /// </summary>
        /// <param name="request">Comando</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Task</returns>
        public Task<Unit> Handle(WindowOpenConfiguration request, CancellationToken cancellationToken)
        {
            OpenWindow(FormConfiguration);
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
            OpenWindow(FormGroupWork);
            return Unit.Task;
        }

        /// <summary>
        ///     Processa o comando: WindowOpenMain
        /// </summary>
        /// <param name="request">Comando</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Task</returns>
        public Task<Form> Handle(WindowOpenMain request, CancellationToken cancellationToken)
        {
            return Task.FromResult(FormMain);
        }

        /// <summary>
        ///     Processa o comando: WindowOpenNotification
        /// </summary>
        /// <param name="request">Comando</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Task</returns>
        public Task<Unit> Handle(WindowOpenNotification request, CancellationToken cancellationToken)
        {
            OpenWindow(FormNotification);
            return Unit.Task;
        }

        /// <summary>
        ///     Abrir uma janela.
        /// </summary>
        /// <param name="formContainerData">Janela.</param>
        private static void OpenWindow(Form formContainerData)
        {
            var form = formContainerData;
            form.WindowState = FormWindowState.Normal;
            form.Show();

            var formHash = form.GetHashCode();
            if (_formsPositioned == null) _formsPositioned = new List<int>();
            var formPositioned = _formsPositioned.Contains(formHash);
            if (!formPositioned) _formsPositioned.Add(formHash);
            if (Application.OpenForms.Count > 0 && !formPositioned)
            {
                var mainForm = Application.OpenForms[0];
                var center = new Point(mainForm.Left + mainForm.Width / 2, mainForm.Top + mainForm.Height / 2);
                form.Left = center.X - form.Width / 2;
                form.Top = center.Y - form.Height / 2;
            }

            form.BringToFront();
            Application.DoEvents();
            form.InvalidadeAll();
        }
    }
}