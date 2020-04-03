namespace Cabster.Infrastructure
{
    /// <summary>
    ///     Tempo de vida possíveis para um serviço/implementação do IDependencyResolver
    /// </summary>
    public enum DependencyResolverLifeTime
    {
        /// <summary>
        ///     Único por instância do resolvedor de dependência.
        /// </summary>
        PerContainer = 1,

        /// <summary>
        ///     Único em um dado escopo.
        /// </summary>
        PerScope = 2,

        /// <summary>
        ///     Novo a cada requisição.
        /// </summary>
        PerRequest = 3
    }
}