using System.IO;
using System.Reflection;
using System.Text;
using Cabster.Business.Entities;
using Cabster.Exceptions;
using Cabster.Infrastructure;

namespace Cabster.Business
{
    /// <summary>
    ///     Manipulação de dados.
    /// </summary>
    // ReSharper disable once ClassNeverInstantiated.Global
    public class DataManipulation : IDataManipulation
    {
        /// <summary>
        ///     Codificação de texto padrão.
        /// </summary>
        private readonly Encoding _encoding = Encoding.UTF8;

        /// <summary>
        ///     Construtor.
        /// </summary>
        public DataManipulation()
        {
            this.LogClassInstantiate();
        }

        /// <summary>
        ///     Arquivo onde os dados são salvos.
        /// </summary>
        public string Path { get; } =
            new FileInfo((
                             Assembly.GetEntryAssembly() ?? 
                             Assembly.GetAssembly(typeof(Program)) ?? 
                             throw new ThisWillNeverOccurException()).Location +
                         ".data.json")
                .FullName;

        /// <summary>
        ///     Carrega do arquivo.
        /// </summary>
        /// <returns>ContainerData</returns>
        public ContainerData? LoadFromFile()
        {
            if (!File.Exists(Path)) return null;
            var content = File.ReadAllText(Path, _encoding);
            return EntityBase.FromJson<ContainerData>(content);
        }

        /// <summary>
        ///     Grava no arquivo.
        /// </summary>
        /// <param name="data">ContainerData</param>
        public void SaveToFile(ContainerData data)
        {
            var content = data.AsJson();
            File.WriteAllText(Path, content, _encoding);
        }
    }
}