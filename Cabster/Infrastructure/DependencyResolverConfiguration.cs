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

            dependencyResolver.Register<FormMain, FormMain>();
            dependencyResolver.Register<FormGroupWork, FormGroupWork>();
            dependencyResolver.Register<FormGroupWorkTimer, FormGroupWorkTimer>();
            dependencyResolver.Register<FormGroupWorkAskBreak, FormGroupWorkAskBreak>();
            dependencyResolver.Register<FormConfiguration, FormConfiguration>();
            dependencyResolver.Register<FormNotification, FormNotification>();
            dependencyResolver.Register<FormStatistics, FormStatistics>();

            dependencyResolver.Register<ITips, Tips>();
            dependencyResolver.Register<IDataManipulation, DataManipulation>();
            dependencyResolver.Register<IShortcut, Shortcut>();
            dependencyResolver.Register<IUserNotification, UserNotification>();
            dependencyResolver.Register<ILockScreen, LockScreen>();

            dependencyResolver.ServiceCollection.AddMediatR(typeof(Program));

            return dependencyResolver;
        }
    }
}