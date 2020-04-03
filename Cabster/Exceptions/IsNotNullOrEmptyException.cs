using System;
using Cabrones.Utils.Text;
using Cabster.Properties;

namespace Cabster.Exceptions
{
    /// <summary>
    ///     Quando uma situação de valor nulo ou vazio é exigida.
    /// </summary>
    public class IsNotNullOrEmptyException : DomainException
    {
        /// <summary>
        ///     Construtor.
        /// </summary>
        /// <param name="property">Propriedade que não deveria ter valor.</param>
        /// <param name="innerException">Exceção interna.</param>
        public IsNotNullOrEmptyException(string property, Exception? innerException = null) :
            base(Resources.Exception_Common_IsNotNullOrEmpty.QueryString(property), innerException)
        {
        }
    }
}