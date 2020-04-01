using System;

namespace Cabster.Business.Entities
{
    /// <summary>
    ///     Dados estatísticos das marcações de tempo.
    /// </summary>
    [Serializable]
    public class TimeStatistics
    {
        /// <summary>
        ///     Quando começou a contar essas estatísticas.
        /// </summary>
        public DateTimeOffset Start { get; set; }

        /// <summary>
        ///     Tempo de trabalho.
        /// </summary>
        public int SecondsOfWork { get; set; }

        /// <summary>
        ///     Tempo de intervalo.
        /// </summary>
        public int SecondsOfBreak { get; set; }

        /// <summary>
        ///     Tempo de pausa.
        /// </summary>
        public int SecondsOfPause { get; set; }

        /// <summary>
        ///     Rodadas de trabalho.
        /// </summary>
        public int CountRoundsOfWork { get; set; }

        /// <summary>
        ///     Rodadas de trabalho.
        /// </summary>
        public int CountBreaks { get; set; }
    }
}