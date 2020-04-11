using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Cabster.Business.Forms;
using Cabster.Components;
using Cabster.Exceptions;
using MediatR;
using MediatR.Registration;
using Microsoft.Extensions.DependencyInjection;

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
            dependencyResolver.Register<FormWorkGroup, FormWorkGroup>();
            dependencyResolver.Register<FormConfiguration, FormConfiguration>();

            dependencyResolver.ServiceCollection.AddMediatR(typeof(Program));

            return dependencyResolver;
        }
    }
}