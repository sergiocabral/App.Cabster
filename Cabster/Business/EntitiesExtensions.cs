using Cabster.Business.Entities;

namespace Cabster.Business
{
    /// <summary>
    ///     Extensões para as entidades.
    /// </summary>
    public static class EntitiesExtensions
    {
        /// <summary>
        /// Converte a entidade para JSON. 
        /// </summary>
        /// <param name="entity">Entidade</param>
        /// <returns>Serialização como texto JSON.</returns>
        public static string ToJson(this IEntity entity)
        {            
            return string.Empty;
        }
    }
}