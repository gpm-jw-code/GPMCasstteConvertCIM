using GPMCasstteConvertCIM.Utilities;
using Secs4Net;
using Secs4Net.Sml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace GPMCasstteConvertCIM.GPM_SECS
{
    internal class SECSLogger : LoggerBase, ISecsGemLogger
    {

        internal SECSLogger(RichTextBox? richTextBox, string saveFolder, string subFolderName) : base(richTextBox, saveFolder, subFolderName)
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
            var time = DateTime.Now;
            string sml = msg.ToSml();
            var raw_bytes = Secs4Net.EncodingSetting.ASCIIEncoding.GetBytes(sml);
            var rawStr = string.Join(" ", raw_bytes);
            string log_str = $"<--{msg.Name} [0x{id:X8}]\nRaw Data={rawStr}\nMessage= {sml}\n";
            _richTextBox?.Invoke((MethodInvoker)delegate
            {
                _richTextBox.SelectionColor = Color.SeaGreen;
                _richTextBox.AppendText(time.ToString("yyyy/MM/dd HH:mm:ss.ffff") + " " + log_str);
            });
            WriteToFile(time, LOG_LEVEL.SECS_MSG, log_str);
        }

        public void MessageOut(SecsMessage msg, int id)
        {
            var time = DateTime.Now;
            string sml = msg.ToSml();
            var raw_bytes = Secs4Net.EncodingSetting.ASCIIEncoding.GetBytes(sml);
            var rawStr = string.Join(" ", raw_bytes);
            string log_str = $"{msg.Name}--> [0x{id:X8}] {msg.ToSml()}\n";
            _richTextBox?.Invoke((MethodInvoker)delegate
            {
                _richTextBox.SelectionColor = Color.White;
                _richTextBox.AppendText(time.ToString("yyyy/MM/dd HH:mm:ss.ffff") + " " + log_str);
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
