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

        internal SECSLogger(RichTextBox? richTextBox) : base(richTextBox)
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
            _richTextBox?.Invoke((MethodInvoker)delegate
            {
                AppendDateTime();
                _richTextBox.SelectionColor = Color.Yellow;
                _richTextBox.AppendText($"<-- [0x{id:X8}] {msg.ToSml()}\n");
            });
        }

        public void MessageOut(SecsMessage msg, int id)
        {
            _richTextBox?.Invoke((MethodInvoker)delegate
            {
                AppendDateTime();
                _richTextBox.SelectionColor = Color.Green;
                _richTextBox.AppendText($"--> [0x{id:X8}] {msg.ToSml()}\n");
            });
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
