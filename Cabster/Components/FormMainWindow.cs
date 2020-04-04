using System;
using System.Threading;
using System.Threading.Tasks;
using Cabster.Business.Messenger.Notification;
using Cabster.Business.Messenger.Request;
using Cabster.Exceptions;
using Cabster.Extensions;
using MediatR;
using Serilog;
using Timer = System.Windows.Forms.Timer;

#pragma warning disable 109

namespace Cabster.Components
{
    /// <summary>
    ///     Janela principal da aplicação.
    /// </summary>
    public partial class FormMainWindow :
        FormBase,
        IRequestHandler<SinalizeApplicationClock>,
        IRequestHandler<FinalizeApplication>,
        INotificationHandler<ApplicationInitialized>
    {
        /// <summary>
        ///     Sinaliza que a aplicação foi finalizada.
        /// </summary>
        private bool _applicationFinalized;

        /// <summary>
        ///     Sinaliza que a aplicação foi inicializada.
        /// </summary>
        private bool _applicationInitialized;

        /// <summary>
        ///     Construtor.
        /// </summary>
        public FormMainWindow()
        {
            InitializeComponent();
            InitializeComponent2();
        }

        public new Task Handle(ApplicationInitialized notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                if (_applicationInitialized)
                    throw new ExpectedSingleOperationException(nameof(ApplicationInitialized));

                _applicationInitialized = true;

                Log.Verbose("Clock started with {Interval} milliseconds interval.", timer.Interval);
            }, cancellationToken);
        }

        /// <summary>
        ///     Processa o comando: FinalizeApplication
        /// </summary>
        /// <param name="request">Comando</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Task</returns>
        public new Task<Unit> Handle(FinalizeApplication request, CancellationToken cancellationToken)
        {
            _applicationFinalized = true;
            return Unit.Task;
        }

        /// <summary>
        ///     Processa o comando: SinalizeApplicationClock
        /// </summary>
        /// <param name="request">Comando</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Task</returns>
        public new Task<Unit> Handle(SinalizeApplicationClock request, CancellationToken cancellationToken)
        {
            Mediator.Publish(new ApplicationClockSignaled(request), cancellationToken);

            if (request.TickCount == 10) Mediator.Send(new FinalizeApplication(), cancellationToken);

            return Unit.Task;
        }

        /// <summary>
        ///     Inicializa os componentes da janela.
        /// </summary>
        private void InitializeComponent2()
        {
            this.MakeInvisible();
        }

        /// <summary>
        ///     Clock de funcionamento da aplicação.
        /// </summary>
        /// <param name="sender">Fonte do evento.</param>
        /// <param name="args">Informações do evento.</param>
        private void OnTimerTick(object sender, EventArgs args)
        {
            if (!_applicationInitialized) return;

            ((Timer) sender).Enabled = false;

            if (_applicationFinalized)
            {
                Close();
                return;
            }

            try
            {
                var requestSinalizeApplicationClock = new SinalizeApplicationClock();
                Mediator.Send(requestSinalizeApplicationClock);

                Log.Verbose("Clock: {ClockTickCount}", requestSinalizeApplicationClock.TickCount);
            }
            finally
            {
                ((Timer) sender).Enabled = true;
            }
        }
    }
}