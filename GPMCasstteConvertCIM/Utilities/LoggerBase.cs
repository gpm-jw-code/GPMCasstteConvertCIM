using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
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

        internal static LOG_TIME_UNIT logTimeUnit = LOG_TIME_UNIT.ByHour;
        internal string saveFolder { get; set; } = "";
        public string FileNameHeaderDisplay { get; internal set; } = "";

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
            if (_richTextBox != null)
                if (_richTextBox.Created)
                {
                    _richTextBox?.Invoke((MethodInvoker)delegate
                {
                    if (_richTextBox.Text.Length > 16384)
                        _richTextBox.Clear();
                    _richTextBox.ScrollToCaret();

                });
                }
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
            if (_richTextBox != null)
            {
                if (show_in_richbox && _richTextBox.Created)
                {
                    _richTextBox?.Invoke((MethodInvoker)delegate
                    {
                        _richTextBox.SelectionColor = Color.White;
                        _richTextBox.AppendText($"{time} [INFO] {msg}\n");
                    });
                }
            }

            StoreLogItemToQueue(time, LOG_LEVEL.INFO, msg, subFolder);
        }
        public void Info(string msg, Color foreCOlor, bool show_in_richbox = true, string subFolder = "")
        {
            DateTime time = DateTime.Now;
            if (_richTextBox != null)
                if (show_in_richbox && _richTextBox.Created)
                {
                    _richTextBox?.Invoke((MethodInvoker)delegate
                    {
                        _richTextBox.SelectionColor = foreCOlor;
                        _richTextBox.AppendText($"{time} [INFO] {msg}\n");
                    });
                }
            StoreLogItemToQueue(time, LOG_LEVEL.INFO, msg, subFolder);
        }
        public void Warning(string msg, bool show_in_richbox = true, string subFolder = "")
        {
            DateTime time = DateTime.Now;
            if (_richTextBox != null)
                if (show_in_richbox && _richTextBox.Created)
                    _richTextBox?.Invoke((MethodInvoker)delegate
                    {
                        _richTextBox.SelectionColor = Color.Gold;
                        _richTextBox.AppendText($"{time} [WARN] {msg}\n");
                    });
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
            if (_richTextBox != null)
                if (show_in_richbox && _richTextBox.Created)
                {
                    _richTextBox?.Invoke((MethodInvoker)delegate
                        {
                            _richTextBox.SelectionColor = Color.FromArgb(255, 92, 97);
                            _richTextBox.AppendText($"{time} [ERROR] {msg}\n");
                            _richTextBox.SelectionColor = Color.Gray;
                            _richTextBox.AppendText($"{ex}\n");
                        });
                }
            StoreLogItemToQueue(time, LOG_LEVEL.ERROR, $"{msg}-{ex?.Message}-{ex?.StackTrace}", subFolder);
        }
        public class clsLogItem
        {
            internal string sub_folder_name { get; set; } = "";

            public DateTime time { get; set; }
            public LOG_LEVEL level { get; set; }
            public string msg { get; set; }
        }
        public void Debug(string msg, string subFolder = "")
        {
            var time = DateTime.Now;

            if (_richTextBox != null && _richTextBox.Created)
            {
                _richTextBox?.Invoke((MethodInvoker)delegate
                {
                    _richTextBox.SelectionColor = Color.Yellow;
                    _richTextBox.AppendText($"{time} {msg}\n");
                });
            }
            StoreLogItemToQueue(time, LOG_LEVEL.DEBUG, msg, subFolder);
        }
        private ConcurrentQueue<clsLogItem> LogItemsQueue = new ConcurrentQueue<clsLogItem>();

        private async Task WriteLogWorker()
        {
            _ = Task.Run(async () =>
             {
                 while (true)
                 {
                     await Task.Delay(1);

                     if (!LogItemsQueue.TryDequeue(out clsLogItem logItem))
                         continue;

                     try
                     {
                         if (saveFolder == "")
                         {
                             return;
                         }
                         if (logItem.msg == "")
                         {
                             continue;
                         }
                         string folder = Path.Combine(saveFolder, DateTime.Now.ToString("yyyy-MM-dd"));
                         folder = Path.Combine(folder, subFolderName);
                         folder = Path.Combine(folder, logItem.sub_folder_name);
                         if (!Directory.Exists(folder))
                             Directory.CreateDirectory(folder);
                         string log_file = Path.Combine(folder, $"{FileNameHeaderDisplay}{DateTime.Now.ToString(FileTimeFormat)}.log");
                         using (StreamWriter sw = new StreamWriter(log_file, true))
                         {
                             sw.WriteLine($"{logItem.time.ToString("yyyy/MM/dd HH:mm:ss.ffff")} [{logItem.level}] {logItem.msg}");
                         }
                     }
                     catch (Exception ex)
                     {
                     }
                 }
             });
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
