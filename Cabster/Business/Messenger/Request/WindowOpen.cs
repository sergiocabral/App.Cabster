﻿using System.Collections.Generic;
using System.Windows.Forms;
using Cabster.Business.Values;
using Cabster.Infrastructure;

namespace Cabster.Business.Messenger.Request
{
    /// <summary>
    ///     Abrir uma janela de aplicação.
    /// </summary>
    public class WindowOpen : MessengerRequest<IDictionary<Window, Form>>
    {
        /// <summary>
        ///     Construtor.
        /// </summary>
        /// <param name="window">Janela pai.</param>
        /// <param name="parent">Form pai.</param>
        /// <param name="orderBy">Ordem de abertura das janelas.</param>
        public WindowOpen(Window window, Form? parent = null, params Window[] orderBy)
        {
            Window = window;
            Parent = parent;
            OrderBy = orderBy;
        }

        /// <summary>
        ///     Janela pai.
        /// </summary>
        public Window Window { get; }

        /// <summary>
        ///     Form pai.
        /// </summary>
        public Form? Parent { get; }

        /// <summary>
        ///     Ordem de abertura das janelas.
        /// </summary>
        public Window[] OrderBy { get; }
    }
}