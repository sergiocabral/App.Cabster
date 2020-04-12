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
        /// Sinaliza para evitar a gravação dos dados.
        /// </summary>
        public bool AvoidDataSave { get; }

        /// <summary>
        /// Construtor.
        /// </summary>
        /// <param name="data">Dados atualizados.</param>
        /// <param name="section">Seções que foram atualizadas.</param>
        /// <param name="avoidDataSave">Sinaliza para evitar a gravação dos dados.</param>
        public DataUpdate(ContainerData data, DataSection section = DataSection.All, bool avoidDataSave = false)
        {
            Data = data;
            Section = section;
            AvoidDataSave = avoidDataSave;
        }
    }
}