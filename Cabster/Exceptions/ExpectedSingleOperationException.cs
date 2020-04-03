using System;
using Cabrones.Utils.Text;
using Cabster.Properties;

namespace Cabster.Exceptions
{
    /// <summary>
    ///     Quando uma operação só pode ser executada uma vez.
    /// </summary>
    public class ExpectedSingleOperationException : DomainException
    {
        /// <summary>
        ///     Construtor.
        /// </summary>
        /// <param name="operation">Nome da operação única.</param>
        /// <param name="innerException">Exceção interna.</param>
        public ExpectedSingleOperationException(string operation, Exception? innerException = null) :
            base(Resources.Exception_Common_ExpectedSingleOperation.QueryString(operation), innerException)
        {
        }
    }
}