using System;

namespace Cabster.Business.Entities
{
    /// <summary>
    ///     Representa todas as configurações da aplicação.
    /// </summary>
    [Serializable]
    public class ContainerData: IEntity
    {
        /// <summary>
        ///     Dados privados apenas neste computador.
        /// </summary>
        public Private Private { get; set; } = new Private();

        /// <summary>
        ///     Dados compartilhados na sessão em rede.
        /// </summary>
        public Shared Shared { get; set; } = new Shared();

        /// <summary>
        ///     Dados temporários gravados apenas na memória.
        /// </summary>
        public Temporary Temporary { get; set; } = new Temporary();
    }
}