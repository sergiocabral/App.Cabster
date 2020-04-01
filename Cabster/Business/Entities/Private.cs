using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Cabster.Business.Entities
{
    /// <summary>
    ///     Dados privados apenas neste computador.
    /// </summary>
    [Serializable]
    public class Private : IEntity
    {
        /// <summary>
        ///     Tecla de atalho para o aplicativo.
        /// </summary>
        public Shortcut Shortcut { get; set; }

        /// <summary>
        ///     Dados estatísticos das marcações de tempo.
        /// </summary>
        public Dictionary<string, TimeStatistics> MyTimeStatistics { get; set; } =
            new Dictionary<string, TimeStatistics>();
    }
}