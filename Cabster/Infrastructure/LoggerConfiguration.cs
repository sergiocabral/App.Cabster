using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Cabster.Business;
using Cabster.Exceptions;
using Cabster.Properties;
using Serilog;
using Serilog.Core;
using Serilog.Enrichers;
using Serilog.Events;
using Serilog.Exceptions.Core;

namespace Cabster.Infrastructure
{
    /// <summary>
    ///     Inicializa o Logger
    /// </summary>
    public static class LoggerConfiguration
    {
        /// <summary>
        ///     Registra um log nível Verbose para sinalizar que uma instância foi criada.
        /// </summary>
        /// <param name="instance">Instância.</param>
        public static void LogClassInstantiate<T>(this T instance) where T : notnull
        {
            var typeOfInstance = instance.GetType();

            const string messageTemplate = "New instance of {Context}: {Type}";
            var typeOfContext = new[]
                {
                    typeof(Form),
                    typeof(EntityBase),
                    typeof(MessengerHandler),
                    typeof(MessengerRequest),
                    typeof(MessengerNotification)
                }
                .SingleOrDefault(type => type.IsAssignableFrom(typeOfInstance));

            var context = typeOfContext != null ? typeOfContext.Name : typeof(object).Name;
            var typeNameOfInstance = typeOfContext != null ? typeOfInstance.Name : typeOfInstance.FullName;

            if (instance is IDisposable) typeNameOfInstance += " : " + nameof(IDisposable);

            Log.Verbose(messageTemplate, context, typeNameOfInstance);
        }

        /// <summary>
        ///     Registra um log nível Verbose para sinalizar que uma instância foi criada.
        /// </summary>
        /// <param name="instance">Instância.</param>
        public static void LogClassDispose<T>(this T instance) where T : notnull
        {
            var type = instance.GetType();

            if (!typeof(IDisposable).IsAssignableFrom(type))
                throw new WrongArgumentException(
                    nameof(LoggerConfiguration),
                    nameof(LogClassDispose),
                    nameof(instance));

            const string messageTemplate = "Dispose instance of {Context}: {Type}";
            string context;
            string typeName;

            switch (instance)
            {
                case Form _:
                    context = nameof(Form);
                    typeName = type.Name;
                    break;
                default:
                    context = nameof(Object);
                    typeName = instance.GetType().FullName;
                    break;
            }

            if (instance is IDisposable) typeName += " : " + nameof(IDisposable);

            Log.Verbose(messageTemplate, context, typeName);
        }

        /// <summary>
        ///     Inicializa o Logger do Drake.
        /// </summary>
        /// <param name="minimumLevel">Nível mínimo para captura do log.</param>
        public static Logger Initialize(LogEventLevel minimumLevel = LogEventLevel.Verbose)
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

            var logger = loggerConfiguration.CreateLogger();

            logger.Verbose("Logger configured for {Destinations} and initialized.",
                destinations.Select(a =>
                    a.Method.Name.Replace("WriteTo", string.Empty)));

            return logger;
        }

        /// <summary>
        ///     Configura o logger.
        /// </summary>
        private static Serilog.LoggerConfiguration ConfigureLogger()
        {
            return new Serilog.LoggerConfiguration()
                .MinimumLevel.Verbose()
                .Enrich.WithProperty("Application", Resources.Name_Application)
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
            return loggerConfiguration
                .WriteTo.Console();
        }

        /// <summary>
        ///     Configura o Logger para escrever em: File.
        /// </summary>
        /// <param name="loggerConfiguration">LoggerConfiguration</param>
        /// <returns>Mesma instância de entrada.</returns>
        private static Serilog.LoggerConfiguration WriteToFile(Serilog.LoggerConfiguration loggerConfiguration)
        {
            return loggerConfiguration
                .WriteTo.File(
                    $"{Assembly.GetEntryAssembly()?.Location}.log-.txt",
                    rollingInterval: RollingInterval.Day);
        }
    }
}