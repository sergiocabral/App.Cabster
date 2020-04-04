using System;
using System.Windows.Forms;
using Cabster.Business.Messenger.Command;
using Cabster.Business.Messenger.Event;
using Cabster.Exceptions;
using Cabster.Extensions;
using Merq;
using Serilog;

namespace Cabster.Components
{
    /// <summary>
    ///     Janela principal da aplicação.
    /// </summary>
    public partial class FormMainWindow :
        FormBase,
        ICommandHandler<SinalizeApplicationClock>,
        IObserver<ApplicationInitialized>
    {
        /// <summary>
        ///     Timer para clock da aplicação.
        /// </summary>
        private Timer? _timerClock;

        /// <summary>
        ///     Construtor.
        /// </summary>
        public FormMainWindow()
        {
            InitializeComponent();
            InitializeComponent2();
        }

        /// <summary>
        ///     Determina se o comando pode ser executado.
        /// </summary>
        /// <param name="command">Comando.</param>
        /// <returns>Resposta.</returns>
        public bool CanExecute(SinalizeApplicationClock command)
        {
            return true;
        }

        /// <summary>
        ///     Execução do comando.
        /// </summary>
        /// <param name="command">Comando.</param>
        public void Execute(SinalizeApplicationClock command)
        {
            EventStream.Push(new ApplicationClockSignaled(command));
        }

        /// <summary>
        ///     Processamento do evento.
        /// </summary>
        /// <param name="value">Evento.</param>
        public void OnNext(ApplicationInitialized value)
        {
            if (_timerClock != null)
                throw new ExpectedSingleOperationException(nameof(ApplicationInitialized));

            _timerClock = new Timer
            {
                Interval = 100,
                Enabled = true
            };
            _timerClock.Tick += OnTimerTick;

            Log.Verbose("Clock started with {Interval} milliseconds interval.", _timerClock.Interval);
        }

        /// <summary>
        ///     Erro ao processar evento.
        /// </summary>
        /// <param name="error">Exception</param>
        public void OnError(Exception error)
        {
            //throw new ThisWillNeverOccurException();
        }

        /// <summary>
        ///     Processamento completo.
        /// </summary>
        public void OnCompleted()
        {
            //throw new ThisWillNeverOccurException();
        }

        /// <summary>
        ///     Inicializa os componentes da janela.
        /// </summary>
        private void InitializeComponent2()
        {
            this.MakeInvisible();
            EventStream.Of<ApplicationInitialized>().Subscribe(this);
        }

        /// <summary>
        ///     Clock de funcionamento da aplicação.
        /// </summary>
        /// <param name="sender">Fonte do evento.</param>
        /// <param name="args">Informações do evento.</param>
        private void OnTimerTick(object sender, EventArgs args)
        {
            ((Timer) sender).Enabled = false;
            try
            {
                var commandSinalizeApplicationClock = new SinalizeApplicationClock();
                CommandBus.Execute(commandSinalizeApplicationClock);

                Log.Verbose("Clock: {ClockTickCount}", commandSinalizeApplicationClock.TickCount);
            }
            finally
            {
                ((Timer) sender).Enabled = true;
            }
        }
    }
}