using System;
using System.Globalization;
using System.Windows.Forms;
using Cabster.Infrastructure;

namespace Cabster
{
    /// <summary>
    ///     Classe principal
    /// </summary>
    public static class Program
    {
        /// <summary>
        ///     Ponto de entrada do sistema operacional.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMainWindow());
        }
    }
}