using System;

namespace Cabster.Business.Entities
{
    /// <summary>
    ///     Sessão remota entre computadores.
    /// </summary>
    public class Session
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
    }
}