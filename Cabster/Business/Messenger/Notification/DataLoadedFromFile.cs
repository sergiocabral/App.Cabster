using Cabster.Business.Messenger.Request;
using Cabster.Infrastructure;

namespace Cabster.Business.Messenger.Notification
{
    /// <summary>
    ///     Sinalização de que os dados do aplicativo foram carregados do disco.
    /// </summary>
    public class DataLoadedFromFile : MessengerNotification<DataLoadFromFile>
    {
        /// <summary>
        ///     Construtor.
        /// </summary>
        /// <param name="request">Comando.</param>
        public DataLoadedFromFile(DataLoadFromFile request) : base(request)
        {
        }
    }
}