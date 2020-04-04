using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Reflection;
using Merq;

namespace Cabster.Infrastructure
{
    /// <summary>
    ///     Inicializa o serviços de mensagens (comando e eventos)
    /// </summary>
    public static class MessengerConfiguration
    {
        /// <summary>
        ///     Lista de CommandHandlers neste assembly.
        /// </summary>
        private static readonly Type[] ClassesThatImplementICommandHandler = Assembly
            .GetAssembly(typeof(Program))
            .GetTypes()
            .Where(type =>
                !type.IsInterface &&
                type
                    .GetInterfaces()
                    .Any(typeInterface =>
                        typeInterface.IsGenericType &&
                        typeInterface.GetGenericTypeDefinition() == typeof(ICommandHandler<>)))
            .ToArray();

        /// <summary>
        ///     Inicializa o serviços de mensagens.
        /// </summary>
        /// <param name="dependencyResolver">Resolvedor de dependências.</param>
        public static void Initialize(IDependencyResolver dependencyResolver)
        {
            dependencyResolver.Register<IEventStream, EventStream>();
            dependencyResolver.AddInstance<ICommandBus>(
                new CommandBus(GetCommandHandlers(dependencyResolver)));
        }

        /// <summary>
        ///     Registra no CommandBus e no resolvedor de dependências as classes CommandHandlers
        /// </summary>
        /// <param name="dependencyResolver">IDependencyResolver</param>
        /// <returns>Dicionário para uso no construtor do CommandBus</returns>
        private static ConcurrentDictionary<Type, Lazy<ICommandHandler>> GetCommandHandlers(
            IDependencyResolver dependencyResolver)
        {
            var result = new ConcurrentDictionary<Type, Lazy<ICommandHandler>>();

            foreach (var commandHandler in ClassesThatImplementICommandHandler)
            {
                var interfaces = commandHandler.GetInterfaces();

                var service =
                    interfaces.SingleOrDefault(type => type.Name.Contains(commandHandler.Name)) ?? commandHandler;

                foreach (var commandHandlerInterface in interfaces
                    .Where(type =>
                        type.IsGenericType &&
                        type.GetGenericTypeDefinition() == typeof(ICommandHandler<>)))
                {
                    var command = commandHandlerInterface.GenericTypeArguments.Single();

                    dependencyResolver.Register(service, commandHandler);

                    result.TryAdd(command,
                        new Lazy<ICommandHandler>(() => (ICommandHandler)
                            dependencyResolver.GetInstanceRequired(service)));
                }
            }

            return result;
        }
    }
}