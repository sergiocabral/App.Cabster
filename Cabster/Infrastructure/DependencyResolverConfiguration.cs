using Cabster.Business;
using Cabster.Business.Forms;
using Cabster.Components;
using MediatR;

namespace Cabster.Infrastructure
{
    /// <summary>
    ///     Configura o resolvedor de dependência da aplicação.
    /// </summary>
    public static class DependencyResolverConfiguration
    {
        /// <summary>
        ///     Inicializa um resolvedor de dependência.
        /// </summary>
        public static IDependencyResolver Initialize()
        {
            var dependencyResolver = new DependencyResolver();

            dependencyResolver.AddInstance<IDependencyResolver>(dependencyResolver);

            dependencyResolver.Register<FormMainWindow, FormMainWindow>();
            dependencyResolver.Register<FormGroupWork, FormGroupWork>();
            dependencyResolver.Register<FormConfiguration, FormConfiguration>();

            dependencyResolver.Register<IDataManipulation, DataManipulation>();

            dependencyResolver.ServiceCollection.AddMediatR(typeof(Program));

            return dependencyResolver;
        }
    }
}