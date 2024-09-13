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
    internal class MCSSecsLogger : SECSLogger
    {
        internal MCSSecsLogger(RichTextBox? richTextBox, string saveFolder, string subFolderName) : base(richTextBox, saveFolder, subFolderName)
        {
        }

        public override void MessageIn(SecsMessage msg, int id)
        {
            var time = DateTime.Now;
            string sml = msg.ToSml();
            string log_str = $"[MCS -> CIM] Name:{msg.Name} id:[{id}](0x{id:X8}) {msg.ToSml()}\n";
            _richTextBox?.Invoke((MethodInvoker)delegate
            {
                _richTextBox.SelectionColor = Color.SeaGreen;
                _richTextBox.AppendText(time.ToString("yyyy/MM/dd HH:mm:ss.ffff") + " " + log_str);
            });
            StoreLogItemToQueue(time, LOG_LEVEL.INFO, log_str);
        }

        public override void MessageOut(SecsMessage msg, int id)
        {
            var time = DateTime.Now;
            string sml = msg.ToSml();
            string log_str = $"[CIM -> MCS] Name:{msg.Name} id:[{id}](0x{id:X8}) {msg.ToSml()}\n";
            _richTextBox?.Invoke((MethodInvoker)delegate
            {
                _richTextBox.SelectionColor = Color.White;
                _richTextBox.AppendText(time.ToString("yyyy/MM/dd HH:mm:ss.ffff") + " " + log_str);
            });
            StoreLogItemToQueue(time, LOG_LEVEL.INFO, log_str);
        }
    }
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

        public virtual void MessageIn(SecsMessage msg, int id)
        {
            var time = DateTime.Now;
            string sml = msg.ToSml();
            string log_str = $"<--{msg.Name} [0x{id:X8}]\nMessage= {sml}\n";
            _richTextBox?.Invoke((MethodInvoker)delegate
            {
                _richTextBox.SelectionColor = Color.SeaGreen;
                _richTextBox.AppendText(time.ToString("yyyy/MM/dd HH:mm:ss.ffff") + " " + log_str);
            });
            StoreLogItemToQueue(time, LOG_LEVEL.SECS_MSG, log_str);
        }

        public virtual void MessageOut(SecsMessage msg, int id)
        {
            var time = DateTime.Now;
            string sml = msg.ToSml();
            string log_str = $"{msg.Name}--> [0x{id:X8}] {msg.ToSml()}\n";
            _richTextBox?.Invoke((MethodInvoker)delegate
            {
                _richTextBox.SelectionColor = Color.White;
                _richTextBox.AppendText(time.ToString("yyyy/MM/dd HH:mm:ss.ffff") + " " + log_str);
            });
            StoreLogItemToQueue(time, LOG_LEVEL.SECS_MSG, log_str);
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
