using Cabster.Properties;

namespace Cabster.Exceptions
{
    /// <summary>
    ///     Exceção usada para situações que não são possíveis de ocorrer, mas foram definidas para cobrir o código.
    ///     Equivalente a NotImplementedException.
    /// </summary>
    public class ThisWillNeverOccurException : DomainException
    {
        /// <summary>
        ///     Construtor.
        /// </summary>
        public ThisWillNeverOccurException() : base(Resources.Exception_Common_ThisWillNeverOccur)
        {
        }
    }
}