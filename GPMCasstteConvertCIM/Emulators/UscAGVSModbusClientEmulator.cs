using GPMCasstteConvertCIM.CIM;
using GPMCasstteConvertCIM.GPM_Modbus;
using GPMCasstteConvertCIM.UI_UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GPMCasstteConvertCIM.CasstteConverter.Data.clsMemoryAddress;
using static GPMCasstteConvertCIM.GPM_Modbus.ModbusServerBase;

namespace GPMCasstteConvertCIM.Emulators
{
    public partial class UscAGVSModbusClientEmulator : UserControl
    {
        ModbusClientBase modbus = new ModbusClientBase();
        BindingList<DigitalIORegister> DigitalInputs = new BindingList<DigitalIORegister>();
        BindingList<DigitalIORegister> DigitalOutputs = new BindingList<DigitalIORegister>();
        BindingList<HoldingRegister> holdingRegs = new BindingList<HoldingRegister>();
        CancellationTokenSource cancellationToken;

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

        private int CIM_StartHoldingRegisterNumber => CIMDevices.casstteConverter_1.LinkWordMap.FindAll(mem => mem.Link_Modbus_Register_Number != -1).OrderBy(mem => mem.Link_Modbus_Register_Number).ToList().FirstOrDefault(mem => mem.EOwner == OWNER.CIM).Link_Modbus_Register_Number - 1;

        private void UscAGVSModbusClientEmulator_Load(object sender, EventArgs e)
        {
            try
            {
                modbus.Connect("127.0.0.1", 502);
            }
            catch (Exception ex)
            {
            }

            List<CasstteConverter.Data.clsMemoryAddress> modbus_linked_addresses = CIMDevices.casstteConverter_1.LinkBitMap.FindAll(mem => mem.EOwner == OWNER.EQP && mem.Link_Modbus_Register_Number != -1);
            List<CasstteConverter.Data.clsMemoryAddress> DI_modbus_linked_addresses = CIMDevices.casstteConverter_1.LinkBitMap.FindAll(mem => mem.EOwner == OWNER.CIM && mem.Link_Modbus_Register_Number != -1);
            List<CasstteConverter.Data.clsMemoryAddress> word_address = CIMDevices.casstteConverter_1.LinkWordMap.FindAll(mem => mem.Link_Modbus_Register_Number != -1).OrderBy(mem => mem.Link_Modbus_Register_Number).ToList();

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


            //var DiSource = new BindingSource();
            //DiSource.DataSource = DigitalInputs;
            //dgvDI_EQPLC.DataSource = DiSource;

            //var DoSource = new BindingSource();
            //DoSource.DataSource = DigitalOutputs;
            //dgvDO_AGVS.DataSource = DoSource;

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

    }
}
