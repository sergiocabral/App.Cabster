using System.ComponentModel;
using Cabster.Business.Entities;
using Cabster.Business.Enums;
using Cabster.Infrastructure;

namespace Cabster.Business.Messenger.Request
{
    /// <summary>
    ///     Altera os dados da aplicação. 
    /// </summary>
    public class DataUpdate : MessengerRequest
    {
        /// <summary>
        /// Dados atualizados
        /// </summary>
        public ContainerData Data { get; }
        
        /// <summary>
        /// Seções que foram atualizadas.
        /// </summary>
        public DataSection Section { get; }

        /// <summary>
        /// Construtor.
        /// </summary>
        /// <param name="data">Dados atualizados.</param>
        /// <param name="section">Seções que foram atualizadas.</param>
        public DataUpdate(ContainerData data, DataSection section = DataSection.All)
        {
            Data = data;
            Section = section;
        }
    }
}