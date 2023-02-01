using CommunityToolkit.HighPerformance.Buffers;
using GPMCasstteConvertCIM.CasstteConverter.Data;
using GPMCasstteConvertCIM.CIM;
using GPMCasstteConvertCIM.UI_UserControls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static GPMCasstteConvertCIM.CasstteConverter.EnumSTATES;

namespace GPMCasstteConvertCIM.CasstteConverter
{
    public class clsCasstteConverter : ISECSHandShakeable
    {
        internal bool simulation_mode = true;
        private string BitMapFileName_EQ = "src\\PLC_Bit_Map_EQ.csv";
        private string WordMapFileName_EQ = "src\\PLC_Word_Map_EQ.csv";
        private string BitMapFileName_CIM = "src\\PLC_Bit_Map_CIM.csv";
        private string WordMapFileName_CIM = "src\\PLC_Word_Map_CIM.csv";
        internal clsCasstteConverter(int index, UscCasstteConverter mainGUI)
        {
            this.index = index;
            LoadPLCMapData();
            this.mainGUI = mainGUI;
            this.mainGUI.casstteConverter = this;
            PLCMemorySyncTask();
            DataSyncTask();

            Handshaker = new EQPHandShakeHandler(this);
        }
        internal EQPHandShakeHandler Handshaker;


        internal List<clsMemoryAddress> LinkBitMap { get; private set; } = new List<clsMemoryAddress>();
        internal List<clsMemoryAddress> LinkWordMap { get; private set; } = new List<clsMemoryAddress>();

        internal List<clsMemoryAddress> WIP_Port1_BCR_ID_Addresses => LinkWordMap.FindAll(ad => ad.PropertyName.Contains("WIPInfo_Port1_BCR_ID_"));
        internal List<clsMemoryAddress> WIP_LOC_ID_Addresses => LinkWordMap.FindAll(ad => ad.PropertyName.Contains("WIPInfo_Loc_ID_"));
        internal List<clsMemoryAddress> ManualLoad_BCR_ID_Addresses => LinkWordMap.FindAll(ad => ad.PropertyName.Contains("ManualLoad_BCR_ID"));
        internal List<clsMemoryAddress> ManuaUnlLoad_BCR_ID_Addresses => LinkWordMap.FindAll(ad => ad.PropertyName.Contains("ManualUnload_BCR_ID"));
        internal clsMemoryAddress EQPInterfaceClockAddress => LinkWordMap.FirstOrDefault(lp => lp.EOwner == clsMemoryAddress.OWNER.EQP && lp.PropertyName == "InterfaceClock");

        internal string CIMWordStartAddress => LinkWordMap.FirstOrDefault(lp => lp.EOwner == clsMemoryAddress.OWNER.CIM)?.Address;
        internal string CIMWordEndAddress => LinkWordMap.LastOrDefault(lp => lp.EOwner == clsMemoryAddress.OWNER.CIM)?.Address;


        internal string CIMBitStartAddress => LinkBitMap.FirstOrDefault(lp => lp.EOwner == clsMemoryAddress.OWNER.CIM)?.Address;
        internal string CIMBitEndAddress => LinkBitMap.LastOrDefault(lp => lp.EOwner == clsMemoryAddress.OWNER.CIM)?.Address;

        internal string EQPWordStartAddress => LinkWordMap.FirstOrDefault(lp => lp.EOwner == clsMemoryAddress.OWNER.EQP)?.Address;
        internal string EQPWordEndAddress => LinkWordMap.LastOrDefault(lp => lp.EOwner == clsMemoryAddress.OWNER.EQP)?.Address;

        internal string EQPBitStartAddress => LinkBitMap.FirstOrDefault(lp => lp.EOwner == clsMemoryAddress.OWNER.EQP)?.Address;
        internal string EQPBitEndAddress => LinkBitMap.LastOrDefault(lp => lp.EOwner == clsMemoryAddress.OWNER.EQP)?.Address;

        public McInterfaceOptions mcInterfaceOptions { get; private set; } = new McInterfaceOptions();
        internal clsMCE71Interface? mcInterface = new clsMCE71Interface();

        private Task? RetryTask;
        private Common.CONNECTION_STATE _connectionState = Common.CONNECTION_STATE.DISCONNECTED;

        public int index { get; }

        internal UscCasstteConverter mainGUI;
        internal bool monitor = true;

        #region 事件

        public event EventHandler<EventArgs> EQPOnline_Local_OnRequest;
        public event EventHandler<EventArgs> EQPOnline_Remote_OnRequest;
        public event EventHandler<EventArgs> EQPOffline_OnRequset;

        #endregion


        internal Common.CONNECTION_STATE connectionState
        {
            get => _connectionState;
            set
            {
                if (_connectionState != value)
                {
                    _connectionState = value;
                    ConnectionStateChanged?.Invoke(this, _connectionState);
                }
            }
        }
        internal bool Connected { get; private set; }
        internal Data.clsEQPData EQPData { get; private set; } = new Data.clsEQPData(2);
        internal Data.clsAGVSData AGVSData { get; private set; } = new Data.clsAGVSData();

        internal event EventHandler<Common.CONNECTION_STATE>? ConnectionStateChanged;
        internal clsMemoryGroupOptions EQPMemOptions { get; private set; }
        internal clsMemoryGroupOptions CIMMemOptions { get; private set; }

        internal async Task<bool> ActiveAsync(McInterfaceOptions mcInterfaceOptions)
        {
            await Task.Delay(1);
            try
            {
                connectionState = Common.CONNECTION_STATE.CONNECTING;
                this.mcInterfaceOptions = mcInterfaceOptions;
                int connRetCode = -1;

                bool connected = await Task.Run(() =>
                {
                    return mcInterface.Open(mcInterfaceOptions, out connRetCode, enuDataType: clsMC_TCPCnt.enuDataType.ByteArr_02);
                });
                connectionState = connRetCode == 0 ? Common.CONNECTION_STATE.CONNECTED : Common.CONNECTION_STATE.DISCONNECTED;

                if (connectionState != Common.CONNECTION_STATE.CONNECTED)
                {
                    if (RetryTask == null)
                        RetryConnectAsync();
                }
                return connected;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private async void RetryConnectAsync()
        {
            await Task.Delay(1);
            RetryTask = Task.Run(async () =>
            {
                while (!await ActiveAsync(mcInterfaceOptions))
                {
                    Thread.Sleep(1000);
                }
                RetryTask = null;
            });
        }

        private void DataSyncTask()
        {
            _ = Task.Run(async () =>
            {
                while (true)
                {
                    await Task.Delay(1);
                    //TODO 資料解析
                    Stopwatch stopwatch = Stopwatch.StartNew();
                    SyncMemData();
                    stopwatch.Stop();
                    if (index == 0)
                    {

                    }
                }
            });
        }
        private async Task PLCMemorySyncTask()
        {
            _ = Task.Run(async () =>
            {

                CIMBitStartAddress.SplitAddress(true, out string bit_regionName, out int bit_start_address);
                CIMBitEndAddress.SplitAddress(true, out _, out int bit_end_address);
                int cimBitNumber = bit_end_address - bit_start_address + 1;
                CIMWordStartAddress.SplitAddress(true, out string cim_word_regionName, out int cim_word_start_address);
                CIMWordEndAddress.SplitAddress(true, out _, out int cim_word_end_address);
                int cimWordNumber = cim_word_end_address - cim_word_start_address + 1;
                EQPBitStartAddress.SplitAddress(true, out string eqp_bit_regionName, out int eqp_bit_start_address);
                EQPBitEndAddress.SplitAddress(true, out _, out int eqp_bit_end_address);
                int eqpBitNumber = eqp_bit_end_address - eqp_bit_start_address + 1;
                EQPWordStartAddress.SplitAddress(true, out string eqp_word_regionName, out int eqp_word_start_address);
                EQPWordEndAddress.SplitAddress(true, out _, out int eqp_word_end_address);
                int eqpWordNumber = eqp_word_end_address - eqp_word_start_address + 1;

                while (true)
                {
                    try
                    {
                        Thread.Sleep(10);
                        if (_connectionState != Common.CONNECTION_STATE.CONNECTED)
                        {
                            //SyncMemData();
                            continue;
                        }
                        Stopwatch sw = Stopwatch.StartNew();
                        if (!simulation_mode)
                        {
                            int ret_code = -1;
                            try
                            {
                                ret_code = mcInterface.WriteBit(ref CIMMemOptions.memoryTable, CIMMemOptions.bitRegionName, CIMMemOptions.bitStartAddress_no_region, CIMMemOptions.bitSize);
                                ret_code = mcInterface.WriteWord(ref CIMMemOptions.memoryTable, CIMMemOptions.wordRegionName, CIMMemOptions.wordStartAddress_no_region, CIMMemOptions.wordSize);
                                if (monitor)
                                {
                                    ret_code = mcInterface.ReadBit(ref EQPMemOptions.memoryTable, EQPMemOptions.bitRegionName, EQPMemOptions.bitStartAddress_no_region, EQPMemOptions.bitSize);
                                    ret_code = mcInterface.ReadWord(ref EQPMemOptions.memoryTable, EQPMemOptions.wordRegionName, EQPMemOptions.wordStartAddress_no_region, EQPMemOptions.wordSize);
                                }

                                if (ret_code == 0)
                                {

                                }
                            }
                            catch (Exception ex)
                            {
                                //RetryConnectAsync();
                                continue;
                            }

                        }
                        sw.Stop();

                    }
                    catch (Exception ex)
                    {
                    }

                }
            });
        }

        private void SyncMemData()
        {

            foreach (var item in LinkWordMap)
            {

                if (item.EOwner == clsMemoryAddress.OWNER.EQP)
                {
                    item.Value = EQPMemOptions.memoryTable.ReadBinary(item.Address);
                    //EQPData.TrySetPropertyValue(item.PropertyName, item.Value, out bool valChanged);
                }
                else
                {
                    item.Value = CIMMemOptions.memoryTable.ReadBinary(item.Address);
                    //AGVSData.TrySetPropertyValue(item.PropertyName, item.Value, out bool valChanged);
                }
            }


            bool[] cim_bit_states = new bool[CIMMemOptions.bitSize];
            int[] cim_word_datas = new int[CIMMemOptions.wordSize];

            bool[] eqp_bit_states = new bool[EQPMemOptions.bitSize];
            int[] eqp_word_datas = new int[EQPMemOptions.wordSize];

            CIMMemOptions.memoryTable.ReadBit(CIMMemOptions.bitStartAddress, CIMMemOptions.bitSize, ref cim_bit_states);
            CIMMemOptions.memoryTable.ReadWord(CIMMemOptions.wordStartAddress, CIMMemOptions.wordSize, ref cim_word_datas);
            EQPMemOptions.memoryTable.ReadBit(EQPMemOptions.bitStartAddress, EQPMemOptions.bitSize, ref eqp_bit_states);
            EQPMemOptions.memoryTable.ReadWord(EQPMemOptions.wordStartAddress, EQPMemOptions.wordSize, ref eqp_word_datas);

            List<clsMemoryAddress> cimBitData = LinkBitMap.FindAll(v => v.EOwner == clsMemoryAddress.OWNER.CIM);
            List<clsMemoryAddress> eqpBitData = LinkBitMap.FindAll(v => v.EOwner == clsMemoryAddress.OWNER.EQP);

            List<clsMemoryAddress> cimWordData = LinkWordMap.FindAll(v => v.EOwner == clsMemoryAddress.OWNER.CIM);
            List<clsMemoryAddress> eqpWordData = LinkWordMap.FindAll(v => v.EOwner == clsMemoryAddress.OWNER.EQP);

            for (int i = 0; i < cim_bit_states.Length; i++)
            {
                cimBitData[i].Value = cim_bit_states[i];
            }

            for (int i = 0; i < cim_word_datas.Length; i++)
            {
                cimWordData[i].Value = cim_word_datas[i];
            }


            for (int i = 0; i < eqp_bit_states.Length; i++)
            {
                eqpBitData[i].Value = eqp_bit_states[i];
            }
            for (int i = 0; i < eqp_word_datas.Length; i++)
            {
                eqpWordData[i].Value = eqp_word_datas[i];
            }



            //EQP 
            EQPData.EQP_RUN = (bool)LinkBitMap.First(f => f.EScope == EQ_SCOPE.EQ && f.EProperty == PROPERTY.EQP_RUN).Value;
            EQPData.EQP_IDLE = (bool)LinkBitMap.First(f => f.EScope == EQ_SCOPE.EQ && f.EProperty == PROPERTY.EQP_IDLE).Value;
            EQPData.EQP_DOWN = (bool)LinkBitMap.First(f => f.EScope == EQ_SCOPE.EQ && f.EProperty == PROPERTY.EQP_DOWN).Value;
            EQPData.InterfaceClock = (int)LinkWordMap.First(f => f.EScope == EQ_SCOPE.EQ && f.EProperty == PROPERTY.Interface_Clock).Value;
            EQPData.EQP_ON_OFFLine_Mode_Status = (int)LinkWordMap.First(f => f.EScope == EQ_SCOPE.EQ && f.EProperty == PROPERTY.EQP_ON_OFFLine_Mode_Status).Value;
            EQPData.Warning_Report_Index = (int)LinkWordMap.First(f => f.EScope == EQ_SCOPE.EQ && f.EProperty == PROPERTY.Warning_Report_Index).Value;
            EQPData.Warning_Code_1_16 = (int)LinkWordMap.First(f => f.EScope == EQ_SCOPE.EQ && f.EProperty == PROPERTY.Warning_Code_1_16).Value;
            EQPData.Warning_Code_17_32 = (int)LinkWordMap.First(f => f.EScope == EQ_SCOPE.EQ && f.EProperty == PROPERTY.Warning_Code_17_32).Value;
            EQPData.Warning_Code_33_48 = (int)LinkWordMap.First(f => f.EScope == EQ_SCOPE.EQ && f.EProperty == PROPERTY.Warning_Code_33_48).Value;
            EQPData.Alarm_Report_Index = (int)LinkWordMap.First(f => f.EScope == EQ_SCOPE.EQ && f.EProperty == PROPERTY.Alarm_Report_Index).Value;
            EQPData.Alarm_Code_1_16 = (int)LinkWordMap.First(f => f.EScope == EQ_SCOPE.EQ && f.EProperty == PROPERTY.Alarm_Code_1_16).Value;
            EQPData.Alarm_Code_17_32 = (int)LinkWordMap.First(f => f.EScope == EQ_SCOPE.EQ && f.EProperty == PROPERTY.Alarm_Code_17_32).Value;
            EQPData.Alarm_Code_33_48 = (int)LinkWordMap.First(f => f.EScope == EQ_SCOPE.EQ && f.EProperty == PROPERTY.Alarm_Code_33_48).Value;

            //PORTS
            EQ_SCOPE[] Ports = new EQ_SCOPE[2] { EQ_SCOPE.PORT1, EQ_SCOPE.PORT2 };
            for (int i = 0; i < Ports.Length; i++)
            {
                EQ_SCOPE port = Ports[i];

                //bit data
                EQPData.PortDatas[i].L_REQ = (bool)LinkBitMap.First(f => f.EScope == port && f.EProperty == PROPERTY.L_REQ).Value;
                EQPData.PortDatas[i].U_REQ = (bool)LinkBitMap.First(f => f.EScope == port && f.EProperty == PROPERTY.U_REQ).Value;
                EQPData.PortDatas[i].EQ_READY = (bool)LinkBitMap.First(f => f.EScope == port && f.EProperty == PROPERTY.EQ_READY).Value;
                EQPData.PortDatas[i].EQ_BUSY = (bool)LinkBitMap.First(f => f.EScope == port && f.EProperty == PROPERTY.EQ_BUSY).Value;
                EQPData.PortDatas[i].LoadRequest = (bool)LinkBitMap.First(f => f.EScope == port && f.EProperty == PROPERTY.Load_Request).Value;
                EQPData.PortDatas[i].UnloadRequest = (bool)LinkBitMap.First(f => f.EScope == port && f.EProperty == PROPERTY.Unload_Request).Value;

                EQPData.PortDatas[i].PortExist = (bool)LinkBitMap.First(f => f.EScope == port && f.EProperty == PROPERTY.Port_Exist).Value;
                EQPData.PortDatas[i].PortStatusDown = (bool)LinkBitMap.First(f => f.EScope == port && f.EProperty == PROPERTY.Port_Status_Down).Value;
                EQPData.PortDatas[i].LD_UP_POS = (bool)LinkBitMap.First(f => f.EScope == port && f.EProperty == PROPERTY.LD_UP_POS).Value;
                EQPData.PortDatas[i].LD_DOWN_POS = (bool)LinkBitMap.First(f => f.EScope == port && f.EProperty == PROPERTY.LD_DOWN_POS).Value;
                EQPData.PortDatas[i].DoorOpened = (bool)LinkBitMap.First(f => f.EScope == port && f.EProperty == PROPERTY.Door_Opened).Value;

                EQPData.PortDatas[i].CarrierWaitINSystemRequest = (bool)LinkBitMap.First(f => f.EScope == port && f.EProperty == PROPERTY.Carrier_WaitIn_System_Request).Value;
                EQPData.PortDatas[i].CarrierWaitOUTSystemRequest = (bool)LinkBitMap.First(f => f.EScope == port && f.EProperty == PROPERTY.Carrier_WaitOut_System_Report).Value;
                EQPData.PortDatas[i].CarrierRemovedCompletedReport = (bool)LinkBitMap.First(f => f.EScope == port && f.EProperty == PROPERTY.Carrier_Removed_Completed_Report).Value;

                EQPData.PortDatas[i].Port_Mode_Change_Accept = (bool)LinkBitMap.First(f => f.EScope == port && f.EProperty == PROPERTY.Port_Mode_Change_Accept).Value;
                EQPData.PortDatas[i].Port_Mode_Changed_Refuse = (bool)LinkBitMap.First(f => f.EScope == port && f.EProperty == PROPERTY.Port_Mode_Changed_Refuse).Value;
                EQPData.PortDatas[i].Port_Mode_Changed_Report = (bool)LinkBitMap.First(f => f.EScope == port && f.EProperty == PROPERTY.Port_Mode_Changed_Report).Value;
                EQPData.PortDatas[i].Port_Disabled_Report = (bool)LinkBitMap.First(f => f.EScope == port && f.EProperty == PROPERTY.Port_Disabled_Report).Value;
                EQPData.PortDatas[i].Port_Enabled_Report = (bool)LinkBitMap.First(f => f.EScope == port && f.EProperty == PROPERTY.Port_Enabled_Report).Value;

                //word data
                EQPData.PortDatas[i].PortModeStatus = (int)LinkWordMap.First(f => f.EScope == port && f.EProperty == PROPERTY.Port_Type_Status).Value;
                EQPData.PortDatas[i].Port_Auto_Manual_Mode_Status = (int)LinkWordMap.First(f => f.EScope == port && f.EProperty == PROPERTY.Port_Auto_Manual_Mode_Status).Value;
                EQPData.PortDatas[i].WIPInfo_BCR_ID_1 = (int)LinkWordMap.First(f => f.EScope == port && f.EProperty == PROPERTY.WIP_Information_BCR_1).Value;
                EQPData.PortDatas[i].WIPInfo_BCR_ID_2 = (int)LinkWordMap.First(f => f.EScope == port && f.EProperty == PROPERTY.WIP_Information_BCR_2).Value;
                EQPData.PortDatas[i].WIPInfo_BCR_ID_3 = (int)LinkWordMap.First(f => f.EScope == port && f.EProperty == PROPERTY.WIP_Information_BCR_3).Value;
                EQPData.PortDatas[i].WIPInfo_BCR_ID_4 = (int)LinkWordMap.First(f => f.EScope == port && f.EProperty == PROPERTY.WIP_Information_BCR_4).Value;
                EQPData.PortDatas[i].WIPInfo_BCR_ID_5 = (int)LinkWordMap.First(f => f.EScope == port && f.EProperty == PROPERTY.WIP_Information_BCR_5).Value;
                EQPData.PortDatas[i].WIPInfo_BCR_ID_6 = (int)LinkWordMap.First(f => f.EScope == port && f.EProperty == PROPERTY.WIP_Information_BCR_6).Value;
                EQPData.PortDatas[i].WIPInfo_BCR_ID_7 = (int)LinkWordMap.First(f => f.EScope == port && f.EProperty == PROPERTY.WIP_Information_BCR_7).Value;
                EQPData.PortDatas[i].WIPInfo_BCR_ID_8 = (int)LinkWordMap.First(f => f.EScope == port && f.EProperty == PROPERTY.WIP_Information_BCR_8).Value;
                EQPData.PortDatas[i].WIPInfo_BCR_ID_9 = (int)LinkWordMap.First(f => f.EScope == port && f.EProperty == PROPERTY.WIP_Information_BCR_9).Value;
                EQPData.PortDatas[i].WIPInfo_BCR_ID_10 = (int)LinkWordMap.First(f => f.EScope == port && f.EProperty == PROPERTY.WIP_Information_BCR_10).Value;
            }

        }

        internal AUTO_MANUAL_MODE RackMode { get; private set; } = AUTO_MANUAL_MODE.MANUAL;
        internal PORT_MODE PortMode { get; private set; } = PORT_MODE.INOUT;
        /// <summary>
        /// 手動/自動模式切換請求
        /// </summary>
        internal event EventHandler<AUTO_MANUAL_MODE> RackModeChangeOnRequest;

        /// <summary>
        /// 開啟模擬器
        /// </summary>
        internal void OpenSimulatorUI()
        {
            mainGUI?.OpenConvertPLCSumulator();
        }
        private void LoadPLCMapData()
        {
            try
            {
                LoadLinkMapData(BitMapFileName_EQ, WordMapFileName_EQ, out List<clsMemoryAddress> eq_bit_link_map, out List<clsMemoryAddress> eq_word_link_map);
                LoadLinkMapData(BitMapFileName_CIM, WordMapFileName_CIM, out List<clsMemoryAddress> cim_bit_link_map, out List<clsMemoryAddress> cim_word_link_map);

                LinkBitMap.AddRange(cim_bit_link_map);
                LinkBitMap.AddRange(eq_bit_link_map);

                LinkWordMap.AddRange(cim_word_link_map);
                LinkWordMap.AddRange(eq_word_link_map);

                string eqp_bitStartAddress = LinkBitMap.First(i => i.EOwner == clsMemoryAddress.OWNER.EQP).Address;
                string eqp_bitEndAddress = LinkBitMap.Last(i => i.EOwner == clsMemoryAddress.OWNER.EQP).Address;
                string eqp_wordStartAddress = LinkWordMap.First(i => i.EOwner == clsMemoryAddress.OWNER.EQP).Address;
                string eqp_wordEndAddress = LinkWordMap.Last(i => i.EOwner == clsMemoryAddress.OWNER.EQP).Address;

                string cim_bitStartAddress = LinkBitMap.First(i => i.EOwner == clsMemoryAddress.OWNER.CIM).Address;
                string cim_bitEndAddress = LinkBitMap.Last(i => i.EOwner == clsMemoryAddress.OWNER.CIM).Address;
                string cim_wordStartAddress = LinkWordMap.First(i => i.EOwner == clsMemoryAddress.OWNER.CIM).Address;
                string cim_wordEndAddress = LinkWordMap.Last(i => i.EOwner == clsMemoryAddress.OWNER.CIM).Address;


                EQPMemOptions = new clsMemoryGroupOptions(eqp_bitStartAddress, eqp_bitEndAddress, eqp_wordStartAddress, eqp_wordEndAddress);
                CIMMemOptions = new clsMemoryGroupOptions(cim_bitStartAddress, cim_bitEndAddress, cim_wordStartAddress, cim_wordEndAddress);

            }
            catch (Exception ex)
            {
            }
        }


        private void LoadLinkMapData(string bitFile, string wordFile, out List<clsMemoryAddress> bitAddressList, out List<clsMemoryAddress> wordAddressList)
        {
            bitAddressList = new List<clsMemoryAddress>();
            wordAddressList = new List<clsMemoryAddress>();

            string temp_bitMapFile = $"bitmap_temp_{DateTime.Now.Ticks}.csv";
            string temp_wordMapFile = $"wordmap_temp_{DateTime.Now.Ticks}.csv";
            if (File.Exists(bitFile))
            {
                File.Copy(bitFile, temp_bitMapFile);
                string[] context = File.ReadAllLines(temp_bitMapFile);
                File.Delete(temp_bitMapFile);
                ArraySegment<string> context_removeHead = new ArraySegment<string>(context, 1, context.Length - 1);
                bitAddressList = context_removeHead.Select(line => CreateMemoryAddress(line, clsMemoryAddress.DATA_TYPE.BIT)).ToList();
            }
            if (File.Exists(wordFile))
            {
                File.Copy(wordFile, temp_wordMapFile);
                string[] context = File.ReadAllLines(temp_wordMapFile);
                File.Delete(temp_wordMapFile);
                ArraySegment<string> context_removeHead = new ArraySegment<string>(context, 1, context.Length - 1);
                wordAddressList = context_removeHead.Select(line => CreateMemoryAddress(line, clsMemoryAddress.DATA_TYPE.WORD)).ToList();
            }
            bitAddressList = bitAddressList.FindAll(ad => ad.Address != "").ToList();
            wordAddressList = wordAddressList.FindAll(ad => ad.Address != "").ToList();
        }

        private clsMemoryAddress CreateMemoryAddress(string context_line, clsMemoryAddress.DATA_TYPE data_type)
        {
            string[] lineSplited = context_line.Split(',');
            try
            {

                return new clsMemoryAddress(data_type)
                {
                    Address = lineSplited[0],
                    Owner = lineSplited[1],
                    DataName = lineSplited[2],
                    DataFormat = lineSplited[3],
                    Explanation = lineSplited[4],
                    Scope = lineSplited[5],
                    PropertyName = lineSplited[6],
                    Link_Modbus_Register_Number = lineSplited[7] == "" ? -1 : int.Parse(lineSplited[7]),
                };
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void ReplyHOSTOfflineRequest()
        {
        }

        public void ReplyHostOnlineRequest()
        {
        }
    }
}
