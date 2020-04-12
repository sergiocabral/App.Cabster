using Cabster.Business.Messenger.Request;
using Cabster.Infrastructure;

namespace Cabster.Business.Messenger.Notification
{
    /// <summary>
    ///     Sinalização de atualização de dados do aplicativo.
    /// </summary>
    public class DataUpdated : MessengerNotification<DataUpdate>
    {
        /// <summary>
        ///     Construtor.
        /// </summary>
        /// <param name="request">Comando.</param>
        public DataUpdated(DataUpdate request) : base(request)
        {
        }
    }
}