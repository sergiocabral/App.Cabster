using System;

namespace Cabster.Business.Entities
{
    /// <summary>
    ///     Sessão remota entre computadores.
    /// </summary>
    [Serializable]
    public class Session: IEntity
    {
        /// <summary>
        ///     Identificador.
        /// </summary>
        public Guid Guid { get; set; }

        /// <summary>
        ///     Nome.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        ///     Quando foi criada.
        /// </summary>
        public DateTimeOffset Created { get; set; }

        /// <summary>
        ///     Última atualização.
        /// </summary>
        public DateTimeOffset Updated { get; set; }

        /// <summary>
        ///     Dados estatísticos das marcações de tempo.
        /// </summary>
        public TimeStatistics TimeStatistics { get; set; } = new TimeStatistics();
    }
}