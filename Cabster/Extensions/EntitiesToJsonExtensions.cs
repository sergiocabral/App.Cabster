namespace Cabster.Business
{
    /// <summary>
    ///     Extensões para as entidades.
    /// </summary>
    public static class EntitiesToJsonExtensions
    {
        /// <summary>
        ///     Converte a entidade para JSON.
        /// </summary>
        /// <param name="entity">Entidade</param>
        /// <returns>Serialização como texto JSON.</returns>
        public static string ToJson(this IEntity entity)
        {
            return entity.ToString();
        }
    }
}