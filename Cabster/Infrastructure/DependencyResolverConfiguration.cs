using Cabster.Business.Forms;
using Cabster.Components;

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

            dependencyResolver.AddInstance(dependencyResolver);
            dependencyResolver.Register<FormMainWindow, FormMainWindow>();
            dependencyResolver.Register<FormWorkGroup, FormWorkGroup>();

            return dependencyResolver;
        }
    }
}