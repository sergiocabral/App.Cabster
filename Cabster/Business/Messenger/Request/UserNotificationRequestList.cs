using System;
using System.Collections.Generic;
using Cabster.Business.Entities;
using Cabster.Infrastructure;

namespace Cabster.Business.Messenger.Request
{
    /// <summary>
    ///     Requisita a lista de mensagens para o usuário.
    /// </summary>
    public class UserNotificationRequestList : MessengerRequest<IEnumerable<NotificationMessage>>
    {
        /// <summary>
        ///     Construtor.
        /// </summary>
        /// <param name="filter">Filtro</param>
        public UserNotificationRequestList(DateTimeOffset? filter = null)
        {
            Filter = filter;
        }

        /// <summary>
        ///     Filtro.
        /// </summary>
        public DateTimeOffset? Filter { get; }
    }
}