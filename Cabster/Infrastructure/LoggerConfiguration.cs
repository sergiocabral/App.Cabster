﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Cabster.Exceptions;
using Cabster.Properties;
using MediatR;
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
            var type = instance.GetType();

            switch (instance)
            {
                case IDisposable _:
                    Log.Verbose(
                        "New instance of {Type} : {Interface}.",
                        type.FullName, nameof(IDisposable));
                    break;
                case MessengerHandler _:
                    Log.Verbose("New instance of message handler: {Type}",
                        type.Name);
                    break;
                case IRequest _:
                case INotification _:
                    Log.Verbose("New instance of message {MessageType}: {Type}",
                        instance is IRequest ? nameof(IRequest) : nameof(INotification),
                        type.Name);
                    break;
                default:
                    Log.Verbose(
                        "New instance of {Type}.",
                        type.FullName);
                    break;
            }
        }

        /// <summary>
        ///     Registra um log nível Verbose para sinalizar que uma instância foi criada.
        /// </summary>
        /// <param name="instance">Instância.</param>
        public static void LogClassDispose<T>(this T instance) where T : notnull
        {
            var type = instance.GetType();
            var typeDisposable = typeof(IDisposable);

            if (typeDisposable.IsAssignableFrom(type))
                Log.Verbose(
                    "Dispose instance of {Type} : {Interface}.",
                    type.FullName, typeDisposable.Name);
            else
                throw new WrongArgumentException(
                    nameof(LoggerConfiguration),
                    nameof(LogClassDispose),
                    nameof(instance));
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
                    $"{Assembly.GetEntryAssembly()?.Location}-log-.txt",
                    rollingInterval: RollingInterval.Day);
        }
    }
}