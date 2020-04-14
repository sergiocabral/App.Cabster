using System;
using Cabster.Exceptions;
using Cabster.Infrastructure;
using Newtonsoft.Json;

namespace Cabster.Business
{
    /// <summary>
    ///     Classe base para entidade.
    /// </summary>
    public abstract class EntityBase : IEntity, ICloneable
    {
        /// <summary>
        ///     Construtor.
        /// </summary>
        protected EntityBase()
        {
            this.LogClassInstantiate();
        }

        /// <summary>
        ///     Faz um clone da instância.
        /// </summary>
        /// <returns>ContainerData</returns>
        public object Clone()
        {
            return FromJson(GetType(), AsJson());
        }

        /// <summary>
        ///     Retorna o conteúdo como JSON.
        /// </summary>
        /// <returns></returns>
        public string AsJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        ///     Monta a instância com base em um JSON.
        /// </summary>
        /// <param name="json">JSON.</param>
        /// <returns>Instância.</returns>
        public static T FromJson<T>(string json) where T : IEntity
        {
            return (T) FromJson(typeof(T), json);
        }

        /// <summary>
        ///     Monta a instância com base em um JSON.
        /// </summary>
        /// <param name="type">Tipo.</param>
        /// <param name="json">JSON.</param>
        /// <returns>Instância.</returns>
        private static object FromJson(Type type, string json)
        {
            return JsonConvert.DeserializeObject(json, type)
                   ?? throw new IsNullOrEmptyException(type.Name);
        }
    }
}