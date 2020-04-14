using System;

namespace Cabster.Business.Entities
{
    /// <summary>
    ///     Notificação.
    /// </summary>
    public class NotificationMessage : EntityBase
    {
        /// <summary>
        ///     Construtor.
        /// </summary>
        /// <param name="text">Mensagem.</param>
        /// <param name="success">Sucesso.</param>
        public NotificationMessage(string text, bool success = true)
        {
            Time = DateTimeOffset.Now;
            Text = text;
            Success = success;
        }

        /// <summary>
        ///     Data e hora da mensagem.
        /// </summary>
        public DateTimeOffset Time { get; }

        /// <summary>
        ///     Mensagem.
        /// </summary>
        public string Text { get; }

        /// <summary>
        ///     Sucesso.
        /// </summary>
        public bool Success { get; }

        /// <summary>
        ///     Representação como texto da instância.
        /// </summary>
        /// <returns>Texto.</returns>
        public override string ToString()
        {
            return $"{Time:g} {Text}";
        }
    }
}