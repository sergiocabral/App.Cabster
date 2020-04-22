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
        public List<GroupWorkParticipantSet> Participants { get; set; } = new List<GroupWorkParticipantSet>();

        /// <summary>
        ///     Histórico de trabalhos e intervalos.
        /// </summary>
        public List<GroupWorkHistorySet> History { get; set; } = new List<GroupWorkHistorySet>();
    }
}