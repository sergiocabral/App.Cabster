using System;

namespace Cabster.Components
{
    /// <summary>
    ///     Janela padrão usada na UI do aplicativo.
    /// </summary>
    public interface IFormLayout
    {
        /// <summary>
        ///     Exibe o logotipo.
        /// </summary>
        bool ShowLogo { get; set; }

        /// <summary>
        ///     Mensagem de status.
        /// </summary>
        string StatusMessage { get; set; }

        /// <summary>
        ///     Quando clica no botão fechar.
        ///     Retorna false para cancelar o fechamento.
        /// </summary>
        event Action? ButtonCloseClick;

        /// <summary>
        ///     Quando clica no botão minimizar.
        ///     Retorna false para cancelar o fechamento.
        /// </summary>
        event Action? ButtonMinimizeClick;

        /// <summary>
        ///     Define uma mensagem de status.
        /// </summary>
        /// <param name="message">Mensagem.</param>
        /// <param name="information">Quando true, azul. Se false, vermelho.</param>
        void SetStatusMessage(string message, bool information = true);
    }
}