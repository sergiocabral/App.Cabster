using System.Text.Json;
using Cabster.Exceptions;

namespace Cabster.Extensions
{
    /// <summary>
    ///     Extensões para texto.
    /// </summary>
    public static class TextExtensions
    {
        /// <summary>
        ///     Converte uma instância para JSON.
        /// </summary>
        /// <param name="instance">Instância</param>
        /// <returns>Serialização como texto JSON.</returns>
        public static string ToJson<TEntity>(this TEntity instance)
        {
            return JsonSerializer.Serialize(instance);
        }

        /// <summary>
        ///     Converte um JSON para uma entidade.
        /// </summary>
        /// <param name="json">Json.</param>
        /// <returns>Instância.</returns>
        public static TEntity FromJson<TEntity>(this string json)
        {
            return JsonSerializer.Deserialize<TEntity>(json) 
                   ?? throw new IsNullOrEmptyException(typeof(TEntity).Name);
        }
    }
}