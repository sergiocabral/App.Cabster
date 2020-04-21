﻿using System;

namespace Cabster.Business.Entities
{
    /// <summary>
    ///     Temporizador do trabalho corrente.
    /// </summary>
    public class GroupWorkTimerSet : EntityBase
    {
        /// <summary>
        ///     Nome do Driver.
        /// </summary>
        public string Driver { get; set; } = string.Empty;

        /// <summary>
        ///     Nome do Navegador.
        /// </summary>
        public string Navigator { get; set; } = string.Empty;

        /// <summary>
        /// </summary>
        public DateTimeOffset Limit { get; set; }
    }
}