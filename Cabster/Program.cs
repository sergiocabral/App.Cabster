using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Cabster.Business.Entities;
using Cabster.Business.Messenger.Request;
using Cabster.Exceptions;
using Cabster.Helpers;
using Cabster.Infrastructure;
using Cabster.Properties;
using MediatR;
using Serilog;
using Serilog.Events;
using Environment = Cabster.Infrastructure.Environment;
using LoggerConfiguration = Cabster.Infrastructure.LoggerConfiguration;

namespace Cabster
{
    /// <summary>
    ///     Classe principal
    /// </summary>
    public static class Program
    {
        /// <summary>
        ///     Dados que configuram a aplicação.
        /// </summary>
        private static readonly ContainerData DataSource = new ContainerData();

        /// <summary>
        ///     Local para definir a instância DependencyResolver de uso comum.
        /// </summary>
        private static IDependencyResolver? _dependencyResolver;

        /// <summary>
        ///     Dados que configuram a aplicação.
        /// </summary>
        public static ContainerData Data =>
            (ContainerData) DataSource.Clone();

        /// <summary>
        ///     DependencyResolver de uso comum.
        /// </summary>
        public static IDependencyResolver DependencyResolver
        {
            get => _dependencyResolver ??
                   throw new IsNullOrEmptyException($"{nameof(DependencyResolver)}.{nameof(DependencyResolver)}");
            private set => _dependencyResolver = value;
        }

        /// <summary>
        ///     Ponto de entrada do sistema operacional.
        /// </summary>
        [STAThread]
        public static void Main(params string[] args)
        {
            var mainWindowHandle = Process.GetCurrentProcess().MainWindowHandle;
            WindowsApi.ShowWindow(mainWindowHandle, Environment.IsDebug);
            WindowsApi.FixCursorHand();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using var logger = LoggerConfiguration.Initialize(
                Environment.IsDebug || args.Contains("-vv") ? LogEventLevel.Verbose :
                args.Contains("-v") ? LogEventLevel.Debug :
                LogEventLevel.Information);
            Log.Logger = logger;

            while (true)
            {
                using var dependencyResolver = DependencyResolverConfiguration.Initialize();
                DependencyResolver = dependencyResolver;

                var messageBus = DependencyResolver.GetInstanceRequired<IMediator>();

                messageBus.Send(new UserNotificationPost(
                    new NotificationMessage(Resources.Notification_ApplicationStarted))).Wait();

                messageBus.Send(new DataLoadFromFile()).Wait();

                var restart = messageBus.Send<bool>(new ApplicationInitialize());
                
                if (restart.Result)
                {
                    messageBus.Send(new UserNotificationPost(
                        new NotificationMessage(Resources.Notification_ApplicationFinished))).Wait();
                    
                    break;
                }

                messageBus.Send(new UserNotificationPost(
                    new NotificationMessage(Resources.Notification_ApplicationRestarting))).Wait();
            }

            if (Environment.IsDebug && mainWindowHandle != IntPtr.Zero) Console.ReadKey();
        }
    }
}