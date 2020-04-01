using System.Collections.Generic;

namespace Cabster.Business.Entities
{
    /// <summary>
    ///     Dados temporários gravados apenas na memória.
    /// </summary>
    public class Temporary
    {
        /// <summary>
        ///     Lista de sessões remotas.
        /// </summary>
        public IList<Session> CurrentSessions { get; set; } = new List<Session>();
    }
}