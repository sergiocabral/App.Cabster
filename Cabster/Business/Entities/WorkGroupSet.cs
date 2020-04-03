using System.Collections.Generic;

namespace Cabster.Business.Entities
{
    /// <summary>
    /// Coleção de informação para um trabalho de mob.
    /// </summary>
    public class WorkGroupSet
    {
        /// <summary>
        /// Tempo de cada rodada de trabalho.
        /// </summary>
        public int TimeToWork { get; set; } = 10;

        /// <summary>
        /// Tempo de cada intervalo.
        /// </summary>
        public int TimeToBreak { get; set; } = 5;

        /// <summary>
        /// Rodadas de trabalho antes do intervalo.
        /// </summary>
        public int RoundsUpToBreak { get; set; } = 3;
        
        /// <summary>
        /// Participantes.
        /// </summary>
        public IList<WorkGroupParticipantSet> Participants { get; set; } = new List<WorkGroupParticipantSet>();

        /// <summary>
        /// Estatísticas.
        /// </summary>
        public WorkGroupStatisticsSet Statistics { get; set; } = new WorkGroupStatisticsSet();
    }
}