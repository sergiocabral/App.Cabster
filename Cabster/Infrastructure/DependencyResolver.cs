using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cabrones.Utils.Text;
using Cabster.Exceptions;
using Cabster.Properties;
using Microsoft.Extensions.DependencyInjection;

namespace Cabster.Infrastructure
{
    /// <summary>
    ///     Resolvedor de classes.
    /// </summary>
    public class DependencyResolver : IDependencyResolver
    {
        /// <summary>
        ///     Container de trabalho do Injetor de Dependência para este projeto.
        /// </summary>
        private readonly Container _container;

        /// <summary>
        ///     Lista de hashes dos serviços já registrados para evitar duplicações.
        /// </summary>
        private readonly List<int> _registeredHashes = new List<int>();

        /// <summary>
        ///     Lista de escopos abertos.
        /// </summary>
        private readonly IDictionary<Guid, Scope> _scopes = new Dictionary<Guid, Scope>();

        /// <summary>
        ///     Construtor.
        /// </summary>
        /// <param name="services">DependencyResolver pré-existente.</param>
        public DependencyResolver(IServiceCollection? services = null)
        {
            this.LogVerboseInstantiate();

            _container = new Container(services);
        }

        /// <summary>
        ///     IServiceCollection
        /// </summary>
        public IServiceCollection ServiceCollection =>
            _container.ServiceCollection;

        /// <summary>
        ///     IServiceProvider
        /// </summary>
        public IServiceProvider ServiceProvider =>
            _container.ServiceProvider;

        /// <summary>
        ///     Liberação de recursos.
        /// </summary>
        public void Dispose()
        {
            _container.Dispose();

            this.LogVerboseDispose();
        }

        /// <summary>
        ///     Cria um escope.
        /// </summary>
        /// <param name="parentScope">Escopo pai.</param>
        /// <returns>Identificador do escopo.</returns>
        public Guid CreateScope(Guid? parentScope = null)
        {
            ValidateScope(parentScope);

            var serviceProvider = parentScope.HasValue
                ? _scopes[parentScope.Value].ServiceScope.ServiceProvider
                : _container.ServiceProvider;

            var scope =
                new Scope(serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope(), parentScope);

            _scopes.Add(scope.Id, scope);

            return scope.Id;
        }

        /// <summary>
        ///     Libera um escopo e suas instâncias.
        /// </summary>
        /// <param name="scope">Escopo.</param>
        public void DisposeScope(Guid scope)
        {
            ValidateScope(scope);

            _scopes[scope].ServiceScope.Dispose();

            foreach (var child in _scopes.ToList().Where(a => a.Value.ParentId == scope))
                DisposeScope(child.Key);

            _scopes.Remove(scope);
        }

        /// <summary>
        ///     Verifica se um escopo está liberado.
        /// </summary>
        /// <param name="scope">Escopo.</param>
        /// <returns>Indica se está liberado ou não.</returns>
        public bool IsActive(Guid scope)
        {
            return _scopes.ContainsKey(scope);
        }

        /// <summary>
        ///     Retorna uma instância do tipo solicitado.
        /// </summary>
        /// <typeparam name="TService">Tipo solicitado.</typeparam>
        /// <param name="scope">Escopo.</param>
        /// <returns>Instância encontrada ou null.</returns>
        public TService? GetInstance<TService>(Guid? scope = null) where TService : class
        {
            return (TService?) GetInstance(typeof(TService), scope, false);
        }

        /// <summary>
        ///     Retorna uma instância do tipo solicitado.
        /// </summary>
        /// <param name="service">Tipo solicitado.</param>
        /// <param name="scope">Escopo.</param>
        /// <returns>Instância encontrada ou null.</returns>
        public object? GetInstance(Type service, Guid? scope = null)
        {
            return GetInstance(service, scope, false);
        }

        /// <summary>
        ///     Retorna uma instância do tipo solicitado.
        /// </summary>
        /// <typeparam name="TService">Tipo solicitado.</typeparam>
        /// <param name="scope">Escopo.</param>
        /// <returns>Instância encontrada ou exception.</returns>
        public TService GetInstanceRequired<TService>(Guid? scope = null) where TService : class
        {
            return (TService) (GetInstance(typeof(TService), scope, true)
                               ?? throw new ThisWillNeverOccurException());
        }

        /// <summary>
        ///     Retorna uma instância do tipo solicitado.
        /// </summary>
        /// <param name="service">Tipo solicitado.</param>
        /// <param name="scope">Escopo.</param>
        /// <returns>Instância encontrada ou exception.</returns>
        public object GetInstanceRequired(Type service, Guid? scope = null)
        {
            return GetInstance(service, scope, true)
                   ?? throw new ThisWillNeverOccurException();
        }

        /// <summary>
        ///     Registrar um serviço com sua respectiva implementação.
        /// </summary>
        /// <typeparam name="TService">Serviço (interface).</typeparam>
        /// <typeparam name="TImplementation">Implementação (class).</typeparam>
        /// <param name="lifetime">Tempo de vida.</param>
        public void Register<TService, TImplementation>(
            DependencyResolverLifeTime lifetime = DependencyResolverLifeTime.PerContainer)
            where TService : class
            where TImplementation : class, TService
        {
            Register(typeof(TService), typeof(TImplementation), lifetime);
        }

        /// <summary>
        ///     Registrar um serviço com sua respectiva implementação.
        /// </summary>
        /// <param name="service">Serviço (interface).</param>
        /// <param name="implementation">Implementação (class).</param>
        /// <param name="lifetime">Tempo de vida.</param>
        public void Register(Type service, Type implementation, DependencyResolverLifeTime lifetime)
        {
            if (IsAlreadyRegistered(service, implementation, lifetime)) return;

            switch (lifetime)
            {
                case DependencyResolverLifeTime.PerContainer:
                    _container.ServiceCollection.AddSingleton(service, implementation);
                    break;
                case DependencyResolverLifeTime.PerScope:
                    _container.ServiceCollection.AddScoped(service, implementation);
                    break;
                case DependencyResolverLifeTime.PerRequest:
                    _container.ServiceCollection.AddTransient(service, implementation);
                    break;
                default:
                    throw new WrongArgumentException(
                        nameof(DependencyResolver),
                        nameof(Register),
                        nameof(lifetime));
            }

            _container.DisposeServiceProvider();
        }

        /// <summary>
        ///     Adiciona um serviço apontando para uma instância já existente.
        /// </summary>
        /// <param name="instance">Instância existente.</param>
        /// <typeparam name="TService">Serviço (interface).</typeparam>
        public void AddInstance<TService>(TService instance) where TService : notnull
        {
            AddInstance(typeof(TService), instance);
        }

        /// <summary>
        ///     Adiciona um serviço apontando para uma instância já existente.
        /// </summary>
        /// <param name="service">Serviço (interface).</param>
        /// <param name="instance">Instância existente.</param>
        public void AddInstance(Type service, object instance)
        {
            if (IsAlreadyRegistered(service, instance)) return;

            _container.ServiceCollection.AddSingleton(service, instance);

            _container.DisposeServiceProvider();
        }

        /// <summary>
        ///     Gera um hash para um dado conjunto de argumentos.
        /// </summary>
        /// <param name="args">Argumentos.</param>
        /// <returns>Hash.</returns>
        private static int GetHash(params object[] args)
        {
            var hashes = new StringBuilder();

            foreach (var arg in args) hashes.Append(arg?.GetHashCode() ?? string.Empty.GetHashCode());

            return hashes.ToString().GetHashCode();
        }

        /// <summary>
        ///     Verifica se um conjunto de informações já foi registrado.
        /// </summary>
        /// <param name="args">Argumentos.</param>
        /// <returns>Resultado.</returns>
        private bool IsAlreadyRegistered(params object[] args)
        {
            var hash = GetHash(args);
            if (_registeredHashes.Contains(hash)) return true;
            _registeredHashes.Add(hash);
            return false;
        }

        /// <summary>
        ///     Define IServiceProvider como sendo de uma fonte externa.
        /// </summary>
        /// <param name="serviceProvider">IServiceProvider</param>
        public void SetServiceProvider(IServiceProvider serviceProvider)
        {
            _container.ServiceProvider = serviceProvider;
        }

        /// <summary>
        ///     Retorna uma instância do tipo solicitado.
        /// </summary>
        /// <param name="service">Tipo solicitado.</param>
        /// <param name="scope">Escopo.</param>
        /// <param name="required">Dispara exception se o serviço não existir. Do contrário retorna null.</param>
        /// <returns>Instância encontrada.</returns>
        private object? GetInstance(Type service, Guid? scope, bool required)
        {
            if (!scope.HasValue)
                return required
                    ? _container.ServiceProvider.GetRequiredService(service)
                    : _container.ServiceProvider.GetService(service);

            ValidateScope(scope.Value);

            return required
                ? _scopes[scope.Value].ServiceScope.ServiceProvider.GetRequiredService(service)
                : _scopes[scope.Value].ServiceScope.ServiceProvider.GetService(service);
        }

        /// <summary>
        ///     Verifica de um escopo é válido.
        /// </summary>
        /// <param name="scope">Escopo.</param>
        /// <exception cref="ObjectDisposedException">Quando não é válido.</exception>
        private void ValidateScope(Guid? scope = null)
        {
            if (!scope.HasValue) return;
            if (!IsActive(scope.Value))
                throw new WrongArgumentException(
                    nameof(DependencyResolver),
                    nameof(ValidateScope),
                    nameof(scope));
        }

        /// <summary>
        ///     Classe que determina o container global.
        /// </summary>
        private class Container : IDisposable
        {
            /// <summary>
            ///     Sinaliza que o container não foi criado aqui,
            ///     mas se trata de uma instância pre-existente, recebida por parâmetro.
            /// </summary>
            private readonly bool _isManagedExternally;

            /// <summary>
            ///     Gerador de serviços registrados.
            /// </summary>
            private IServiceProvider? _serviceProvider;

            /// <summary>
            ///     Construtor.
            /// </summary>
            /// <param name="services">DependencyResolver pré-existente.</param>
            public Container(IServiceCollection? services)
            {
                this.LogVerboseInstantiate();

                _isManagedExternally = services != null;
                ServiceCollection = services ?? new ServiceCollection();
            }

            /// <summary>
            ///     Coleção de serviços registrados.
            /// </summary>
            public IServiceCollection ServiceCollection { get; }

            /// <summary>
            ///     Gerador de serviços registrados.
            /// </summary>
            public IServiceProvider ServiceProvider
            {
                get =>
                    _serviceProvider ??=
                        !_isManagedExternally
                            ? ServiceCollection.BuildServiceProvider()
                            : throw new WrongOperationException(
                                Resources.Exception_Infrastructure_ConfigurationIsManagedExternally
                                    .QueryString(nameof(DependencyResolver)));
                set =>
                    _serviceProvider =
                        _isManagedExternally
                            ? value
                            : throw new WrongOperationException(
                                Resources.Exception_Infrastructure_ConfigurationIsManagedInternally
                                    .QueryString(nameof(DependencyResolver)));
            }

            /// <summary>
            ///     Liberação de recursos.
            /// </summary>
            public void Dispose()
            {
                if (!_isManagedExternally) DisposeServiceProvider();

                this.LogVerboseDispose();
            }

            /// <summary>
            ///     Descarta ServiceProvider.
            /// </summary>
            public void DisposeServiceProvider()
            {
                if (_serviceProvider == null) return;

                if (_isManagedExternally)
                    throw new WrongOperationException(
                        Resources.Exception_Infrastructure_ConfigurationIsManagedExternally
                            .QueryString(nameof(DependencyResolver)));

                if (_serviceProvider is IDisposable serviceProviderDisposable) serviceProviderDisposable.Dispose();

                _serviceProvider = null;
            }
        }

        /// <summary>
        ///     Escopo para serviços.
        /// </summary>
        private class Scope
        {
            /// <summary>
            ///     Construtor.
            /// </summary>
            /// <param name="serviceScope">IServiceScope</param>
            /// <param name="parentId">Escopo pai.</param>
            public Scope(IServiceScope serviceScope, Guid? parentId)
            {
                Id = Guid.NewGuid();
                ParentId = parentId;
                ServiceScope = serviceScope;
            }

            /// <summary>
            ///     Identificador.
            /// </summary>
            public Guid Id { get; }

            /// <summary>
            ///     Escopo pai.
            /// </summary>
            public Guid? ParentId { get; }

            /// <summary>
            ///     Escopo.
            /// </summary>
            public IServiceScope ServiceScope { get; }
        }
    }
}