using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Cabster.Properties;
using Serilog;
using Serilog.Enrichers;
using Serilog.Events;
using Serilog.Exceptions.Core;

namespace Cabster.Helpers
{
    /// <summary>
    ///     Inicializa o Logger
    /// </summary>
    public static class LoggerConfiguration
    {
        /// <summary>
        ///     Inicializa o Logger do Drake.
        /// </summary>
        /// <param name="minimumLevel">Nível mínimo para captura do log.</param>
        public static void Initialize(LogEventLevel minimumLevel = LogEventLevel.Verbose)
        {
            var destinations = new List<Func<Serilog.LoggerConfiguration, Serilog.LoggerConfiguration>>
            {
                WriteToConsole,
                WriteToFile
            };

            var loggerConfiguration = ConfigureLogger();

            foreach (var writeTo in destinations)
                writeTo(loggerConfiguration)
                    .MinimumLevel.Is(minimumLevel);

            Log.Logger = loggerConfiguration.CreateLogger();

            Log.Verbose("Logger configured for {Destinations} and initialized.",
                destinations.Select(a => 
                    a.Method.Name.Replace("WriteTo", string.Empty)));
        }

        /// <summary>
        ///     Configura o logger.
        /// </summary>
        private static Serilog.LoggerConfiguration ConfigureLogger()
        {
            return new Serilog.LoggerConfiguration()
                .MinimumLevel.Verbose()
                .Enrich.WithProperty("Application", Resources.Name_System)
                .Enrich.WithProperty("Id", Guid.NewGuid())
                .Enrich.With<MachineNameEnricher>()
                .Enrich.With<EnvironmentUserNameEnricher>()
                .Enrich.With<ExceptionEnricher>()
                .Enrich.FromLogContext();
        }

        /// <summary>
        ///     Configura o Logger para escrever em: Console.
        /// </summary>
        /// <param name="loggerConfiguration">LoggerConfiguration</param>
        /// <returns>Mesma instância de entrada.</returns>
        private static Serilog.LoggerConfiguration WriteToConsole(Serilog.LoggerConfiguration loggerConfiguration)
        {
            return loggerConfiguration.WriteTo.Console();
        }

        /// <summary>
        ///     Configura o Logger para escrever em: File.
        /// </summary>
        /// <param name="loggerConfiguration">LoggerConfiguration</param>
        /// <returns>Mesma instância de entrada.</returns>
        private static Serilog.LoggerConfiguration WriteToFile(Serilog.LoggerConfiguration loggerConfiguration)
        {
            return loggerConfiguration.WriteTo.File($"{Assembly.GetEntryAssembly()?.Location}-log.txt");
        }
    }
}