using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cabster.Business.Forms;
using Cabster.Business.Messenger.Notification;
using Cabster.Business.Messenger.Request;
using Cabster.Extensions;
using Cabster.Infrastructure;
using MediatR;

namespace Cabster.Business.Messenger.RequestHandlers
{
    /// <summary>
    ///     Controlador de abertura de janelas.
    /// </summary>
    public class OpenForms :
        MessengerHandler,
        IRequestHandler<OpenFormGroupWork>,
        IRequestHandler<OpenFormConfiguration>
    {
        /// <summary>
        ///     Resolvedor de dependências.
        /// </summary>
        private readonly IDependencyResolver _dependencyResolver;

        /// <summary>
        ///     Construtor.
        /// </summary>
        /// <param name="dependencyResolver">Resolvedor de dependências.</param>
        public OpenForms(IDependencyResolver dependencyResolver)
        {
            _dependencyResolver = dependencyResolver;
        }

        /// <summary>
        ///     Processa o comando: OpenFormConfiguration
        /// </summary>
        /// <param name="request">Comando</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Task</returns>
        public Task<Unit> Handle(OpenFormConfiguration request, CancellationToken cancellationToken)
        {
            OpenForm(_dependencyResolver.GetInstanceRequired<FormConfiguration>());
            return Unit.Task;
        }

        /// <summary>
        ///     Processa o comando: OpenFormGroupWork
        /// </summary>
        /// <param name="request">Comando</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Task</returns>
        public Task<Unit> Handle(OpenFormGroupWork request, CancellationToken cancellationToken)
        {
            OpenForm(_dependencyResolver.GetInstanceRequired<FormGroupWork>());
            return Unit.Task;
        }

        /// <summary>
        ///     Abrir uma janela.
        /// </summary>
        /// <param name="form">Janela.</param>
        private static void OpenForm(Form form)
        {
            form.WindowState = FormWindowState.Normal;
            form.Show();
            form.BringToFront();
            form.InvalidadeAll();
        }
    }
}