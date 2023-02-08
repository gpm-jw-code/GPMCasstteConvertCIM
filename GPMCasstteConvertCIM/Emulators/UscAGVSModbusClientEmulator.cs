using GPMCasstteConvertCIM.Devices;
using GPMCasstteConvertCIM.GPM_Modbus;
using GPMCasstteConvertCIM.UI_UserControls;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GPMCasstteConvertCIM.CasstteConverter.Data.clsMemoryAddress;
using static GPMCasstteConvertCIM.GPM_Modbus.ModbusServerBase;
using static GPMCasstteConvertCIM.GPM_Modbus.TCPHandler;

namespace GPMCasstteConvertCIM.Emulators
{
    public partial class UscAGVSModbusClientEmulator : UserControl
    {
        ModbusClientBase modbus = new ModbusClientBase();
        BindingList<DigitalIORegister> DigitalInputs = new BindingList<DigitalIORegister>();
        BindingList<DigitalIORegister> DigitalOutputs = new BindingList<DigitalIORegister>();
        BindingList<HoldingRegister> holdingRegs = new BindingList<HoldingRegister>();
        CancellationTokenSource cancellationToken;

        internal CasstteConverter.clsCasstteConverter casstte_convert;

        internal class HoldingRegisterWrite
        {
            internal int startIndex;
            internal int[] values;
            internal Action OnWriteDone;
        }
        private Queue<HoldingRegisterWrite> RegisterWritesQueue = new Queue<HoldingRegisterWrite>();
        public UscAGVSModbusClientEmulator()
        {
            InitializeComponent();
        }

        private int CIM_StartHoldingRegisterNumber => casstte_convert.LinkWordMap.FindAll(mem => mem.Link_Modbus_Register_Number != -1).OrderBy(mem => mem.Link_Modbus_Register_Number).ToList().FirstOrDefault(mem => mem.EOwner == OWNER.CIM).Link_Modbus_Register_Number - 1;

        private void UscAGVSModbusClientEmulator_Load(object sender, EventArgs e)
        {
            try
            {

                modbus.Connect("127.0.0.1", casstte_convert.modbusServerGUI.ModbusTCPServer.Port);
            }
            catch (Exception ex)
            {
            }

            List<CasstteConverter.Data.clsMemoryAddress> modbus_linked_addresses = casstte_convert.LinkBitMap.FindAll(mem => mem.EOwner == OWNER.EQP && mem.Link_Modbus_Register_Number != -1);
            List<CasstteConverter.Data.clsMemoryAddress> DI_modbus_linked_addresses = casstte_convert.LinkBitMap.FindAll(mem => mem.EOwner == OWNER.CIM && mem.Link_Modbus_Register_Number != -1);
            List<CasstteConverter.Data.clsMemoryAddress> word_address = casstte_convert.LinkWordMap.FindAll(mem => mem.Link_Modbus_Register_Number != -1).OrderBy(mem => mem.Link_Modbus_Register_Number).ToList();

            for (int i = 1; i <= 255; i++)
            {

                CasstteConverter.Data.clsMemoryAddress? di_address = modbus_linked_addresses.FirstOrDefault(m => m.Link_Modbus_Register_Number == i);
                if (di_address != null)
                {
                    DigitalInputs.Add(new DigitalIORegister
                    {
                        Index = i,
                        State = (bool)di_address.Value,
                        Description = di_address.DataName
                    });
                }
                else
                {
                    DigitalInputs.Add(new DigitalIORegister
                    {
                        Index = i,
                        State = false,
                        Description = ""
                    });
                }

                CasstteConverter.Data.clsMemoryAddress? do_address = DI_modbus_linked_addresses.FirstOrDefault(m => m.Link_Modbus_Register_Number == i);
                if (do_address != null)
                {
                    DigitalOutputs.Add(new DigitalIORegister
                    {
                        Index = i,
                        State = (bool)do_address.Value,
                        Description = do_address.DataName
                    });
                }
                else
                {
                    DigitalOutputs.Add(new DigitalIORegister
                    {
                        Index = i,
                        State = false,
                        Description = ""
                    });
                }

                CasstteConverter.Data.clsMemoryAddress? holding_address = word_address.FirstOrDefault(m => m.Link_Modbus_Register_Number == i);
                if (holding_address != null)
                {
                    holdingRegs.Add(new HoldingRegister
                    {
                        Index = i,
                        Value = short.Parse(holding_address.Value + ""),
                        Description = holding_address.DataName
                    });
                }
                else
                {
                    holdingRegs.Add(new HoldingRegister
                    {
                        Index = i,
                        Value = 0,
                        Description = ""
                    });
                }
            }

            dgvDI_EQPLC.DataSource = DigitalInputs;
            dgvDO_AGVS.DataSource = DigitalOutputs;
            dgvHoldingRegisterMap.DataSource = holdingRegs;

            ReadEQStates();

        }


        private async void ReadEQStates()
        {
            cancellationToken = new CancellationTokenSource();
            await Task.Run(async () =>
            {
                try
                {
                    while (true)
                    {
                        await Task.Delay(200, cancellationToken.Token);


                        while (RegisterWritesQueue.Count != 0)
                        {
                            HoldingRegisterWrite toWrite = RegisterWritesQueue.Dequeue();
                            modbus.WriteMultipleRegisters(toWrite.startIndex, toWrite.values);
                        }
                        try
                        {
                            bool[] states = modbus.ReadDiscreteInputs(0, 255);
                            for (int i = 0; i < states.Length; i++)
                            {
                                bool IsChanged = DigitalInputs[i].State != states[i];
                                DigitalInputs[i].State = states[i];

                                if (IsChanged)
                                    Invoke(new Action(() =>
                                    {
                                        dgvDI_EQPLC.Rows[i].DefaultCellStyle.BackColor = DigitalInputs[i].State ? Color.Lime : Color.White;
                                    }));
                            }


                            List<int> valueList = new List<int>();

                            int loopNum = holdingRegs.Count / 125;
                            int rant = holdingRegs.Count % 125;

                            for (int i = 0; i < loopNum; i++)
                            {
                                int[] values = modbus.ReadHoldingRegisters(125 * i, 125);
                                valueList.AddRange(values);
                            }
                            int[] _values = modbus.ReadHoldingRegisters(125 * loopNum, rant);
                            valueList.AddRange(_values);


                            if (valueList.Count != 0)
                            {

                                List<short> shorts = new List<short>();
                                for (int i = 0; i < valueList.Count; i += 2)
                                {
                                    short sval = (short)(valueList[i + 1] + valueList[i] * 256);
                                    shorts.Add(sval);
                                }
                                for (int i = 0; i < shorts.Count; i++)
                                    holdingRegs[i].Value = shorts[i];
                            }

                            //write
                            modbus.WriteMultipleCoils(0, DigitalOutputs.Select(DO => DO.State).ToArray());
                            //modbus.WriteSingleCoil(0, DigitalOutputs[0].State);
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                catch (TaskCanceledException ex)
                {

                }

            });

        }

        private void DataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            DataGridViewRow row = dgv.Rows[e.RowIndex];
            DigitalIORegister reg = (DigitalIORegister)row.DataBoundItem;
            reg.State = !reg.State;
            row.DefaultCellStyle.BackColor = reg.State ? Color.Lime : Color.White;
        }

        internal void CancelTask()
        {
            cancellationToken?.Cancel();
        }

        private void dgvHoldingRegisterMap_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {

                HoldingRegister _HoldingRegister = (HoldingRegister)dgvHoldingRegisterMap.Rows[e.RowIndex].DataBoundItem;

                if (_HoldingRegister.Address < CIM_StartHoldingRegisterNumber)
                {
                    MessageBox.Show("EQP資料不允許變更", "Forbid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                WordValueChangeDialog dialog = new WordValueChangeDialog();
                int newValue = dialog.ShowDialog(_HoldingRegister.Address + "", _HoldingRegister.Value);
                var toWriteData = new HoldingRegisterWrite()
                {
                    startIndex = _HoldingRegister.Address - 1,
                    values = new int[] { newValue }
                };
                RegisterWritesQueue.Enqueue(toWriteData);
            }
        }

        private int Valid_SignalIndex = 0;
        private int TR_REQ_SignalIndex = 1;
        private int BUSY_SignalIndex = 2;
        private int COMPT_SignalIndex = 3;
        private int AGV_READY_SignalIndex = 4;

        private int To_EQ_UP_SignalIndex = 8;
        private int To_EQ_DOWN_SignalIndex = 9;
        private int CMD_Reserve_Up_SignalIndex = 10;
        private int CMD_Reserve_Down_SignalIndex = 11;


        private int L_REQ_SignalIndex = 0;
        private int U_REQ_SignalIndex = 1;
        private int EQ_READY_SignalIndex = 2;
        private int EQ_BUSY_SignalIndex = 3;

        private int Load_Request_SignalIndex = 5;
        private int Unload_Request_SignalIndex = 6;
        private int Port_Exist_SignalIndex = 7;
        private int Port_Status_Down_SignalIndex = 8;
        private int LD_UP_POS_SignalIndex = 9;
        private int LD_DOWN_POS_SignalIndex = 10;



        #region AGV Signals
        internal DigitalIORegister HS_IO_AGV_Valid => DigitalOutputs[Valid_SignalIndex];
        internal DigitalIORegister HS_IO_AGV_TR_REQ => DigitalOutputs[TR_REQ_SignalIndex];
        internal DigitalIORegister HS_IO_AGV_BUSY => DigitalOutputs[BUSY_SignalIndex];
        internal DigitalIORegister HS_IO_AGV_COMPT => DigitalOutputs[COMPT_SignalIndex];
        internal DigitalIORegister HS_IO_AGV_AGV_READY => DigitalOutputs[AGV_READY_SignalIndex];

        internal DigitalIORegister STATE_IO_To_EQ_UP => DigitalOutputs[To_EQ_UP_SignalIndex];
        internal DigitalIORegister STATE_IO_To_EQ_DOWN => DigitalOutputs[To_EQ_DOWN_SignalIndex];
        internal DigitalIORegister STATE_IO_CMD_Reserve_Up => DigitalOutputs[CMD_Reserve_Up_SignalIndex];
        internal DigitalIORegister STATE_IO_CMD_Reserve_Down => DigitalOutputs[CMD_Reserve_Down_SignalIndex];

        #endregion

        #region EQP Signals

        internal DigitalIORegister HS_IO_EQ_L_REQ => DigitalInputs[L_REQ_SignalIndex];
        internal DigitalIORegister HS_IO_EQ_U_REQ => DigitalInputs[U_REQ_SignalIndex];
        internal DigitalIORegister HS_IO_EQ_EQ_READY => DigitalInputs[EQ_READY_SignalIndex];
        internal DigitalIORegister HS_IO_EQ_EQ_BUSY => DigitalInputs[EQ_BUSY_SignalIndex];
        internal DigitalIORegister STATE_IO_Load_Request => DigitalInputs[Load_Request_SignalIndex];
        internal DigitalIORegister STATE_IO_Unload_Request => DigitalInputs[Unload_Request_SignalIndex];
        internal DigitalIORegister STATE_IO_Port_Exist => DigitalInputs[Port_Exist_SignalIndex];
        internal DigitalIORegister STATE_IO_Port_Status_Down => DigitalInputs[Port_Status_Down_SignalIndex];
        internal DigitalIORegister STATE_IO_LD_UP_POS => DigitalInputs[LD_UP_POS_SignalIndex];
        internal DigitalIORegister STATE_IO_LD_DOWN_POS => DigitalInputs[LD_DOWN_POS_SignalIndex];

        #endregion

        internal CancellationTokenSource LDULDHSCancel = new CancellationTokenSource();

        public async void LoadUnloadHSSimulation(LDULD_STATE ld_uld_action)
        {
            LDULDHSCancel = new CancellationTokenSource();
            Invoke(new Action(async () =>
            {
                STATE_IO_To_EQ_DOWN.State = STATE_IO_CMD_Reserve_Down.State = true;
                btnStartLDSim.Enabled = btnStartULDSim.Enabled = false;
                rtbSimulationLog.Clear();
                ResetHSState();
                await LD_ULD_HS(ld_uld_action);
                ResetHSState();
                STATE_IO_To_EQ_DOWN.State = STATE_IO_CMD_Reserve_Down.State = false;
                btnStartLDSim.Enabled = btnStartULDSim.Enabled = true;
                LDULDHSCancel.Cancel();
            }));
        }

        public enum LDULD_STATE
        {
            LOAD, UNLOAD
        }

        private async Task<bool> LD_ULD_HS(LDULD_STATE _LDULD_STATE)
        {

            DigitalIORegister EQ_LU_SIGNAL = _LDULD_STATE == LDULD_STATE.LOAD ? HS_IO_EQ_L_REQ : HS_IO_EQ_U_REQ;

            SimulationLog_INFO($"Reserve_Down State ON");
            SimulationLog_INFO($"Start {_LDULD_STATE} 交握");

            HS_IO_AGV_Valid.State = true;

            bool timeout = await WaitSignalON(EQ_LU_SIGNAL);

            if (timeout)
                return false;

            HS_IO_AGV_TR_REQ.State = true;

            timeout = await WaitSignalON(HS_IO_EQ_EQ_READY);

            if (timeout)
                return false;

            HS_IO_AGV_BUSY.State = true;

            SimulationLog_INFO("AGV_動作開始(Parking)，結束後手動OFF AGV-BUSY訊號");
            await WaitSignalOFF(HS_IO_AGV_BUSY, 260000); //模擬AGV Load/Unload作業耗時

            HS_IO_AGV_AGV_READY.State = true;

            timeout = await WaitSignalON(HS_IO_EQ_EQ_BUSY);
            if (timeout)
                return false;

            timeout = await WaitSignalOFF(HS_IO_EQ_EQ_BUSY);
            if (timeout)
                return false;


            HS_IO_AGV_AGV_READY.State = false;
            HS_IO_AGV_BUSY.State = true;

            SimulationLog_INFO("AGV_動作開始(MOVE)");
            await WaitSignalOFF(HS_IO_AGV_BUSY, 260000); //模擬AGV Load/Unload作業耗時

            HS_IO_AGV_COMPT.State = true;
            timeout = await WaitSignalOFF(HS_IO_EQ_EQ_READY);
            if (timeout)
                return false;

            HS_IO_AGV_COMPT.State = false;
            HS_IO_AGV_TR_REQ.State = false;
            HS_IO_AGV_Valid.State = false;

            SimulationLog_INFO($"Reserve_Down State OFF");
            return true;
        }


        private async Task<bool> WaitSignalON(DigitalIORegister signal, int timeout_ms = 20000)
        {
            if (Debugger.IsAttached)
                timeout_ms = 60000;
            SimulationLog_INFO($"等待 {signal.Description}({signal.Index}) ON");
            Stopwatch timer = Stopwatch.StartNew();
            while (!signal.State)
            {
                await Task.Delay(1);
                if (timer.ElapsedMilliseconds > timeout_ms)
                {
                    SimulationLog_ERROR($"等待 {signal.Description}({signal.Index}) ON 發生TIMEOUT!");
                    timer.Stop();
                    return true;
                }
            }

            SimulationLog_INFO($"{signal.Description}{(signal.Index)} ON!");
            timer.Stop();
            return false;
        }
        private async Task<bool> WaitSignalOFF(DigitalIORegister signal, int timeout_ms = 20000)
        {
            SimulationLog_INFO($"等待 {signal.Description}({signal.Index}) OFF");
            Stopwatch timer = Stopwatch.StartNew();
            while (signal.State)
            {
                await Task.Delay(1);
                if (timer.ElapsedMilliseconds > timeout_ms)
                {
                    SimulationLog_ERROR($"等待 {signal.Description}({signal.Index}) OFF 發生TIMEOUT!");
                    timer.Stop();
                    return true;
                }
            }
            SimulationLog_INFO($"{signal.Description}{(signal.Index)} OFF!");
            timer.Stop();
            return false;
        }


        private void ResetHSState()
        {
            HS_IO_AGV_Valid.State = false;
            HS_IO_AGV_TR_REQ.State = false;
            HS_IO_AGV_BUSY.State = false;
            HS_IO_AGV_COMPT.State = false;
            HS_IO_AGV_AGV_READY.State = false;
        }

        private async void btnStartLDSim_Click(object sender, EventArgs e)
        {
            //if (!STATE_IO_Load_Request.State)
            //{
            //    MessageBox.Show("EQP Load_Request 訊號必須為ON");
            //    return;
            //}
            //if (STATE_IO_Port_Exist.State)
            //{
            //    MessageBox.Show("Port_Exist 訊號必須為OFF");
            //    return;
            //}
            LoadUnloadHSSimulation(LDULD_STATE.LOAD);
        }

        private async void btnStartULDSim_Click(object sender, EventArgs e)
        {
            //if (!STATE_IO_Unload_Request.State)
            //{
            //    MessageBox.Show("EQP Unload_Request 訊號必須ON");
            //    return;
            //}
            //if (!STATE_IO_Port_Exist.State)
            //{
            //    MessageBox.Show("Port_Exist 訊號必須為ON");
            //    return;
            //}
            LoadUnloadHSSimulation(LDULD_STATE.UNLOAD);
        }

        private void SimulationLog_INFO(string msg)
        {
            rtbSimulationLog.AppendText(DateTime.Now + " " + msg + "\r\n");
            rtbSimulationLog.ScrollToCaret();
        }


        private void SimulationLog_ERROR(string msg)
        {
            rtbSimulationLog.SelectionColor = Color.Red;
            rtbSimulationLog.AppendText(DateTime.Now + " " + msg + "\r\n");
            rtbSimulationLog.ScrollToCaret();
        }

    }
}
