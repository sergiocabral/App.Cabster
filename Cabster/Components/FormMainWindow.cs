using System;
using System.Threading;
using Cabster.Business.Messenger.Command;
using Cabster.Business.Messenger.Event;
using Cabster.Extensions;
using Merq;

namespace Cabster.Components
{
    /// <summary>
    ///     Janela invisível.
    /// </summary>
    public partial class FormMainWindow : FormBase, ICommandHandler<SinalizeApplicationClock>
    {
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
            if (command.Count == 1) CommandBus.Execute(new InitializeApplication());

            EventStream.Push(new ApplicationClockSignaled(command));
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
        private void timer_Tick(object sender, EventArgs args)
        {
            timer.Enabled = false;
            try
            {
                CommandBus.Execute(new SinalizeApplicationClock());
            }
            finally
            {
                if (Program.SignalToTerminate) Close();
                else timer.Enabled = true;
            }
        }
    }
}