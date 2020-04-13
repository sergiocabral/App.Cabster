using System;
using System.Collections.Generic;

namespace Cabster.Business
{
    /// <summary>
    /// Notificação de mensagens para o usuário.
    /// </summary>
    public interface IUserNotification
    {
        /// <summary>
        /// Posta uma mensagem.
        /// </summary>
        /// <param name="message">Mensagem.</param>
        /// <param name="success">Sucesso ou falha.</param>
        void Post(string message, bool success);

        /// <summary>
        /// Obtem as mensagens a partir de uma data.
        /// </summary>
        /// <param name="filter">Filtro de data.</param>
        /// <returns>Lista de mensagens</returns>
        IEnumerable<(string, bool)> GetMessages(DateTimeOffset? filter = null);
    }
}