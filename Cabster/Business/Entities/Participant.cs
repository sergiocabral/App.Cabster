using System;

namespace Cabster.Business.Entities
{
    /// <summary>
    ///     Participante do trabalho em grupo.
    /// </summary>
    [Serializable]
    public class Participant
    {
        /// <summary>
        ///     Nome.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        ///     Está ativo.
        /// </summary>
        public bool Active { get; set; }
    }
}