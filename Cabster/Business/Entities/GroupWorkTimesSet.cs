namespace Cabster.Business.Entities
{
    /// <summary>
    ///     Conjunto de informações de tempos para o trabalho de grupo.
    /// </summary>
    public class GroupWorkTimesSet : EntityBase
    {
        /// <summary>
        ///     Tempo de cada rodada de trabalho.
        /// </summary>
        public int TimeToWork { get; set; } = 10;

        /// <summary>
        ///     Tempo de cada intervalo.
        /// </summary>
        public int TimeToBreak { get; set; } = 5;

        /// <summary>
        ///     Rodadas de trabalho antes do intervalo.
        /// </summary>
        public int RoundsUpToBreak { get; set; } = 3;
    }
}