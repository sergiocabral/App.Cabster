using System;
using System.Collections.Generic;
using System.Linq;
using Cabster.Business.Entities;
using Cabster.Infrastructure;

namespace Cabster.Business
{
    /// <summary>
    ///     Notificação de mensagens para o usuário.
    /// </summary>
    // ReSharper disable once ClassNeverInstantiated.Global
    public class UserNotification : IUserNotification
    {
        /// <summary>
        ///     Lista de mensagens.
        /// </summary>
        private static readonly List<NotificationMessage> Messages = new List<NotificationMessage>();

        /// <summary>
        ///     Construtor.
        /// </summary>
        public UserNotification()
        {
            this.LogClassInstantiate();
        }

        /// <summary>
        ///     Posta uma mensagem.
        /// </summary>
        /// <param name="message">Mensagem.</param>
        public void Post(NotificationMessage message)
        {
            Messages.Add(message);
        }

        /// <summary>
        ///     Obtem as mensagens a partir de uma data.
        /// </summary>
        /// <param name="filter">Filtro de data.</param>
        /// <returns>Lista de mensagens</returns>
        public IEnumerable<NotificationMessage> GetMessages(DateTimeOffset? filter = null)
        {
            var messages = Messages.AsEnumerable();

            if (filter.HasValue)
                messages = messages.Where(a => a.Time > filter.Value);

            return messages;
        }
    }
}