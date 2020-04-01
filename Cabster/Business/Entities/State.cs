using System;
using Cabster.Business.Enums;

namespace Cabster.Business.Entities
{
    /// <summary>
    ///     Estado de funcionamento da aplicação.
    /// </summary>
    [Serializable]
    public class State : IEntity
    {
        /// <summary>
        ///     Estado atual da aplicação.
        /// </summary>
        public StateMode Mode { get; set; }

        /// <summary>
        ///     Data e hora atual da aplicação.
        /// </summary>
        public DateTimeOffset CurrentTime { get; set; }
    }
}