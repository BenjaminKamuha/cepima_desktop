using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyProject
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ThemeManager.CurrentMode = Properties.Settings.Default.ThemeMode == "Dark"
                ? ThemeMode.Dark
                : ThemeMode.Light;
            Application.Run(new Form1());
        }
    }
}
