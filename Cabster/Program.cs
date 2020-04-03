using System;
using System.Windows.Forms;
using Cabster.Components;
using Cabster.Helpers;
using Cabster.Infrastructure;

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
        ///     Ponto de entrada do sistema operacional.
        /// </summary>
        [STAThread]
        public static void Main()
        {
#if DEBUG
            WindowsApi.AllocConsole();
#endif
            LoggerConfiguration.Initialize();
            DependencyInjectionConfiguration.Initialize();
            WindowsApi.FixCursorHand();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMainWindow());
        }
    }
}