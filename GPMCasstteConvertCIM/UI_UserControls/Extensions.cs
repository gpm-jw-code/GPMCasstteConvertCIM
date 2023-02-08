using GPMCasstteConvertCIM.CasstteConverter.Data;
using GPMCasstteConvertCIM.GPM_Modbus;
using GPMCasstteConvertCIM.Utilities;
using Secs4Net;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;

namespace GPMCasstteConvertCIM.UI_UserControls
{
    internal static class Extensions
    {
        internal enum DataGridViewType
        {
            MODBUS,
            PLC
        }
        internal static void ConnectionStateChange(this Label label, ConnectionState secs_state)
        {
            label?.Invoke((MethodInvoker)delegate
            {
                label.ForeColor = Color.White;
                switch (secs_state)
                {
                    case ConnectionState.Connecting:
                        label.ForeColor = Color.Black;
                        label.BackColor = Color.Yellow;
                        break;
                    case ConnectionState.Connected:
                        label.BackColor = Color.SeaGreen;
                        break;
                    case ConnectionState.Selected:
                        label.BackColor = Color.DarkSeaGreen;
                        break;
                    case ConnectionState.Retry:
                        label.ForeColor = Color.Black;
                        label.BackColor = Color.Yellow;
                        break;
                    default:
                        break;
                }
                //switch (secs_state)
                //{
                //    case Common.CONNECTION_STATE.DISCONNECTED:
                //        checkbox.FlatAppearance.CheckedBackColor = Color.Red;
                //        break;
                //    case Common.CONNECTION_STATE.CONNECTING:
                //        checkbox.FlatAppearance.CheckedBackColor = Color.Yellow;
                //        break;
                //    case Common.CONNECTION_STATE.CONNECTED:
                //        checkbox.FlatAppearance.CheckedBackColor = Color.SeaGreen;
                //        break;
                //    default:
                //        break;
                //}
            });
        }
        internal static void ConnectionStateChange(this Label label, Common.CONNECTION_STATE state)
        {
            label?.Invoke((MethodInvoker)delegate
            {
                label.ForeColor = Color.White;
                switch (state)
                {
                    case Common.CONNECTION_STATE.DISCONNECTED:
                        label.BackColor = Color.Red;
                        break;
                    case Common.CONNECTION_STATE.CONNECTING:
                        label.ForeColor = Color.Black;
                        label.BackColor = Color.Yellow;
                        break;
                    case Common.CONNECTION_STATE.CONNECTED:
                        label.BackColor = Color.SeaGreen;
                        break;
                    default:
                        break;
                }
            });
        }

        /// <summary>
        /// 依照布林狀態改變Label的背景顏色
        /// </summary>
        /// <param name="label"></param>
        /// <param name="on"></param>
        internal static void RenderBGColorByState(this Label label, bool on , Color active_color)
        {
            label.BackColor = on ? active_color : Color.Gray;
        }

        internal static void RowColorSet(this DataGridView dgvDOTable, DataGridViewType dataSource)
        {
            foreach (DataGridViewRow _row in dgvDOTable.Rows)
            {
                bool _state = false;

                if (dataSource == DataGridViewType.MODBUS)
                {
                    DigitalIORegister? reg = _row.DataBoundItem as DigitalIORegister;
                    if (reg == null)
                        continue;
                    _state = (_row.DataBoundItem as DigitalIORegister).State;
                }
                else
                {
                    clsMemoryAddress? reg = _row.DataBoundItem as clsMemoryAddress;
                    if (reg == null)
                        continue;
                    _state = (bool)(_row.DataBoundItem as clsMemoryAddress).Value;
                }

                _row.DefaultCellStyle.BackColor = _state ? Color.Lime : Color.White;

                if (dataSource == DataGridViewType.MODBUS)
                    _row.Cells[3].Style.BackColor = Color.FromArgb(224, 224, 224);
            }
        }

    }
}
