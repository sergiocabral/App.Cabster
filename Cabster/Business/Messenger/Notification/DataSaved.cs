using Cabster.Business.Enums;
using Cabster.Business.Messenger.Request;
using Cabster.Infrastructure;

namespace Cabster.Business.Messenger.Notification
{
    /// <summary>
    ///     Sinalização de gravação dos dados do aplicativo em disco.
    /// </summary>
    public class DataSaved : MessengerNotification<DataSave>
    {
        /// <summary>
        /// Construtor.
        /// </summary>
        /// <param name="request">Comando.</param>
        public DataSaved(DataSave request) : base(request)
        {
        }
    }
}