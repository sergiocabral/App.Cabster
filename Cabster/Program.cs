using System;
using System.Windows.Forms;
using Cabster.Business.Messenger.Command;
using Cabster.Components;
using Cabster.Exceptions;
using Cabster.Helpers;
using Cabster.Infrastructure;
using Merq;
using Serilog;
using LoggerConfiguration = Cabster.Infrastructure.LoggerConfiguration;

namespace Cabster
{
    /// <summary>
    ///     Classe principal
    /// </summary>
    public static class Program
    {
        /// <summary>
        ///     Local para definir a instância DependencyResolver de uso comum.
        /// </summary>
        private static IDependencyResolver? _dependencyResolver;

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
        public static void Main()
        {
#if DEBUG
            WindowsApi.AllocConsole();
#endif
            WindowsApi.FixCursorHand();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using var logger = LoggerConfiguration.Initialize();
            Log.Logger = logger;

            using var dependencyResolver = DependencyResolverConfiguration.Initialize();
            DependencyResolver = dependencyResolver;

            MessengerConfiguration.Initialize(dependencyResolver);
            var commandBus = DependencyResolver.GetInstanceRequired<ICommandBus>();

            var mainForm = DependencyResolver.GetInstanceRequired<FormMainWindow>();

            commandBus.Execute(new InitializeApplication());
            
            Application.Run(mainForm);
        }
    }
}