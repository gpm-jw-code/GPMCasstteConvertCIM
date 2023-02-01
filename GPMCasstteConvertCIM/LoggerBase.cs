using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GPMCasstteConvertCIM
{
    internal class LoggerBase
    {
        internal enum LOG_LEVEL
        {
            INFO = 0,
            DEBUG = 1,
            ERROR = 2,
            WARNING = 3
        }
        protected RichTextBox? _richTextBox;
        internal LoggerBase(RichTextBox? richTextBox)
        {
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
        protected void AppendDateTime()
        {
            _richTextBox.AppendText($"{DateTime.Now} ");
        }
        public void Info(string msg)
        {
            _richTextBox?.Invoke((MethodInvoker)delegate
            {
                AppendDateTime();
                _richTextBox.SelectionColor = Color.LightBlue;
                _richTextBox.AppendText($"{msg}\n");
            });
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
        public void Warning(string msg)
        {
            _richTextBox?.Invoke((MethodInvoker)delegate
            {
                AppendDateTime();
                _richTextBox.SelectionColor = Color.Green;
                _richTextBox.AppendText($"{msg}\n");
            });
        }

        public void Error(string msg, Exception? ex)
        {
            _richTextBox?.Invoke((MethodInvoker)delegate
            {
                AppendDateTime();
                _richTextBox.SelectionColor = Color.Red;
                _richTextBox.AppendText($"{msg}\n");
                _richTextBox.SelectionColor = Color.Gray;
                _richTextBox.AppendText($"{ex}\n");
            });
        }

        public void Debug(string msg)
        {
            AppendDateTime();
            _richTextBox?.Invoke((MethodInvoker)delegate
            {
                _richTextBox.SelectionColor = Color.Yellow;
                _richTextBox.AppendText($"{msg}\n");
            });
        }
    }
}
