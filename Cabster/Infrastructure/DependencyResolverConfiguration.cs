using System;
using Cabster.Business.Forms;
using Cabster.Components;

namespace Cabster.Infrastructure
{
    /// <summary>
    /// Configura o resolvedor de dependência da aplicação.
    /// </summary>
    public static class DependencyResolverConfiguration
    {
        /// <summary>
        ///     Inicializa o DependencyInjection.
        /// </summary>
        public static IDisposable Initialize()
        {
            var dependencyResolver = new DependencyResolver();
            
            dependencyResolver.AddInstance<IDependencyResolver>(dependencyResolver);
            dependencyResolver.AddInstance(new FormMainWindow());
            dependencyResolver.Register<FormWorkGroup, FormWorkGroup>();

            return DependencyResolver.Default = dependencyResolver;
        }
    }
}