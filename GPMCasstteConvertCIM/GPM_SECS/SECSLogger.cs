using GPMCasstteConvertCIM.Utilities;
using Secs4Net;
using Secs4Net.Sml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GPMCasstteConvertCIM.GPM_SECS
{
    internal class SECSLogger : LoggerBase, ISecsGemLogger
    {

        internal SECSLogger(RichTextBox? richTextBox, string saveFolder) : base(richTextBox, saveFolder)
        {

        }

        private void _richTextBox_TextChanged(object? sender, EventArgs e)
        {
            _richTextBox?.Invoke((MethodInvoker)delegate
            {
                _richTextBox.ScrollToCaret();
            });
        }

        public void MessageIn(SecsMessage msg, int id)
        {
            AppendDateTime(out DateTime time);
            string log_str = $"<-- [0x{id:X8}] {msg.ToSml()}\n";
            _richTextBox?.Invoke((MethodInvoker)delegate
            {
                _richTextBox.SelectionColor = Color.Yellow;
                _richTextBox.AppendText(log_str);
            });
            WriteToFile(time, LOG_LEVEL.SECS_MSG, log_str);
        }

        public void MessageOut(SecsMessage msg, int id)
        {
            AppendDateTime(out DateTime time);
            string log_str = $"--> [0x{id:X8}] {msg.ToSml()}\n";
            _richTextBox?.Invoke((MethodInvoker)delegate
            {
                _richTextBox.SelectionColor = Color.Green;
                _richTextBox.AppendText(log_str);
            });
            WriteToFile(time, LOG_LEVEL.SECS_MSG, log_str);
        }

        public void Info(string msg)
        {
            base.Info(msg);
        }

        public void Warning(string msg)
        {
            base.Warning(msg);
        }

        public void Error(string msg, SecsMessage? message, Exception? ex)
        {
            if (message != null)
            {
                msg += "\r\n" + message.ToSml();
            }
            base.Error(msg, ex);
        }

    }
}
