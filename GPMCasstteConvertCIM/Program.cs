using GPMCasstteConvertCIM.Forms;
using Microsoft.VisualBasic.ApplicationServices;
using System.Diagnostics;
using System.Windows.Forms;

namespace GPMCasstteConvertCIM
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            CheckProgramOpenState();
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += Application_ThreadException; ;
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            Application.SetCompatibleTextRenderingDefault(false);
            ApplicationConfiguration.Initialize();
            Application.Run(new frmMain());
        }

        private static void CheckProgramOpenState()
        {
            var pros = Process.GetProcessesByName(Application.ProductName);
            if (pros.Length > 1)
            {
                MessageBox.Show("CIM 程式已經啟動");
                Environment.Exit(0);
            }
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
        }

    }
}