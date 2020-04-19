using System.Collections.Generic;

namespace Cabster.Business.Entities
{
    /// <summary>
    ///     Coleção de informação para um trabalho de mob.
    /// </summary>
    public class GroupWorkSet : EntityBase
    {
        /// <summary>
        ///     Tempos
        /// </summary>
        public GroupWorkTimesSet Times { get; set; } = new GroupWorkTimesSet();

        /// <summary>
        ///     Participantes.
        /// </summary>
        public IList<GroupWorkParticipantSet> Participants { get; set; } = new List<GroupWorkParticipantSet>();
        
        /// <summary>
        ///     Temporizador do trabalho corrente.
        /// </summary>
        public GroupWorkTimerSet Timer { get; set; } = new GroupWorkTimerSet();
    }
}