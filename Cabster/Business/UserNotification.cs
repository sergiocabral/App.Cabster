using System;
using System.Collections.Generic;
using System.Linq;

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
        private readonly List<(DateTimeOffset, string, bool)> _messages = new List<(DateTimeOffset, string, bool)>();
        
        /// <summary>
        /// Posta uma mensagem.
        /// </summary>
        /// <param name="message">Mensagem.</param>
        /// <param name="success">Sucesso ou falha.</param>
        public void Post(string message, bool success)
        {
            _messages.Add((DateTimeOffset.Now, message, success));
        }

        /// <summary>
        /// Obtem as mensagens a partir de uma data.
        /// </summary>
        /// <param name="filter">Filtro de data.</param>
        /// <returns>Lista de mensagens</returns>
        public IEnumerable<(string, bool)> GetMessages(DateTimeOffset? filter = null)
        {
            var messages = _messages.AsEnumerable();

            if (filter.HasValue)
                messages = messages.Where(a => a.Item1 >= filter.Value);
                
            return messages.Select(a => (a.Item2, a.Item3));
        }
    }
}