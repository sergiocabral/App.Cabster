using System;
using Cabster.Business.Enums;

namespace Cabster.Business.Entities
{
    /// <summary>
    ///     Representa todas as configurações da aplicação.
    /// </summary>
    [Serializable]
    public class ContainerData : IEntity
    {
        /// <summary>
        /// Estado da aplicação 
        /// </summary>
        public StateMode State { get; set; } = StateMode.ApplicationStarted;
        
        /// <summary>
        /// Trabalho em grupo do aplicativo.
        /// </summary>
        public WorkGroupSet WorkGroup { get; set; } = new WorkGroupSet();
    }
}