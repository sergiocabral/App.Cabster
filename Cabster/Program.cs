using System;
using System.Windows.Forms;
using Cabster.Infrastructure;

namespace Cabster
{
    /// <summary>
    ///     Classe principal
    /// </summary>
    internal static class Program
    {
        /// <summary>
        ///     Ponto de entrada do sistema operacional.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMainWindow());
        }
    }
}