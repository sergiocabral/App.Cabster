namespace Cabster.Business.Entities
{
    /// <summary>
    ///     Conjunto de informações que representa um participante de trabalho de mob.
    /// </summary>
    public class GroupWorkParticipantSet : EntityBase
    {
        /// <summary>
        ///     Nome da pessoa
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        ///     Ativo
        /// </summary>
        public bool Active { get; set; } = true;
    }
}