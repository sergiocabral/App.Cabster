using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cabster.Business.Messenger.Notification;
using Cabster.Business.Messenger.Request;
using Cabster.Components;
using MediatR;

#pragma warning disable 109

namespace Cabster.Business.Forms
{
    /// <summary>
    ///     Janela de trabalho em grupo.
    /// </summary>
    public partial class FormWorkGroup :
        FormLayout,
        INotificationHandler<ApplicationInitialized>
    {
        /// <summary>
        ///     Construtor.
        /// </summary>
        public FormWorkGroup()
        {
            InitializeComponent();
            InitializeComponent2();
        }

        /// <summary>
        ///     Processa o evento: ApplicationInitialized
        /// </summary>
        /// <param name="notification">Evento.</param>
        /// <param name="cancellationToken">Token.</param>
        /// <returns>Task</returns>
        public new Task Handle(ApplicationInitialized notification, CancellationToken cancellationToken)
        {
            Show();
            return Unit.Task;
        }

        /// <summary>
        ///     Inicializa os componentes da janela.
        /// </summary>
        [ExcludeFromCodeCoverage]
        private void InitializeComponent2()
        {
            ButtonCloseClick += OnButtonCloseClick;
        }

        /// <summary>
        ///     Quando clica o botão de fechar a janela.
        /// </summary>
        private void OnButtonCloseClick()
        {
            MessengerBus.Send(new FinalizeApplication());
        }
    }
}