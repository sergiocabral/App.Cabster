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
        ///     Construtor.
        /// </summary>
        /// <param name="data">Dados atualizados.</param>
        /// <param name="section">Seções que foram atualizadas.</param>
        /// <param name="avoidSaveToFile">Sinaliza para evitar a gravação dos dados.</param>
        public DataUpdate(ContainerData data, DataSection section = DataSection.All, bool avoidSaveToFile = false)
        {
            Data = data;
            Section = section;
            AvoidSaveToFile = avoidSaveToFile;
        }
        
        /// <summary>
        ///     Dados atualizados
        /// </summary>
        public ContainerData Data { get; }

        /// <summary>
        ///     Seções que foram atualizadas.
        /// </summary>
        public DataSection Section { get; }

        /// <summary>
        ///     Sinaliza para evitar a gravação dos dados.
        /// </summary>
        public bool AvoidSaveToFile { get; }
    }
}