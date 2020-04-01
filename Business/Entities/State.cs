using System;

namespace Cabster.Business.Entities
{
    /// <summary>
    ///     Estado de funcionamento da aplicação.
    /// </summary>
    [Serializable]
    public class State
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