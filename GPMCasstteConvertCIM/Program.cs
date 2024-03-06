using GPMCasstteConvertCIM.Alarm;
using GPMCasstteConvertCIM.DataBase.KGS_AGVs;
using GPMCasstteConvertCIM.Forms;
using GPMCasstteConvertCIM.Utilities;
using GPMCasstteConvertCIM.WebServer;
using System;
using System.Diagnostics;
using System.Net;
using System.Text;
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

            ApplicationConfiguration.Initialize();
            StartBGAPP();
            EnvironmentVariables.AddUserVariable("GPM_CIM_Path", Environment.CurrentDirectory);


            // 設定應用程序域的未捕捉異常處理
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            // 設定應用程序線程的未捕捉異常處理
            Application.ThreadException += Application_ThreadException;
            Application.Run(new frmMain());
        }


        private static void StartBGAPP()
        {
            var pros = Process.GetProcessesByName("GPMBGAPP");
            if (pros.Length == 0)
            {
                string folder = Path.Combine(Environment.CurrentDirectory, "BackgroundApp");
                string filePath = Path.Combine(folder, "GPMBGAPP.exe");
                if (File.Exists(filePath))
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo()
                    {
                        UseShellExecute = false,
                        WorkingDirectory = folder,
                        FileName = filePath,
                        CreateNoWindow = true,
                    };
                    Process.Start(startInfo);
                }
            }
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
            LogUnHandleException(e.Exception);

        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var exception = (Exception)e.ExceptionObject;
            LogUnHandleException(exception);
        }

        private static void LogUnHandleException(Exception exception)
        {
            exception.GetClassNameAndLine(out string clsName, out int lineNumber);
            AlarmManager.AddExceptionRecored(new clsExceptionDto
            {
                Time = DateTime.Now,
                ClassName = clsName,
                LineNumber = lineNumber,
                ErrorMessage = exception.Message,
                IsChecked = false,
            });
            Utility.SystemLogger.Error(exception.Message, exception, true);

        }
    }



}