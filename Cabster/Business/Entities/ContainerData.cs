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
        ///     Estado da aplicação
        /// </summary>
        public ApplicationState ApplicationState { get; set; } = ApplicationState.ApplicationStarted;

        /// <summary>
        ///     Trabalho em grupo do aplicativo.
        /// </summary>
        public GroupWorkSet GroupWork { get; set; } = new GroupWorkSet();
    }
}