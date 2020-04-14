using System;
using System.Diagnostics;
using System.Globalization;
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
using LoggerConfiguration = Cabster.Infrastructure.LoggerConfiguration;

namespace Cabster
{
    /// <summary>
    ///     Classe principal
    /// </summary>
    public static class Program
    {
        /// <summary>
        ///     Indica se a aplicação está executando em modo Debug.
        /// </summary>
        public static bool? IsDebug;

        /// <summary>
        ///     Local para definir a instância DependencyResolver de uso comum.
        /// </summary>
        private static IDependencyResolver? _dependencyResolver;

        /// <summary>
        ///     Dados que configuram a aplicação.
        /// </summary>
        private static readonly ContainerData DataSource = new ContainerData();

        /// <summary>
        ///     Sinaliza se a aplicação deve ser reiniciada ao fechar.
        /// </summary>
        public static bool RestartWhenClose { get; set; }

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
#if DEBUG
            IsDebug = true;
#else
            IsDebug = false;
#endif

            var mainWindowHandle = Process.GetCurrentProcess().MainWindowHandle;
            WindowsApi.ShowWindow(mainWindowHandle, IsDebug == true);
            WindowsApi.FixCursorHand();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using var logger = LoggerConfiguration.Initialize(
                IsDebug == true || args.Contains("-vv") ? LogEventLevel.Verbose :
                args.Contains("-v") ? LogEventLevel.Debug :
                LogEventLevel.Information);

            Log.Logger = logger;

            do
            {
                RestartWhenClose = false;

                using var dependencyResolver = DependencyResolverConfiguration.Initialize();
                DependencyResolver = dependencyResolver;

                var messageBus = DependencyResolver.GetInstanceRequired<IMediator>();

                messageBus.Send(new DataLoadFromFile()).Wait();

                messageBus.Send(new ApplicationInitialize()).Wait();
            } while (RestartWhenClose);

            if (IsDebug == true && mainWindowHandle != IntPtr.Zero) Console.ReadKey();
        }
    }
}