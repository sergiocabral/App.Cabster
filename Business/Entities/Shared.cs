using System.Collections.Generic;

namespace Cabster.Business.Entities
{
    /// <summary>
    ///     Dados compartilhados na sessão em rede.
    /// </summary>
    public class Shared
    {
        /// <summary>
        ///     Parâmetros de tempo para o trabalho em grupo.
        /// </summary>
        public TimeParameters TimeParameters { get; set; } = new TimeParameters();

        /// <summary>
        ///     Dados estatísticos das marcações de tempo.
        /// </summary>
        public TimeStatistics TimeStatistics { get; set; } = new TimeStatistics();

        /// <summary>
        ///     Participante do trabalho em grupo.
        /// </summary>
        public IList<Participant> Participants { get; set; } = new List<Participant>();

        /// <summary>
        ///     Estado de funcionamento da aplicação.
        /// </summary>
        public State State { get; set; } = new State();
    }
}