using System.Threading.Tasks;

namespace Cabster.Business
{
    /// <summary>
    ///     Texto de dicas aleatórias.
    /// </summary>
    public interface ITips
    {
        /// <summary>
        ///     Obtem uma dica aleatória
        /// </summary>
        /// <returns>Dica.</returns>
        Task<string> Get();
    }
}