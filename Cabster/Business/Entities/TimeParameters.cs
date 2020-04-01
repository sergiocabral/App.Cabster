using System;

namespace Cabster.Business.Entities
{
    /// <summary>
    ///     Parâmetros de tempo para o trabalho em grupo.
    /// </summary>
    [Serializable]
    public class TimeParameters: IEntity
    {
        /// <summary>
        ///     Duração de cada rodada de trabalho.
        /// </summary>
        public int MinutesToWork { get; set; }

        /// <summary>
        ///     Duração do intervalo.
        /// </summary>
        public int MinutesToBreak { get; set; }

        /// <summary>
        ///     Quantas rodadas de trabalho até começar o intervalo.
        /// </summary>
        public int RoundsUpToTheBreak { get; set; }
    }
}