using System;
using System.Threading.Tasks;
using Cabster.Business.Messenger.Request;
using Cabster.Extensions;
using Serilog;

namespace Cabster.Components
{
    /// <summary>
    ///     Janela principal da aplicação.
    /// </summary>
    public partial class FormMain : FormBase
    {
        /// <summary>
        ///     Sinaliza que a aplicação foi inicializada.
        /// </summary>
        private bool _applicationInitialized;

        /// <summary>
        ///     Sinaliza que o clock está trabalhando.
        /// </summary>
        private bool _timerWorking;

        /// <summary>
        ///     Construtor.
        /// </summary>
        public FormMain()
        {
            InitializeComponent();
            InitializeComponent2();
        }

        /// <summary>
        ///     Inicializa os componentes da janela.
        /// </summary>
        private void InitializeComponent2()
        {
            this.MakeInvisible();
            Task.Run(() =>
            {
                _applicationInitialized = true;
                Log.Debug("Clock started with {Interval} milliseconds interval.", timer.Interval);
            });
        }

        /// <summary>
        ///     Clock de funcionamento da aplicação.
        /// </summary>
        /// <param name="sender">Fonte do evento.</param>
        /// <param name="args">Informações do evento.</param>
        private void OnTimerTick(object sender, EventArgs args)
        {
            if (!_applicationInitialized) return;
            if (_timerWorking) return;
            _timerWorking = true;

            try
            {
                var requestSinalizeApplicationClock = new ClockSinalize();
                MessageBus.Send(requestSinalizeApplicationClock);

                if (requestSinalizeApplicationClock.TickCount % 1000 == 0 ||
                    requestSinalizeApplicationClock.TickCount == 1)
                    Log.Verbose("Clock: {ClockTickCount}",
                        requestSinalizeApplicationClock.TickCount);
            }
            finally
            {
                _timerWorking = false;
            }
        }
    }
}