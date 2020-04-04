using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using Cabster.Business.Messenger.Notification;
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
            ButtonMinimizeClick += OnButtonMinimizeClick;
        }

        /// <summary>
        ///     Quando clica o botão de minimzar a janela.
        /// </summary>
        private void OnButtonMinimizeClick()
        {
        }

        /// <summary>
        ///     Quando clica o botão de fechar a janela.
        /// </summary>
        private void OnButtonCloseClick()
        {
        }
    }
}