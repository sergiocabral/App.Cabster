using System;
using Cabster.Business.Entities;
using Newtonsoft.Json;

namespace Cabster.Business
{
    /// <summary>
    ///     Classe base para entidade.
    /// </summary>
    public class EntityBase: IEntity, ICloneable
    {
        /// <summary>
        /// Retorna o conteúdo como JSON.
        /// </summary>
        /// <returns></returns>
        public string AsJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Monta a instância com base em um JSON.
        /// </summary>
        /// <param name="json">JSON.</param>
        /// <returns>Instância.</returns>
        public static ContainerData FromJson(string json)
        {
            return JsonConvert.DeserializeObject<ContainerData>(json);
        }
        
        /// <summary>
        /// Faz um clone da instância.
        /// </summary>
        /// <returns>ContainerData</returns>
        public object Clone()
        {
            return FromJson(AsJson());
        }
    }
}