using System;

namespace Cabster.Exceptions
{
    /// <summary>
    ///     Quando uma operação inválida é executada.
    /// </summary>
    public class WrongOperationException : DomainException
    {
        /// <summary>
        ///     Construtor.
        /// </summary>
        /// <param name="customMessage">Mensagem.</param>
        /// <param name="innerException">Exceção interna.</param>
        public WrongOperationException(string customMessage, Exception? innerException = null) :
            base(customMessage, innerException)
        {
        }
    }
}