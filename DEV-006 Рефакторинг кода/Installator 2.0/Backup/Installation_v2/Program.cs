using System;
using System.Windows.Forms;

namespace Installation_v2 {
    internal static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main(string[] args) {
            ProgramMode.RowParams = string.Join(" ", args);
//            ProgramMode.RowParams = " adssad ";
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormInstall());
        }
    }
}