using Cabster.Business.Messenger.Request;
using Cabster.Infrastructure;

namespace Cabster.Business.Messenger.Notification
{
    /// <summary>
    ///     Sinalização de gravação dos dados do aplicativo em disco.
    /// </summary>
    public class DataSavedToFile : MessengerNotification<DataSaveToFile>
    {
        /// <summary>
        ///     Construtor.
        /// </summary>
        /// <param name="request">Comando.</param>
        public DataSavedToFile(DataSaveToFile request) : base(request)
        {
        }
    }
}