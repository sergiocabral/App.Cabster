namespace Cabster.Business.Entities
{
    /// <summary>
    ///     Informações do trabalho corrente.
    /// </summary>
    public class GroupWorkCurrentSet : EntityBase
    {
        /// <summary>
        ///     Nome do Driver.
        /// </summary>
        public string Driver { get; set; } = string.Empty;

        /// <summary>
        ///     Nome do Navegador.
        /// </summary>
        public string Navigator { get; set; } = string.Empty;
    }
}