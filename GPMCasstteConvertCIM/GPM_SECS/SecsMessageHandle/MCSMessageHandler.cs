using GPMCasstteConvertCIM.Alarm;
using GPMCasstteConvertCIM.CasstteConverter;
using GPMCasstteConvertCIM.Devices;
using GPMCasstteConvertCIM.Utilities;
using Secs4Net;
using Secs4Net.Sml;
using static Secs4Net.Item;
using GPMCasstteConvertCIM.GPM_SECS;
using Microsoft.VisualBasic.Logging;

namespace GPMCasstteConvertCIM.GPM_SECS.SecsMessageHandle
{
    public class MCSMessageHandler
    {
        internal static MCSSecsLogger MCSUseLogger = new MCSSecsLogger(null, Utility.SysConfigs.Log.SyslogFolder, "SECS\\MCS");
        private static SECSBase AGVS => DevicesManager.secs_client_for_agvs;
        internal static async void PrimaryMessageOnReceivedAsync(object? sender, PrimaryMessageWrapper _primaryMessageWrapper)
        {
            var secs_client = sender as SECSBase;
            using SecsMessage _primaryMessage = _primaryMessageWrapper.PrimaryMessage;
            MCSUseLogger.MessageIn(_primaryMessage, _primaryMessageWrapper.Id);
            bool reply = false;

            if (_primaryMessage.S == 2 && (_primaryMessage.F == 41 | _primaryMessage.F == 49))
            {
                _primaryMessage.TryGetRCMDAction(_primaryMessage.F, out RCMD cmd, out Item parameterGroups);

                if (cmd == RCMD.PORTTYPECHG)
                {
                    PortTypeChangeHandler(parameterGroups, _primaryMessageWrapper);
                    return;
                }
                if (cmd == RCMD.NOTRANSFERNOTIFY)
                {
                    NoTransferHandler(_primaryMessageWrapper);
                    return;
                }
            }

            TransmitMsgToAGVS(_primaryMessageWrapper);

        }


        private static void NoTransferHandler(PrimaryMessageWrapper _primaryMessageWrapper)
        {
            try
            {
                Item Params = _primaryMessageWrapper.PrimaryMessage.SecsItem.Items[1];
                SecsMessage S2F42_Reply = new SecsMessage(2, 42, false)
                {
                    SecsItem = L(
                                B((byte)0) //command will be perform with completion signaled later by an event

                        )
                };
                _primaryMessageWrapper.TryReplyAsync(S2F42_Reply);

                string cstid = Params.Items[0].Items[1].GetString();
                string port_id = Params.Items[1].Items[1].GetString();

                Utility.SystemLogger.Info($"MCS NOTRANSFER Notify, PORT ={port_id} , CST ID = {cstid} ");

                var port = DevicesManager.GetPortByPortID(port_id);
            }
            catch (Exception ex)
            {
                Utility.SystemLogger.Info($"NOTRANSFER, EX = {ex.Message} ");
            }


        }

        /// <summary>
        /// </summary>
        /// <param name="parameterGroups"></param>
        /// <param name="_primaryMessageWrapper"></param>
        private async static void PortTypeChangeHandler(Item parameterGroups, PrimaryMessageWrapper _primaryMessageWrapper)
        {
            HCACK ack = HCACK.Acknowledge;
            string port_id = parameterGroups.Items[0].Items[1].GetString();
            ushort port_type = parameterGroups.Items[1].Items[1].FirstValue<ushort>();
            PortUnitType port_type_to_change = port_type == 0 ? PortUnitType.Input : PortUnitType.Output;
            _Log($"MCS Port Type Change Request In.  Port ID = {port_id} , Port Type = {port_type_to_change} ");
            clsConverterPort port = DevicesManager.GetPortByPortID(port_id);
            byte CPACK_PROTID = 0;
            byte CPACK_PORTTYPE = 0;
            if (port_type > 1)
                CPACK_PORTTYPE = 2;
            else
            {
                if (port == null)
                {
                    ack = HCACK.At_least_one_parameter_is_invalid;
                    _Log($"Port ID = {port_id}  Not in cim system");
                    CPACK_PROTID = 1;
                }
                else
                {
                    port.MCSReservePortType = port_type_to_change;
                    if (port.EPortType == port_type_to_change)
                    {
                        ack = HCACK.Rejected_Already_in_desired_condition;
                        _Log($"Port ( {port_id} ) already in {port_type_to_change} Mode.");
                    }
                    else
                    {
                        bool accept = await port.ModeChangeRequestHandshake(port_type_to_change);
                        ack = accept ? HCACK.Acknowledge : HCACK.Cannot_Perform_Now;
                        _Log($"Port ( {port_id} ) {(accept ? "ACCEPT" : "REJECT")}  Port Type Change Request.");
                    }
                }

            }
            SecsMessage replyMsg = null;
            if (CPACK_PORTTYPE != 0 | CPACK_PROTID != 0)
            {
                replyMsg = new SecsMessage(2, 42, false)
                {
                    SecsItem = L(
                                B((byte)HCACK.At_least_one_parameter_is_invalid),
                                L(
                                    L(
                                           A("PORTID"),
                                           B(CPACK_PROTID)
                                        )
                                    ),
                                    L(
                                          A("PORTUNITTYPE"),
                                          B(CPACK_PORTTYPE)
                                       )
                                )
                };
            }
            else
            {
                replyMsg = new SecsMessage(2, 42, false)
                {
                    SecsItem = L(
                                B((byte)ack)
                            )
                };
            }

            await _primaryMessageWrapper.TryReplyAsync(replyMsg);
            _Log($"Reply MCS Port Type Change Request : {replyMsg.ToSml()}");

            //port.PortTypeReport();
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
                                B((byte)COMMACK.Denied_Try_Again),
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

                if (S == 1 && F == 3) //Selected Equipment Status Request
                {
                    Utility.SystemLogger.SecsTransferLog($"Start Transfer To AGVS[{Name}]");
                    replyMessage = await S1F3RequestHandle(primaryMsgFromMcs);
                }
                else
                {
                    Utility.SystemLogger.SecsTransferLog($"Start Transfer To AGVS[{Name}]");
                    replyMessage = await AGVS.SendMsg(primaryMsgFromMcs, msg_name: "CIM->AGVS");

                    if (replyMessage.S == 2 && replyMessage.F == 50) //S2F49 搬運任務的回覆
                    {
                        bool AGVS_Accept_TransferTask = replyMessage.SecsItem[0].FirstValue<byte>() == 0x00;
                        if (primaryMsgFromMcs.TryParseTransferInfo(out string carrier_id, out string source, out string destine))
                        {
                            Utility.SystemLogger.Info($"AGVs {(AGVS_Accept_TransferTask ? "Accept" : "Reject")} Transfer Task (Carrier id={carrier_id},Source={source},Destine={destine})");
                            var port_wait_in = DevicesManager.GetAllPorts().FirstOrDefault(port => port.Properties.PortID == source);
                            if (port_wait_in != null)
                            {
                                if (AGVS_Accept_TransferTask || !port_wait_in.Properties.CarrierWaitOutWhenAGVSRefuseMCSMission)
                                    port_wait_in.CstTransferAcceptInvoke();
                                else
                                    port_wait_in.CstTransferRejectInvoke();
                            }
                        }
                        else
                        {
                            Utility.SystemLogger.Warning($"Parse S2F49-{primaryMsgFromMcs.ToSml()} Fail");

                        }
                        //(bool confirm, ALARM_CODES alarmcode) handleResult = await TransferHandler(parameterGroups, _primaryMessageWrapper);
                    }

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
                    {
                        MCSUseLogger.MessageOut(replyMessage, _primaryMessageWrapper.Id);
                        Utility.SystemLogger.SecsTransferLog($"Message Reply to MCS Finish");
                    }
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

                    SecsMessage? AGVSReplyMessage = await AGVS.SendMsg(new SecsMessage(1, 3)
                    {
                        SecsItem = L(toAGVSItems)
                    }, msg_name: "CIM->AGVS");
                    bool IsAGVSReplySuccess = !AGVSReplyMessage.IsS9F7();
                    if (!IsAGVSReplySuccess)
                    {
                        AlarmManager.AddAlarm(ALARM_CODES.AGVS_NO_REPLY_FOR_S1F3, "MCSMSGHANDLER");
                    }
                    for (int i = 0; i < itemsToAGVS.Count; i++)
                    {
                        try
                        {
                            svid_data_store.Add((itemsToAGVS[i].FirstValue<ushort>(), IsAGVSReplySuccess ? AGVSReplyMessage.SecsItem.Items[i] : L()));
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
            List<clsConverterPort> ports = DevicesManager.GetAllPorts().FindAll(p => p.Properties.SecsReport);
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
            List<clsConverterPort> ports = DevicesManager.GetAllPorts().FindAll(p => p.Properties.SecsReport);
            ports = ports.OrderBy(p => p.Properties.PortID).ToList();
            Item CarrierInfo(clsConverterPort port)
            {
                return L(
                            A(port.PortExist ? port.CSTIDOnPort : ""),
                            A(port.Properties.PortID),
                            A(""),
                            A(port.Properties.CarrierInstallTime.ToString("yyyyMMddHHmmssff")),
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
            List<clsConverterPort> ports = DevicesManager.GetAllPorts().FindAll(port => port.Properties.SecsReport);
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
            List<clsConverterPort> ports = DevicesManager.GetAllPorts().FindAll(p => p.Properties.SecsReport); ;
            ports = ports.OrderBy(p => p.Properties.PortID).ToList();
            Item GetPortTypeInfo(clsConverterPort port)
            {
                return L(
                            A(port.Properties.PortID),
                            U2((ushort)(port.EPortType == PortUnitType.Input_Output ? port.MCSReservePortType : port.EPortType))
                        );
            }

            return ports.Select(port => GetPortTypeInfo(port)).ToArray();
        }

        private static void _AddAlarm(ALARM_CODES alarm_code)
        {
            AlarmManager.AddAlarm(alarm_code, "MCSMessage Transfer");
        }

        private static void _Log(string msg)
        {
            Utility.SystemLogger.Info(msg);
        }
    }
}
