using System;
using System.Collections.Generic;
using Cabster.Business.Entities;

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
        void Post(NotificationMessage message);

        /// <summary>
        /// Obtem as mensagens a partir de uma data.
        /// </summary>
        /// <param name="filter">Filtro de data.</param>
        /// <returns>Lista de mensagens</returns>
        IEnumerable<NotificationMessage> GetMessages(DateTimeOffset? filter = null);
    }
}