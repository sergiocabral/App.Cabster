using Cabster.Infrastructure;

namespace Cabster.Business.Messenger.Request
{
    /// <summary>
    ///     Grava em disco os dados da aplicação.
    /// </summary>
    public class DataSaveToFile : MessengerRequest
    {
        /// <summary>
        ///     Força a gravação imediata sem esperas
        /// </summary>
        public bool SaveImmediately { get; set; }
    }
}