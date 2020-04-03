using System;
using Cabrones.Utils.Text;
using Cabster.Properties;

namespace Cabster.Exceptions
{
    /// <summary>
    ///     Quando uma situação de valor nulo ou vazio não é aceitável.
    /// </summary>
    public class IsNullOrEmptyException : DomainException
    {
        /// <summary>
        ///     Construtor.
        /// </summary>
        /// <param name="property">Propriedade que deveria ter valor.</param>
        /// <param name="innerException">Exceção interna.</param>
        public IsNullOrEmptyException(string property, Exception? innerException = null) :
            base(Resources.Exception_Common_IsNullOrEmpty.QueryString(property), innerException)
        {
        }
    }
}