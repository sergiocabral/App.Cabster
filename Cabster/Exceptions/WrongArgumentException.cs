using System;
using Cabrones.Utils.Text;
using Cabster.Properties;

namespace Cabster.Exceptions
{
    /// <summary>
    ///     Quando o argumento passado é inválido.
    /// </summary>
    public class WrongArgumentException : DomainException
    {
        /// <summary>
        ///     Construtor.
        /// </summary>
        /// <param name="nameOfClass">Nome da classe.</param>
        /// <param name="nameOfMethod">Nome do método.</param>
        /// <param name="nameOfArgument">Nome do argumento.</param>
        /// <param name="innerException">Exceção interna.</param>
        public WrongArgumentException(
            string nameOfClass,
            string nameOfMethod,
            string nameOfArgument,
            Exception? innerException = null) :
            base(Resources.Exception_Common_WrongArgument
                .QueryString(nameOfClass, nameOfMethod, nameOfArgument), innerException)
        {
        }
    }
}