using System;

namespace Cabster.Business.Entities
{
    /// <summary>
    ///     Representa todas as configurações da aplicação.
    /// </summary>
    [Serializable]
    public class ContainerData : EntityBase
    {
        /// <summary>
        ///     Conjunto de configurações da aplicação.
        /// </summary>
        public ApplicationSet Application { get; set; } = new ApplicationSet();
        
        /// <summary>
        ///     Trabalho em grupo do aplicativo.
        /// </summary>
        public GroupWorkSet GroupWork { get; set; } = new GroupWorkSet();
    }
}