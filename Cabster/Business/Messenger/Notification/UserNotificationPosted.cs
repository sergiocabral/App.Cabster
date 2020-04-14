using System;
using Cabster.Business.Messenger.Request;
using Cabster.Infrastructure;
using Serilog;
using Serilog.Events;
using LoggerConfiguration = Cabster.Infrastructure.LoggerConfiguration;

namespace Cabster.Business.Messenger.Notification
{
    /// <summary>
    ///     Posta uma mensagem para o usuário..
    /// </summary>
    public class UserNotificationPosted : MessengerNotification<UserNotificationPost>
    {
        /// <summary>
        ///     Template da mensagem de log. Simplifica quando Log em nível Information ou superior.
        /// </summary>
        private static readonly string LogMessageTemplate =
            LoggerConfiguration.MinimumLevel >= LogEventLevel.Information
                ? "{NotificationMessage}"
                : "User notification: {NotificationMessage}";

        /// <summary>
        ///     Construtor.
        /// </summary>
        /// <param name="request">Comando.</param>
        public UserNotificationPosted(UserNotificationPost request) : base(request)
        {
            var log = request.Message.Success 
                ? (Action<string, string>) Log.Information 
                : Log.Warning;
            log(LogMessageTemplate, request.Message.Text);
        }
    }
}