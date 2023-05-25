using GPMCasstteConvertCIM.Devices;
using GPMCasstteConvertCIM.GPM_SECS;
using GPMCasstteConvertCIM.Utilities;
using Secs4Net;
using Secs4Net.Sml;
using static Secs4Net.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPMCasstteConvertCIM.CasstteConverter;
using System.Diagnostics;
using static GPMCasstteConvertCIM.GPM_SECS.SECSMessageHelper;
using GPMCasstteConvertCIM.Alarm;
using System.Xml.Linq;
using System.Windows.Forms;

namespace GPMCasstteConvertCIM.GPM_SECS.SecsMessageHandle
{
    public class MCSMessageHandler
    {
        private static SECSBase AGVS => DevicesManager.secs_client_for_agvs;
        internal static void PrimaryMessageOnReceivedAsync(object? sender, PrimaryMessageWrapper _primaryMessageWrapper)
        {
            var secs_client = sender as SECSBase;
            using SecsMessage _primaryMessage = _primaryMessageWrapper.PrimaryMessage;

            bool reply = false;

            if (_primaryMessage.S == 2 && _primaryMessage.F == 41)
            {
                _primaryMessage.TryGetRCMDAction_S2F41(out RCMD cmd, out Item parameterGroups);
                if (cmd == RCMD.PORTTYPECHG)
                {
                    PortTypeChangeHandler(parameterGroups, _primaryMessageWrapper);
                    return;
                }
                if (cmd == RCMD.NOTRANSFER)
                {
                    NoTransferHandler(_primaryMessageWrapper);
                    return;
                }
            }


            TransmitMsgToAGVS(_primaryMessageWrapper);

        }

        private static void NoTransferHandler(PrimaryMessageWrapper _primaryMessageWrapper)
        {
            // 2023 / 5 / 25 下午 04:03:38 | SECS_MSG_TRANSFER | Primary Mesaage From MCS: MCS_To_CIM: 'S2F41'W
            //    < L[2]
            //        < A[16] 'NOTRANSFERNOTIFY' >
            //        < L[2]
            //            < L[2]
            //                < A[9] 'CARRIERID' >
            //                < A[10] 'TA12E28469' >
            //            >
            //            < L[2]
            //                < A[10] 'CARRIERLOC' >
            //                < A[18] '3F_AGVC02_PORT_2_5' >
            //            >
            //        >
            //    >
            //.
            try
            {
                Item Params = _primaryMessageWrapper.PrimaryMessage.SecsItem.Items[1];
                SecsMessage S2F42 = new SecsMessage(2, 42, false)
                {
                    SecsItem = L(

                                B(0),
                                Params
                        )
                };
                _primaryMessageWrapper.TryReplyAsync(S2F42);

                string cstid = Params.Items[0].Items[1].GetString();

                Utility.SystemLogger.Info("NOTRANSFER, PORT = ");
            }
            catch (Exception ex)
            {
                Utility.SystemLogger.Info($"NOTRANSFER, EX = {ex.Message} ");
            }


        }

        /// <summary>
        /// 
        ///L(
        ///  L(
        ///     A('PORTID')
        ///     A('port ID')
        ///   )
        ///
        ///  L(
        ///     A('PORTUNITTYPE')
        ///     U2(0) //0:input,1:output
        ///   )
        ///)
        /// </summary>
        /// <param name="parameterGroups"></param>
        /// <param name="_primaryMessageWrapper"></param>
        private async static void PortTypeChangeHandler(Item parameterGroups, PrimaryMessageWrapper _primaryMessageWrapper)
        {
            string port_id = parameterGroups.Items[0].Items[1].GetString();
            ushort port_type = parameterGroups.Items[1].Items[1].FirstValue<ushort>();
            clsConverterPort port = DevicesManager.GetPortByPortID(port_id);
            bool accept = await port.ModeChangeRequestHandshake(port_type == 0 ? PortUnitType.Input : PortUnitType.Output);

            //TODO SEND REPLY TO MCS(PORTTYPECHANGE ack)
            await _primaryMessageWrapper.TryReplyAsync(new SecsMessage(2, 42, false)
            {
            });
        }

        private static async void TransmitMsgToAGVS(PrimaryMessageWrapper _primaryMessageWrapper)
        {
            try
            {
                var primaryMsgFromMcs = _primaryMessageWrapper.PrimaryMessage;
                _primaryMessageWrapper.PrimaryMessage.Name = "MCS_To_CIM";
                Utility.SystemLogger.SecsTransferLog($"Primary Mesaage From MCS : {primaryMsgFromMcs.ToSml()}");


                SecsMessage replyMessage;
                var S = primaryMsgFromMcs.S;
                var F = primaryMsgFromMcs.F;
                var Name = $"S{S}F{F}";

                if (S == 1 && F == 13)
                {
                    SecsMessage Establish_Communication_Request_DENIED_Acknowledge = new SecsMessage(1, 14, false)
                    {
                        SecsItem = L(
                                B(1),
                                L(
                                    A(""),
                                    A("")
                                 )
                            )
                    };
                    if (AGVS.connector == null)
                    {
                        Utility.SystemLogger.SecsTransferLog($"AGVS Not Connected, Send S1F14  COMMACK =1 (Denied)");
                        _primaryMessageWrapper.TryReplyAsync(Establish_Communication_Request_DENIED_Acknowledge);
                        return;
                    }
                    if (AGVS.connector.State != ConnectionState.Selected)
                    {
                        Utility.SystemLogger.SecsTransferLog($"AGVS Not Selected, Send S1F14  COMMACK =1 (Denied)");
                        _primaryMessageWrapper.TryReplyAsync(Establish_Communication_Request_DENIED_Acknowledge);
                        return;
                    }
                }

                if (S == 1 && F == 3)
                {
                    Utility.SystemLogger.SecsTransferLog($"Start Transfer To AGVS[{Name}]");
                    replyMessage = await S1F3RequestHandle(primaryMsgFromMcs);
                }
                else
                {
                    Utility.SystemLogger.SecsTransferLog($"Start Transfer To AGVS[{Name}]");
                    replyMessage = await AGVS.ActiveSendMsgAsync(primaryMsgFromMcs);

                }
                if (replyMessage == null)
                {
                    _AddAlarm(ALARM_CODES.TRANSFER_MCS_MSG_TO_AGVS_BUT_AGVS_NO_REPLY);
                }
                else
                {
                    Utility.SystemLogger.SecsTransferLog($"AGVS Reply : {replyMessage.ToSml()}");
                    //回傳給MCS

                    bool reply_to_mcs_succss = await _primaryMessageWrapper.TryReplyAsync(replyMessage);
                    if (reply_to_mcs_succss)
                        Utility.SystemLogger.SecsTransferLog($"Message Reply to MCS Finish");
                    else
                    {
                        Utility.SystemLogger.SecsTransferLog($"Message Reply to MCS Fail..");
                        _AddAlarm(ALARM_CODES.AGVS_REPLY_MCS_MSG_BUT_ERROR_WHEN_REPLY_TO_MCS);
                    }
                }

            }
            catch (Exception ex)
            {

                Utility.SystemLogger.SecsTransferLog($"Transfer Exception (MCS -> AGVS) ! [{ex}]");
                _AddAlarm(ALARM_CODES.CODE_EXCEPTION_WHEN_TRANSFER_MSG_TO_AGVS);
            }

        }

        /// <summary>
        /// 處理S1F3 , SVID 2005/2007/2009 是CIM要處理的
        /// 流程:
        /// 1. 移除2005/2007/2009之後送給KGS，得到回覆Msg
        /// 2. CIM 處理 2005/2007/2009
        /// 3. 根據 MCS 下發的 VID順序把KGS跟CIM的資料灌到S1F4裡面
        /// </summary>
        /// <param name="primaryMsgFromMcs"></param>
        /// <returns></returns>
        public static async Task<SecsMessage> S1F3RequestHandle(SecsMessage primaryMsgFromMcs)
        {
            try
            {
                List<(ushort vid, Item secs_item)> svid_data_store = new List<(ushort vid, Item secs_item)>();
                List<Item> svid_items = primaryMsgFromMcs.SecsItem.Items.ToList();

                List<Item> itemsToCIM = svid_items.FindAll(item => item.FirstValue<ushort>() is 2005 or 2007 or 2009);
                if (itemsToCIM.Count > 0)
                {
                    foreach (var item in itemsToCIM)
                    {
                        var sid = item.FirstValue<ushort>();
                        if (sid is 2005)    //CurrentPortStates
                        {
                            svid_data_store.Add((2005, L(CreateCurrentPortStatesItem())));
                        }
                        else if (sid is 2007) //CurrEqPortStatus
                        {
                            svid_data_store.Add((2007, L(CreateCurrEqPortStatusItem())));
                        }
                        else if (sid is 2009) //PortTypes
                        {
                            svid_data_store.Add((2009, L(CreatePortInfosItem())));
                        }
                    }
                    Utility.SystemLogger?.Info($"CIM Create VIDS ({svid_data_store.ToJson()}) Data Content Done");
                }
                List<Item> itemsToAGVS = svid_items.FindAll(item => item.FirstValue<ushort>() is not 2005 and not 2007 and not 2009);
                if (itemsToAGVS.Count != 0)
                {
                    List<Item> toAGVSItems = new List<Item>();
                    foreach (var item in itemsToAGVS)
                        toAGVSItems.Add(U2(item.FirstValue<ushort>()));

                    SecsMessage? AGVSReplyMessage = await AGVS.ActiveSendMsgAsync(new SecsMessage(1, 3)
                    {
                        SecsItem = L(toAGVSItems)
                    });


                    for (int i = 0; i < itemsToAGVS.Count; i++)
                    {
                        try
                        {
                            svid_data_store.Add((itemsToAGVS[i].FirstValue<ushort>(), AGVSReplyMessage.SecsItem.Items[i]));
                        }
                        catch (Exception ex)
                        {
                            Utility.SystemLogger?.Info($"Convert secs data from mcs FAIL.{itemsToAGVS[i].ToJson()}\r\n{ex.Message}");
                        }
                    }

                }
                //Combined
                List<Item> datas = new List<Item>();


                foreach (Item? item in svid_items)
                {
                    ushort svid = item.FirstValue<ushort>();
                    (ushort vid, Item secs_item) item_store = svid_data_store.FirstOrDefault(v => v.vid == svid);

                    if (item_store.secs_item != null)
                    {
                        if (item_store.vid == 2004)
                        {

                            List<Item>? ori = item_store.secs_item.Items.ToList();
                            Utility.SystemLogger.Info($"SV2004 Expand. Add Port Carrier Info,{ori.Count} ");
                            Item[]? portInfos = CreateEnhancedCarrierInfo();
                            ori.AddRange(portInfos);
                            Item newItem = L(ori);
                            datas.Add(newItem);
                            Utility.SystemLogger.Info($"SV2004 Expand Done,{ori.Count} ");

                        }
                        else
                        {
                            datas.Add(item_store.secs_item);
                        }
                    }
                }

                var replyMessage = new SecsMessage(1, 4, false)
                {
                    Name = "Selected Equipment Status Reply",
                    SecsItem = L(datas)
                };

                Utility.SystemLogger?.Info($"S1F3 Reply Message Create Done:\r\n{replyMessage.ToSml()}");

                return replyMessage;
            }
            catch (Exception ex)
            {
                Utility.SystemLogger.Error("S1F3RequestHandle", ex);
                _AddAlarm(ALARM_CODES.CIM_HANDLE_S1F3_OCCUR_ERROR);
                return new SecsMessage(1, 4, false) { };
            }

        }
        public static void AddPortDataToVID2004(ref SecsMessage message)
        {
        }
        private static Item[] CreateCurrEqPortStatusItem()
        {

            //<L[4]
            //<PortID>
            //<PortTransferState>
            //<EqReqSatus>
            //<EqPresenceStatus> >
            List<clsConverterPort> ports = DevicesManager.GetAllPorts();
            ports = ports.OrderBy(p => p.Properties.PortID).ToList();
            Item GetCurrEqPortStatus(clsConverterPort port)
            {
                return L(
                            A(port.Properties.PortID),
                            U2((ushort)(port.Properties.InSerivce ? 1 : 0)),
                            U2((ushort)(!port.LoadRequest && !port.UnloadRequest ? 0 : port.LoadRequest ? 1 : 2)),
                            U2(0)

                        );
            }
            return ports.Select(port => GetCurrEqPortStatus(port)).ToArray();

        }

        private static Item[] CreateEnhancedCarrierInfo()
        {
            List<clsConverterPort> ports = DevicesManager.GetAllPorts();
            ports = ports.OrderBy(p => p.Properties.PortID).ToList();
            Item CarrierInfo(clsConverterPort port)
            {
                return L(
                            A(port.WIPINFO_BCR_ID),
                            A(port.Properties.PortID),
                            A(""),
                            A(port.CarrierInstallTime.ToString("yyyyMMddHHmmssff")),
                            U2((ushort)(port.PortType == 0 ? 0 : 4))
                        );
            }
            return ports.Select(port => CarrierInfo(port)).ToArray();

        }

        private static Item[] CreateCurrentPortStatesItem()
        {
            //< L[2]
            //  A <PortID>
            //  U2<PortTransferState> 0=out of service; 1= in service
            List<clsConverterPort> ports = DevicesManager.GetAllPorts();
            ports = ports.OrderBy(p => p.Properties.PortID).ToList();

            Item GetPortType(clsConverterPort port)
            {
                return L(
                            A(port.Properties.PortID),
                            U2((ushort)(port.Properties.InSerivce ? 1 : 0))
                        );
            }

            return ports.Select(port => GetPortType(port)).ToArray();
        }

        private static Item[] CreatePortInfosItem()
        {
            //< L[2]
            //  A <PortID>
            //  U2<PortUnitType> 0=Input ; 1=Output
            List<clsConverterPort> ports = DevicesManager.GetAllPorts();
            ports = ports.OrderBy(p => p.Properties.PortID).ToList();
            Item GetPortTypeInfo(clsConverterPort port)
            {
                return L(
                            A(port.Properties.PortID),
                            U2((ushort)port.Properties.PortType)
                        );
            }

            return ports.Select(port => GetPortTypeInfo(port)).ToArray();
        }

        private static void _AddAlarm(ALARM_CODES alarm_code)
        {
            AlarmManager.AddAlarm(alarm_code, "MCSMessage Transfer");
        }
    }
}
