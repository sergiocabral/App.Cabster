using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Cabster.Business.Forms;
using Cabster.Components;
using MediatR;
using MediatR.Registration;

namespace Cabster.Infrastructure
{
    /// <summary>
    ///     Configura o resolvedor de dependência da aplicação.
    /// </summary>
    public static class DependencyResolverConfiguration
    {
        /// <summary>
        ///     Lista de interfaces usadas pelos handlers.
        /// </summary>
        private static readonly Type[] TypesOfInterfaces =
        {
            typeof(IRequestHandler<,>),
            typeof(INotificationHandler<>)
        };

        /// <summary>
        ///     Lista de Handlers neste assembly.
        /// </summary>
        private static readonly Type[] TypesOfHandlers = Assembly
            .GetAssembly(typeof(Program))
            .GetTypes()
            .Where(type =>
                !type.IsInterface &&
                type
                    .GetInterfaces()
                    .Any(typeInterface =>
                        typeInterface.IsGenericType &&
                        TypesOfInterfaces.Contains(typeInterface.GetGenericTypeDefinition())))
            .ToArray();

        /// <summary>
        ///     Inicializa um resolvedor de dependência.
        /// </summary>
        public static IDependencyResolver Initialize()
        {
            var dependencyResolver = new DependencyResolver();

            dependencyResolver.AddInstance(dependencyResolver);

            dependencyResolver.Register<FormMainWindow, FormMainWindow>();
            dependencyResolver.Register<FormWorkGroup, FormWorkGroup>();

            dependencyResolver.AddMediatR();

            return dependencyResolver;
        }

        /// <summary>
        ///     Configura o resolvedor de dependências com o MediatR
        /// </summary>
        /// <param name="dependencyResolver">Resolvedor de dependências</param>
        private static void AddMediatR(this DependencyResolver dependencyResolver)
        {
            var mediatRServiceConfiguration = new MediatRServiceConfiguration();

            // // Define o ServiceLifetime do IMediator como Singleton. Por padrão é Transient.
            // var methodLifetimeSet =
            //     mediatRServiceConfiguration
            //         .GetType()
            //         .GetMethod(
            //             $"set_{nameof(mediatRServiceConfiguration.Lifetime)}",
            //             BindingFlags.Instance | BindingFlags.NonPublic)
            //     ?? throw new ThisWillNeverOccurException();
            //
            // methodLifetimeSet.Invoke(mediatRServiceConfiguration, new object[] {ServiceLifetime.Singleton});

            ServiceRegistrar.AddRequiredServices(dependencyResolver.ServiceCollection, mediatRServiceConfiguration);

            TypesOfHandlers.AddMediatR(dependencyResolver);
        }

        /// <summary>
        ///     Configura o MediatR para os tipos informados.
        /// </summary>
        /// <param name="types">Tipos</param>
        /// <param name="dependencyResolver">Resolvedor de dependência.</param>
        /// <returns>Mesma instância de entrada.</returns>
        private static void AddMediatR(this IEnumerable<Type> types, IDependencyResolver dependencyResolver)
        {
            foreach (var type in types)
            {
                var instance = typeof(Form).IsAssignableFrom(type)
                    ? type.GetConstructor(new Type[0])?.Invoke(new object[0])
                    : null;

                if (instance != null) dependencyResolver.AddInstance(type, instance);

                foreach (var interfaceType in type
                    .GetInterfaces()
                    .Where(t => t.IsGenericType &&
                                TypesOfInterfaces.Contains(t.GetGenericTypeDefinition())))
                    if (instance != null) dependencyResolver.AddInstance(interfaceType, instance);
                    else dependencyResolver.Register(interfaceType, type);
            }
        }
    }
}