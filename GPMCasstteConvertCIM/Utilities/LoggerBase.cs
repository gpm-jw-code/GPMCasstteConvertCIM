using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RosSharp.RosBridgeClient.MessageTypes.Std;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GPMCasstteConvertCIM.Utilities.LoggerBase;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace GPMCasstteConvertCIM.Utilities
{
    public class LoggerBase
    {

        public enum LOG_LEVEL
        {
            INFO = 0,
            DEBUG = 1,
            ERROR = 2,
            WARNING = 3,
            SECS_MSG,
            SECS_MSG_TRANSFER
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum LOG_TIME_UNIT
        {
            ByDay = 24,
            ByHour = 1
        }

        internal static string FileTimeFormat
        {
            get
            {
                if (logTimeUnit == LOG_TIME_UNIT.ByHour)
                    return "yyyy-MM-dd_HH";
                else
                    return "yyyy-MM-dd";
            }
        }

        internal FormWindowState UIWindowState = FormWindowState.Normal;

        private ConcurrentQueue<clsLogItem> LogItemsQueue = new ConcurrentQueue<clsLogItem>();

        internal static LOG_TIME_UNIT logTimeUnit = LOG_TIME_UNIT.ByHour;
        internal string saveFolder { get; set; } = "";
        public string FileNameHeaderDisplay { get; internal set; } = "";
        public string currentLogFolder { get; private set; }

        private string subFolderName;

        protected RichTextBox? _richTextBox;
        internal LoggerBase(RichTextBox? richTextBox, string saveFolder, string subFolderName)
        {
            this.saveFolder = saveFolder;
            this.subFolderName = subFolderName;
            _richTextBox = richTextBox;
            if (richTextBox != null)
                _richTextBox.TextChanged += _richTextBox_TextChanged;
            WriteLogWorker();
        }

        private void _richTextBox_TextChanged(object? sender, EventArgs e)
        {
            if (_richTextBox == null || !_richTextBox.Created)
                return;
            _richTextBox?.Invoke((MethodInvoker)delegate
            {
                if (_richTextBox.Text.Length > 16384)
                    _richTextBox.Clear();
                _richTextBox.ScrollToCaret();

            });
        }


        public void Log(string msg, LOG_LEVEL log_level = LOG_LEVEL.INFO, Exception ex = null, string subFolder = "")
        {
            switch (log_level)
            {
                case LOG_LEVEL.INFO:
                    Info(msg, subFolder: subFolder);
                    break;
                case LOG_LEVEL.DEBUG:
                    Debug(msg, subFolder: subFolder);
                    break;
                case LOG_LEVEL.ERROR:
                    Error(msg, ex, subFolder: subFolder);
                    break;
                case LOG_LEVEL.WARNING:
                    Warning(msg, subFolder: subFolder);
                    break;
                default:
                    break;
            }
        }

        public void SecsTransferLog(string msg, string subFolder = "")
        {
            StoreLogItemToQueue(DateTime.Now, LOG_LEVEL.SECS_MSG_TRANSFER, msg, subFolder);
        }
        public void Info(string msg, bool show_in_richbox = true, string subFolder = "")
        {
            DateTime time = DateTime.Now;
            if (show_in_richbox)
            {
                ShowLogInRichTextBox(time, LOG_LEVEL.INFO, msg, Color.White);
            }
            StoreLogItemToQueue(time, LOG_LEVEL.INFO, msg, subFolder);
        }
        public void Info(string msg, Color foreCOlor, bool show_in_richbox = true, string subFolder = "")
        {
            DateTime time = DateTime.Now;

            if (show_in_richbox)
            {
                ShowLogInRichTextBox(time, LOG_LEVEL.INFO, msg, foreCOlor);
            }
            StoreLogItemToQueue(time, LOG_LEVEL.INFO, msg, subFolder);
        }
        public void Warning(string msg, bool show_in_richbox = true, string subFolder = "")
        {
            DateTime time = DateTime.Now;
            if (show_in_richbox)
            {
                ShowLogInRichTextBox(time, LOG_LEVEL.WARNING, msg, Color.Gold);
            }
            StoreLogItemToQueue(time, LOG_LEVEL.WARNING, msg, subFolder);
        }
        public void Error(string message, bool show_in_richbox = true, string subFolder = "")
        {
            Error(message, new Exception(message), show_in_richbox);
        }
        public void Error(Exception ex, bool show_in_richbox = true)
        {
            Error(ex.Message, ex, show_in_richbox);
        }
        public void Error(string msg, Exception? ex, bool show_in_richbox = true, string subFolder = "")
        {
            DateTime time = DateTime.Now;
            if (show_in_richbox)
            {
                ShowLogInRichTextBox(time, LOG_LEVEL.ERROR, msg, Color.FromArgb(255, 92, 97));
            }
            StoreLogItemToQueue(time, LOG_LEVEL.ERROR, $"{msg}-{ex?.Message}-{ex?.StackTrace}", subFolder);
        }
        public void Debug(string msg, string subFolder = "")
        {
            var time = DateTime.Now;
            ShowLogInRichTextBox(time, LOG_LEVEL.DEBUG, msg, Color.Yellow);
            StoreLogItemToQueue(time, LOG_LEVEL.DEBUG, msg, subFolder);
        }
        private void ShowLogInRichTextBox(DateTime time, LOG_LEVEL classify, string message, Color foreColor, Exception ex = null)
        {
            if (_richTextBox == null || !_richTextBox.Created || UIWindowState == FormWindowState.Minimized)
                return;

            _richTextBox?.Invoke(new MethodInvoker(() =>
            {
                _richTextBox.SelectionColor = foreColor;
                _richTextBox.AppendText($"{time.ToString("yyyy/MM/dd HH:mm:ss.ffffff")} [{classify}] {message}\n");
                _richTextBox.SelectionColor = Color.Gray;
                if (ex != null)
                    _richTextBox.AppendText($"{ex}\n");
            }));
        }
        public class clsLogItem : IDisposable
        {
            private bool disposedValue;

            internal string sub_folder_name { get; set; } = "";

            public DateTime time { get; set; }
            public LOG_LEVEL level { get; set; }
            public string msg { get; set; }

            protected virtual void Dispose(bool disposing)
            {
                if (!disposedValue)
                {
                    if (disposing)
                    {
                    }
                    msg = null;
                    disposedValue = true;
                }
            }
            public void Dispose()
            {
                Dispose(disposing: true);
                GC.SuppressFinalize(this);
            }
        }

        private async Task WriteLogWorker()
        {
            await Task.Delay(50); // 替换 Thread.Sleep 为 Task.Delay

            while (true)
            {
                await Task.Delay(50); // 替换 Thread.Sleep 为 Task.Delay
                try
                {
                    if (LogItemsQueue.Count == 0)
                        continue;

                    if (!LogItemsQueue.TryDequeue(out clsLogItem? logItem) || logItem == null)
                        continue;

                    if (string.IsNullOrWhiteSpace(saveFolder) || string.IsNullOrWhiteSpace(logItem.msg))
                    {
                        logItem.Dispose();
                        continue;
                    }

                    string folder = Path.Combine(saveFolder, DateTime.Now.ToString("yyyy-MM-dd"), subFolderName, logItem.sub_folder_name);
                    if (!Directory.Exists(folder))
                        Directory.CreateDirectory(folder);
                    currentLogFolder = folder;
                    string log_file = Path.Combine(folder, $"{FileNameHeaderDisplay}{DateTime.Now.ToString(FileTimeFormat)}.log");
                    string writeLine = $"{logItem.time:yyyy/MM/dd HH:mm:ss.ffffff} [{logItem.level}] {logItem.msg}";

                    await File.AppendAllTextAsync(log_file, writeLine + Environment.NewLine);

                    if (logItem.level != LOG_LEVEL.INFO)
                    {
                        string Warn_Error_log_file = Path.Combine(folder, $"{FileNameHeaderDisplay}{DateTime.Now.ToString(FileTimeFormat)}_{logItem.level}.log");
                        await File.AppendAllTextAsync(Warn_Error_log_file, writeLine + Environment.NewLine);
                    }
                    logItem.Dispose();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Logging error: {ex.Message}");
                }
            }
        }

        protected void StoreLogItemToQueue(DateTime time, LOG_LEVEL log_level, string logStr, string subFolder = "")
        {
            LogItemsQueue.Enqueue(new clsLogItem
            {
                time = time,
                level = log_level,
                msg = logStr,
                sub_folder_name = subFolder
            });

        }

    }
}
