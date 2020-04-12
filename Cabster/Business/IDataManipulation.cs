using Cabster.Business.Entities;

namespace Cabster.Business
{
    /// <summary>
    /// Manipulação de dados.
    /// </summary>
    public interface IDataManipulation
    {
        /// <summary>
        /// Caminho onde o arquivo é gravado e lido.
        /// </summary>
        string Path { get; }
        
        /// <summary>
        /// Carrega do arquivo.
        /// </summary>
        /// <returns>ContainerData</returns>
        ContainerData? LoadFromFile();
        
        /// <summary>
        /// Grava no arquivo.
        /// </summary>
        /// <param name="data">ContainerData</param>
        void SaveToFile(ContainerData data);
    }
}