using System;

namespace Cabster.Business.Values
{
    /// <summary>
    ///     Lista de janelas da aplicação.
    /// </summary>
    [Flags]
    public enum Window
    {
        /// <summary>
        ///     Janela principal do sistema.
        /// </summary>
        Main =
            0b_0000_0001,

        /// <summary>
        ///     Janela de trabalho em MOB.
        /// </summary>
        GroupWork =
            0b_0000_0010,

        /// <summary>
        ///     Janela de configuração.
        /// </summary>
        Configuration =
            0b_0000_0100,

        /// <summary>
        ///     Janela de notificação.
        /// </summary>
        Notification =
            0b_0000_1000
    }
}