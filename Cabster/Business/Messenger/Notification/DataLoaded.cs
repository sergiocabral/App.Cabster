using Cabster.Business.Enums;
using Cabster.Business.Messenger.Request;
using Cabster.Infrastructure;

namespace Cabster.Business.Messenger.Notification
{
    /// <summary>
    ///     Sinalização de que os dados do aplicativo foram carregados do disco.
    /// </summary>
    public class DataLoaded : MessengerNotification<DataLoad>
    {
        /// <summary>
        /// Construtor.
        /// </summary>
        /// <param name="request">Comando.</param>
        public DataLoaded(DataLoad request) : base(request)
        {
        }
    }
}