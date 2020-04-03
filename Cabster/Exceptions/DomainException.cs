using System;
using System.Reflection;

namespace Cabster.Exceptions
{
    /// <summary>
    ///     Exceção base para o domínio do sistema.
    /// </summary>
    public class DomainException : Exception
    {
        /// <summary>
        ///     Nome da aplicação em execução.
        /// </summary>
        private static readonly string ApplicationName = $"{Assembly.GetEntryAssembly()?.FullName}";

        /// <summary>
        ///     Mensagem padrão pata um exception de domínio.
        /// </summary>
        private static readonly string DefaultExceptionMessage = $"{ApplicationName} generic exception.";

        /// <summary>
        ///     Construtor.
        /// </summary>
        /// <param name="customMessage">Mensagem.</param>
        /// <param name="innerException">Exceção interna.</param>
        public DomainException(string? customMessage = null, Exception? innerException = null) :
            base(customMessage ?? DefaultExceptionMessage, innerException)
        {
        }
    }
}