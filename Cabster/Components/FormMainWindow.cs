﻿using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Cabster.Business.Messenger.Notification;
using Cabster.Business.Messenger.Request;
using Cabster.Exceptions;
using Cabster.Extensions;
using MediatR;
using Serilog;
using Timer = System.Windows.Forms.Timer;

namespace Cabster.Components
{
    /// <summary>
    ///     Janela principal da aplicação.
    /// </summary>
    public partial class FormMainWindow : FormBase
    {
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

        /// <summary>
        ///     Inicializa os componentes da janela.
        /// </summary>
        private void InitializeComponent2()
        {
            this.MakeInvisible();
            Task.Run(() =>
            {
                _applicationInitialized = true;
                Log.Verbose("Clock started with {Interval} milliseconds interval.", timer.Interval);
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
            
            ((Timer) sender).Enabled = false;

            try
            {
                var requestSinalizeApplicationClock = new SinalizeApplicationClock();
                MessageBus.Send(requestSinalizeApplicationClock);

                if (requestSinalizeApplicationClock.TickCount % 1000 == 0 ||
                    requestSinalizeApplicationClock.TickCount == 1)
                    Log.Verbose("Clock: {ClockTickCount}",
                            requestSinalizeApplicationClock.TickCount);
            }
            finally
            {
                ((Timer) sender).Enabled = true;
            }
        }
    }
}