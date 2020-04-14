using System;
using System.Collections.Generic;
using System.Linq;
using Cabster.Business.Entities;
using MediatR;

namespace Cabster.Business
{
    /// <summary>
    /// Notificador de mensagens para o usuário.
    /// </summary>
    public class UserNotification: IUserNotification
    {
        /// <summary>
        /// Lista de mensagens.
        /// </summary>
        private readonly List<NotificationMessage> _messages = new List<NotificationMessage>();
        
        /// <summary>
        /// Posta uma mensagem.
        /// </summary>
        /// <param name="message">Mensagem.</param>
        public void Post(NotificationMessage message)
        {
            _messages.Add(message);
        }

        /// <summary>
        /// Obtem as mensagens a partir de uma data.
        /// </summary>
        /// <param name="filter">Filtro de data.</param>
        /// <returns>Lista de mensagens</returns>
        public IEnumerable<NotificationMessage> GetMessages(DateTimeOffset? filter = null)
        {
            var messages = _messages.AsEnumerable();

            if (filter.HasValue)
                messages = messages.Where(a => a.Time > filter.Value);
                
            return messages;
        }
    }
}