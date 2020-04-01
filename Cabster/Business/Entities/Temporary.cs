using System;
using System.Collections.Generic;

namespace Cabster.Business.Entities
{
    /// <summary>
    ///     Dados temporários gravados apenas na memória.
    /// </summary>
    [Serializable]
    public class Temporary: IEntity
    {
        /// <summary>
        ///     Lista de sessões remotas.
        /// </summary>
        public IList<Session> CurrentSessions { get; set; } = new List<Session>();
    }
}