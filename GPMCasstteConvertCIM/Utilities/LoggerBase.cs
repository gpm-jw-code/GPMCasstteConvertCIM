using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            SECS_MSG
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

        private object lock_object = new object();

        protected RichTextBox? _richTextBox;
        internal LoggerBase(RichTextBox? richTextBox, string saveFolder)
        {
            this.saveFolder = saveFolder;
            _richTextBox = richTextBox;
            if (richTextBox != null)
                _richTextBox.TextChanged += _richTextBox_TextChanged;
        }

        private void _richTextBox_TextChanged(object? sender, EventArgs e)
        {
            _richTextBox?.Invoke((MethodInvoker)delegate
            {
                _richTextBox.ScrollToCaret();

            });
        }
        protected void AppendDateTime(out DateTime time)
        {
            var _time = DateTime.Now;

            _richTextBox?.Invoke((MethodInvoker)delegate
            {
                _richTextBox.AppendText($"{_time} ");
            });
            time = _time;
        }

        public void Log(string msg, LOG_LEVEL log_level = LOG_LEVEL.INFO, Exception ex = null)
        {
            switch (log_level)
            {
                case LOG_LEVEL.INFO:
                    Info(msg);
                    break;
                case LOG_LEVEL.DEBUG:
                    Debug(msg);
                    break;
                case LOG_LEVEL.ERROR:
                    Error(msg, ex);
                    break;
                case LOG_LEVEL.WARNING:
                    Warning(msg);
                    break;
                default:
                    break;
            }
        }

        public void SecsTransferLog(string msg)
        {
            AppendDateTime(out DateTime time);
            _richTextBox?.Invoke((MethodInvoker)delegate
            {
                _richTextBox.SelectionColor = Color.Yellow;
                _richTextBox.AppendText($"[SECS Msg Transfer] {msg}\n");
            });
            WriteToFile(time, LOG_LEVEL.SECS_MSG, msg);
        }
        public void Info(string msg)
        {
            AppendDateTime(out DateTime time);
            _richTextBox?.Invoke((MethodInvoker)delegate
            {
                _richTextBox.SelectionColor = Color.LightBlue;
                _richTextBox.AppendText($"{msg}\n");
            });
            WriteToFile(time, LOG_LEVEL.INFO, msg);
        }
        public void Info(string msg,Color foreCOlor)
        {
            AppendDateTime(out DateTime time);
            _richTextBox?.Invoke((MethodInvoker)delegate
            {
                _richTextBox.SelectionColor = foreCOlor;
                _richTextBox.AppendText($"{msg}\n");
            });
            WriteToFile(time, LOG_LEVEL.INFO, msg);
        }
        public void Warning(string msg)
        {
            AppendDateTime(out DateTime time);
            _richTextBox?.Invoke((MethodInvoker)delegate
            {
                _richTextBox.SelectionColor = Color.Green;
                _richTextBox.AppendText($"{msg}\n");
            });
            WriteToFile(time, LOG_LEVEL.WARNING, msg);
        }

        public void Error(string msg, Exception? ex)
        {
            AppendDateTime(out DateTime time);
            _richTextBox?.Invoke((MethodInvoker)delegate
            {
                _richTextBox.SelectionColor = Color.Red;
                _richTextBox.AppendText($"{msg}\n");
                _richTextBox.SelectionColor = Color.Gray;
                _richTextBox.AppendText($"{ex}\n");
            });
            WriteToFile(time, LOG_LEVEL.ERROR, $"{msg}-{ex?.Message}-{ex?.StackTrace}");
        }

        public void Debug(string msg)
        {
            AppendDateTime(out DateTime time);
            _richTextBox?.Invoke((MethodInvoker)delegate
            {
                _richTextBox.SelectionColor = Color.Yellow;
                _richTextBox.AppendText($"{msg}\n");
            });
            WriteToFile(time, LOG_LEVEL.DEBUG, msg);
        }

        protected void WriteToFile(DateTime time, LOG_LEVEL log_level, string logStr)
        {
            try
            {

                if (saveFolder == "")
                {
                    return;
                }
                string folder = Path.Combine(saveFolder, log_level.ToString());
                if (!Directory.Exists(folder))
                    Directory.CreateDirectory(folder);

                string log_file = Path.Combine(folder, $"{DateTime.Now.ToString(FileTimeFormat)}.log");

                lock (lock_object)
                {
                    using (StreamWriter sw = new StreamWriter(log_file, true))
                    {
                        sw.WriteLine($"{time}|{log_level}|{logStr}");
                    }
                }
            }
            catch (Exception ex)
            {
            }

        }
    }
}
