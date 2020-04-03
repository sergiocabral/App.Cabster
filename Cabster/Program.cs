using System;
using System.Windows.Forms;
using Cabster.Business.Entities;
using Cabster.Components;
using Cabster.Helpers;

namespace Cabster
{
    /// <summary>
    ///     Classe principal
    /// </summary>
    public static class Program
    {
        /// <summary>
        ///     Sinaliza que a aplicação deve ser encerrada.
        /// </summary>
        public static bool SignalToTerminate { get; set; }
        
        /// <summary>
        /// Conjunto de informações que configura o aplicativo.
        /// </summary>
        public static ContainerData Data { get; set; } = new ContainerData();

        /// <summary>
        /// Recarrega o conjunto de informações que configura o aplicativo. 
        /// </summary>
        /// <returns></returns>
        public static ContainerData ReloadData()
        {
            return ((FormMainWindow) Application.OpenForms[0]).ReloadData();
        } 

        /// <summary>
        ///     Ponto de entrada do sistema operacional.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            WindowsApi.FixCursorHand();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMainWindow());
        }
    }
}