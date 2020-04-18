using Cabster.Business.Entities;

namespace Cabster.Components
{
    /// <summary>
    ///     Janela que apresenta dados do aplicativo.
    /// </summary>
    public interface IFormContainerData
    {
        /// <summary>
        /// Notifica a atualização dos controles da tela.
        /// </summary>
        /// <param name="data">Dados da aplicação.</param>
        void UpdateControls(ContainerData? data);
    }
}