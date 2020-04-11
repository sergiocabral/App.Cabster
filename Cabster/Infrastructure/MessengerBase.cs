using System;
using Cabster.Exceptions;
using MediatR;
using Serilog;

namespace Cabster.Infrastructure
{
    /// <summary>
    ///     Classe base para qualquer comando ou evento.
    /// </summary>
    public abstract class MessengerBase
    {
        /// <summary>
        /// Ignora o log desse Request.
        /// </summary>
        protected virtual bool IgnoreLog { get; } = false;
        
        /// <summary>
        /// Construtor.
        /// </summary>
        protected MessengerBase()
        {
            // ReSharper disable once VirtualMemberCallInConstructor
            if (!IgnoreLog) this.LogClassInstantiate();
        }
    }
}