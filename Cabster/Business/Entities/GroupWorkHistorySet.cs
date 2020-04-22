using System;

namespace Cabster.Business.Entities
{
    /// <summary>
    ///     Temporizador do trabalho em grupo MOB.
    /// </summary>
    public class GroupWorkHistorySet : EntityBase
    {
        /// <summary>
        /// Momento do início. 
        /// </summary>
        public DateTimeOffset Started { get; set; }
        
        /// <summary>
        /// Tempo esperado de execução.
        /// </summary>
        public TimeSpan TimeExpected { get; set; }
        
        /// <summary>
        /// Tempo decorrido de execução.
        /// </summary>
        public TimeSpan TimeElapsed { get; set; }
        
        /// <summary>
        /// Tempo foi concluído.
        /// </summary>
        public bool TimeConcluded { get; set; }

        /// <summary>
        ///     Indica que é um intervalo
        /// </summary>
        public bool IsBreak { get; set; }
        
        /// <summary>
        ///     Nome do Driver.
        /// </summary>
        public string? Driver { get; set; }

        /// <summary>
        ///     Nome do Navegador.
        /// </summary>
        public string? Navigator { get; set; }
    }
}