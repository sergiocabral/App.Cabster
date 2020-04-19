using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cabster.Business.Forms;
using Cabster.Business.Messenger.Notification;
using Cabster.Business.Messenger.Request;
using Cabster.Business.Values;
using Cabster.Components;
using Cabster.Exceptions;
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
        IRequestHandler<WindowOpen, IDictionary<Window, Form>>,
        IRequestHandler<WindowClose>,
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
        private static Form? _formMain;

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
        ///     Lista de tipos de janelas.
        /// </summary>
        private static readonly Window[] _windowsType =
            Enum
                .GetNames(typeof(Window))
                .Select(a =>
                    (Window) Enum.Parse(typeof(Window), a))
                .ToArray();

        /// <summary>
        ///     Bloqueador de telas.
        /// </summary>
        private readonly ILockScreen _lockScreen;

        /// <summary>
        ///     Barramento de mensagens.
        /// </summary>
        private readonly IMediator _messageBus;

        /// <summary>
        ///     Construtor.
        /// </summary>
        /// <param name="messageBus">Barramento de mensagens.</param>
        /// <param name="lockScreen">Bloqueador de telas.</param>
        public WindowHandler(
            IMediator messageBus,
            ILockScreen lockScreen)
        {
            _messageBus = messageBus;
            _lockScreen = lockScreen;
        }

        /// <summary>
        ///     Janela: FormMain
        /// </summary>
        private static Form FormMain =>
            _formMain ??= Program.DependencyResolver.GetInstanceRequired<FormMain>();

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
        public async Task Handle(ApplicationInitialized notification, CancellationToken cancellationToken)
        {
            const Window formType = Window.GroupWork;
            var forms = await _messageBus.Send<IDictionary<Window, Form>>(
                new WindowOpen(formType), cancellationToken);
            var form = forms[formType];

            ((IFormLayout) form).NotUseEscToClose = true;
            ((IFormLayout) form).ShowButtonMinimize = true;

            var lockScreen = false;
            form.SizeChanged += (sender, args) =>
            {
                if (form.WindowState == FormWindowState.Minimized)
                {
                    foreach (var formLayout in Application
                        .OpenForms
                        .Cast<Form>()
                        .Where(a => a != form && a is IFormLayout)
                        .ToArray())
                        formLayout.Hide();

                    lockScreen = _lockScreen.IsLocked;
                    if (lockScreen) _lockScreen.Unlock();
                }
                else if (lockScreen)
                {
                    _lockScreen.Lock();
                    lockScreen = false;
                }
            };
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
                ((IFormContainerData?) _formConfiguration)?.UpdateControls(notification.Request.Data);
            if ((notification.Request.Section & DataSection.WorkGroup) != 0)
                ((IFormContainerData?) _formGroupWork)?.UpdateControls(notification.Request.Data);
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
                ((dataUpdate.Section & DataSection.ApplicationShortcut) != 0 ||
                 (dataUpdate.Section & DataSection.ApplicationLockScreen) != 0))
                ((IFormLayout?) _formConfiguration)?
                    .SetStatusMessage(notification.Request.Message.Text, notification.Request.Message.Success);

            ((IFormContainerData?) _formNotification)?.UpdateControls(null);

            return Unit.Task;
        }

        /// <summary>
        ///     Processa o comando: WindowClose
        /// </summary>
        /// <param name="request">Comando</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Task</returns>
        public Task<Unit> Handle(WindowClose request, CancellationToken cancellationToken)
        {
            var windowTypes = GetWindowsTypeOrdered(request.Window, request.OrderBy);
            foreach (var windowType in windowTypes)
            {
                var form = GetInstance(windowType).Item1;
                form?.Hide();
            }

            return Unit.Task;
        }

        /// <summary>
        ///     Processa o comando: WindowOpenConfiguration
        /// </summary>
        /// <param name="request">Comando</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Task</returns>
        public Task<IDictionary<Window, Form>> Handle(WindowOpen request, CancellationToken cancellationToken)
        {
            var windowTypes = GetWindowsTypeOrdered(request.Window, request.OrderBy);
            var result = (IDictionary<Window, Form>) windowTypes
                .ToDictionary(
                    windowType => windowType,
                    windowType => OpenWindow(GetInstance(windowType).Item2(), request.Parent));
            return Task.FromResult(result);
        }

        /// <summary>
        ///     Monta uma lista de tipos de janela na ordem em que devem ser acessadas.
        /// </summary>
        /// <param name="selected">Tipos selecionados.</param>
        /// <param name="orderBy">Ordem de acesso aos tipos.</param>
        /// <returns>Lista filtrada e na ordem esperada.</returns>
        private static IEnumerable<Window> GetWindowsTypeOrdered(Window selected, IReadOnlyCollection<Window> orderBy)
        {
            var windowsType = _windowsType.Where(a => (a & selected) != 0);

            if (orderBy == null || orderBy.Count <= 0) return windowsType;

            var orderByList = orderBy.ToList();
            windowsType = windowsType
                .OrderBy(windowType =>
                {
                    var indexOf = orderByList.IndexOf(windowType);
                    return indexOf < 0 ? int.MaxValue : indexOf;
                });

            return windowsType;
        }

        /// <summary>
        ///     Retorna uma instância de janela para um tipo.
        /// </summary>
        /// <param name="window">Tipo de janela.</param>
        /// <returns>Instância do Form.</returns>
        private static (Form, Func<Form>) GetInstance(Window window)
        {
            return window switch
            {
                Window.Main => (_formMain, () => FormMain),
                Window.GroupWork => (_formGroupWork, () => FormGroupWork),
                Window.Configuration => (_formConfiguration, () => FormConfiguration),
                Window.Notification => (_formNotification, () => FormNotification),
                _ => throw new ThisWillNeverOccurException()
            };
        }

        /// <summary>
        ///     Abrir uma janela.
        /// </summary>
        /// <param name="form">Janela.</param>
        /// <param name="formParent">Janela pai.</param>
        /// <returns>Mesma instância de entrada.</returns>
        private static Form OpenWindow(Form form, Form? formParent)
        {
            if (form == FormMain) return form;

            form.WindowState = FormWindowState.Normal;
            form.Show();

            var formHash = form.GetHashCode();
            if (_formsPositioned == null) _formsPositioned = new List<int>();
            var formPositioned = _formsPositioned.Contains(formHash);
            if (!formPositioned) _formsPositioned.Add(formHash);
            if (Application.OpenForms.Count > 0 && !formPositioned)
            {
                var mainForm = formParent ?? Application.OpenForms[0];
                var center = new Point(mainForm.Left + mainForm.Width / 2, mainForm.Top + mainForm.Height / 2);
                form.Left = center.X - form.Width / 2;
                form.Top = center.Y - form.Height / 2;
            }

            form.BringToFront();
            Application.DoEvents();
            form.InvalidadeAll();

            return form;
        }
    }
}