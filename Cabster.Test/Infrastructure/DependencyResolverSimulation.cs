using System;

namespace Cabster.Infrastructure
{
    /// <summary>
    ///     Classe usada como insumo para testar o DependencyResolver.
    /// </summary>
    internal class DependencyResolverSimulation : IDisposable
    {
        /// <summary>
        ///     Identificador da instância.
        /// </summary>
        public Guid Identificador { get; } = Guid.NewGuid();

        /// <summary>
        ///     Dispose.
        /// </summary>
        public void Dispose()
        {
            Disposed?.Invoke();
        }

        /// <summary>
        ///     Evento disparado quando Dispose é chamado.
        /// </summary>
        public event Action Disposed;
    }
}