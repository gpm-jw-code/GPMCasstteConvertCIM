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
        private static SemaphoreSlim _writeExpLogSlim = new SemaphoreSlim(1, 1);

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            CheckProgramOpenState();
            StartDump();
            ApplicationConfiguration.Initialize();
            StartBGAPP();
            EnvironmentVariables.AddUserVariable("GPM_CIM_Path", Application.ExecutablePath);
            // 設定應用程序域的未捕捉異常處理
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            // 設定應用程序線程的未捕捉異常處理
            Application.ThreadException += Application_ThreadException;
            Application.Run(new frmMain());
        }

        private static void StartDump()
        {
            string dumpCmdFileName = Path.Combine(Environment.CurrentDirectory, "start_dump.cmd");
            if (File.Exists(dumpCmdFileName))
            {
                Directory.CreateDirectory(@"C:\Dumps");
                Process proc = new Process()
                {
                    StartInfo = new ProcessStartInfo()
                    {
                        FileName = dumpCmdFileName,
                        WorkingDirectory = Environment.CurrentDirectory
                    }
                };
                proc.Start();
            }
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

            try
            {
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
            catch (Exception ex)
            {

            }
            finally
            {
                _ = _WriteExceptionLogInCurrentWorkDirectory(exception, clsName, lineNumber);
            }
        }


        private static async Task _WriteExceptionLogInCurrentWorkDirectory(Exception exception, string clsName, int lineNumber)
        {
            await _writeExpLogSlim.WaitAsync();
            try
            {
                string _localErrorRecordFolder = Path.Combine(Environment.CurrentDirectory, "Exception Log");
                Directory.CreateDirectory(_localErrorRecordFolder);
                string _localErrorLogFile = Path.Combine(_localErrorRecordFolder, $"{DateTime.Now.ToString("yyyy-MM-dd-HH")}.log");
                using StreamWriter streamWriter = new StreamWriter(_localErrorLogFile, true);
                streamWriter.WriteLine($"{DateTime.Now}-{clsName}-Line:{lineNumber}-> {exception.Message}");

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                _writeExpLogSlim.Release();
            }
        }
    }



}