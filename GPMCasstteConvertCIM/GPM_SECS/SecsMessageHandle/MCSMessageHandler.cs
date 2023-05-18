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

namespace GPMCasstteConvertCIM.GPM_SECS.SecsMessageHandle
{
    internal class MCSMessageHandler
    {

        internal static void PrimaryMessageOnReceivedAsync(object? sender, PrimaryMessageWrapper _primaryMessageWrapper)
        {
            var secs_client = sender as SECSBase;
            using SecsMessage _primaryMessage = _primaryMessageWrapper.PrimaryMessage;

            bool reply = false;


            if (_primaryMessage.S == 2 && _primaryMessage.F == 33) // Define Report
            {
                DefineReport(_primaryMessage);
            }
            if (_primaryMessage.S == 2 && _primaryMessage.F == 35) // Link Event Report
            {
                LinkEventReport(_primaryMessage);
            }
            if (_primaryMessage.S == 2 && _primaryMessage.F == 41)
            {
                _primaryMessage.TryGetRCMDAction_S2F41(out RCMD cmd, out Item parameterGroups);
                if (cmd == RCMD.PORTTYPECHG)
                {
                    PortTypeChangeHandler(parameterGroups, _primaryMessageWrapper);
                    return;
                }
            }

            TransmitMsgToAGVS(_primaryMessageWrapper);

        }

        private async static void PortTypeChangeHandler(Item parameterGroups, PrimaryMessageWrapper _primaryMessageWrapper)
        {
            //L(
            //  L(
            //     A('PORTID')
            //     A('port ID')
            //   )

            //  L(
            //     A('PORTUNITTYPE')
            //     U2(0) //0:input,1:output
            //   )
            //)

            string port_id = parameterGroups.Items[0].Items[1].GetString();
            ushort port_type = parameterGroups.Items[1].Items[1].FirstValue<ushort>();
            clsConverterPort port = DevicesManager.GetPortByPortID(port_id);
            bool accept = await port.HandshakeHelper.Mode_Change_RequestAsync(port_type == 0 ? PortUnitType.Input : PortUnitType.Output);

            //TODO SEND REPLY TO MCS(PORTTYPECHANGE ack)
            _primaryMessageWrapper.TryReplyAsync(new SecsMessage(2, 42, false)
            {
            });
        }

        private static async void TransmitMsgToAGVS(PrimaryMessageWrapper _primaryMessageWrapper)
        {
            try
            {
                var primaryMsgFromMcs = _primaryMessageWrapper.PrimaryMessage;
                Utility.SystemLogger.Info($"[MCS SECS Message > AGVS] From MCS : {primaryMsgFromMcs.ToSml()}");

                SecsMessage replyMessage;

                if (primaryMsgFromMcs.S == 1 && primaryMsgFromMcs.F == 3)
                {
                    replyMessage = await S1F3RequestHandle(primaryMsgFromMcs);
                }
                else
                {
                    replyMessage = await DevicesManager.secs_client_for_agvs.SendAsync(primaryMsgFromMcs);

                }
                if (replyMessage == null)
                {
                    _AddAlarm(ALARM_CODES.TRANSFER_MCS_MSG_TO_AGVS_BUT_AGVS_NO_REPLY);
                }
                else
                {
                    await Task.Delay(100);
                    Utility.SystemLogger.Info($"[MCS SECS Message > AGVS] AGVS Reply : {replyMessage.ToSml()}");
                    //回傳給MCS
                    bool reply_to_mcs_succss = await _primaryMessageWrapper.TryReplyAsync(replyMessage);
                    if (reply_to_mcs_succss)
                        Utility.SystemLogger.Info($"[MCS SECS Message > AGVS] Message Transfer Finish");
                    else
                        _AddAlarm(ALARM_CODES.AGVS_REPLY_MCS_MSG_BUT_ERROR_WHEN_REPLY_TO_MCS);
                }

            }
            catch (Exception ex)
            {
                
                _AddAlarm(ALARM_CODES.CODE_EXCEPTION_WHEN_TRANSFER_MSG_TO_AGVS);
            }

        }

        /// <summary>
        /// 處理S1F3 , SVID 2005/2009 是CIM要處理但AGVS不處理
        /// </summary>
        /// <param name="primaryMsgFromMcs"></param>
        /// <returns></returns>
        public static async Task<SecsMessage> S1F3RequestHandle(SecsMessage primaryMsgFromMcs)
        {
            try
            {
                List<Item> svid_items = primaryMsgFromMcs.SecsItem.Items.ToList();
                Dictionary<ushort, Item> svid_data_store = new Dictionary<ushort, Item>();

                List<Item> itemsToCIM = svid_items.FindAll(item => item.FirstValue<ushort>() is 2005 or 2009);
                if (itemsToCIM.Count > 0)
                {
                    foreach (var item in itemsToCIM)
                    {
                        var sid = item.FirstValue<ushort>();
                        if (sid is 2005)
                        {
                            Item[] portStates = CreatePortInfosItem();
                            svid_data_store.Add(2005, L(portStates));
                        }
                        else if (sid is 2009)
                        {
                            Item[] portStates = CreatePortTypesItem();
                            svid_data_store.Add(2009, L(portStates));
                        }
                    }
                }

                List<Item> itemsToAGVS = svid_items.FindAll(item => item.FirstValue<ushort>() is not 2005 and not 2009);
                if (itemsToAGVS.Count != 0)
                {
                    List<Item> toAGVSItems = new List<Item>();
                    foreach (var item in itemsToAGVS)
                        toAGVSItems.Add(U2(item.FirstValue<ushort>()));

                    var AGVSReplyMessage = await DevicesManager.secs_client_for_agvs.SendAsync(new SecsMessage(1, 3)
                    {
                        SecsItem = L(toAGVSItems)
                    });

                    for (int i = 0; i < itemsToAGVS.Count; i++)
                        svid_data_store.Add(itemsToAGVS[i].FirstValue<ushort>(), AGVSReplyMessage.SecsItem.Items[i]);

                }
                //Combined
                List<Item> datas = new List<Item>();
                foreach (Item? item in svid_items)
                {
                    ushort svid = item.FirstValue<ushort>();
                    bool exist = svid_data_store.TryGetValue(svid, out Item data);
                    if (exist)
                        datas.Add(data);
                }

                var replyMessage = new SecsMessage(1, 4, false)
                {
                    SecsItem = L(datas)
                };
                return replyMessage;
            }
            catch (Exception ex)
            {
                return new SecsMessage(1, 4, false) { };
            }

        }


        /// <summary>
        /// 收集轉換架Ports的資訊然後加到回傳MESSAGE裡面
        /// </summary>
        /// <param name="primaryMsgFromMcs"></param>
        /// <param name="secondaryMsgFromAGVS"></param>
        private static void AppendPortDataToS1F4MessageItems(SecsMessage primaryMsgFromMcs, ref SecsMessage secondaryMsgFromAGVS)
        {
            var SVIDItemList = primaryMsgFromMcs.SecsItem.Items.ToList();
            //找到2009是第幾個
            Item? CurrentPortStatesItems = SVIDItemList.FirstOrDefault(item => item.FirstValue<ushort>() == 2005);
            Item? PortTypesItems = SVIDItemList.FirstOrDefault(item => item.FirstValue<ushort>() == 2009);

            //SVID:2005
            if (CurrentPortStatesItems != null)
            {
                int CurrentPortStatesItemsIndex = SVIDItemList.FindIndex(item => item == CurrentPortStatesItems);
                //
                Item[] portStates = CreatePortInfosItem();
                Item[] oriPortStatesItems = secondaryMsgFromAGVS.SecsItem[CurrentPortStatesItemsIndex].Items;
                List<Item> newPortStateItems = new List<Item>();
                newPortStateItems.AddRange(oriPortStatesItems);

                foreach (var item in portStates)
                    newPortStateItems.Add(item);

                //secondaryMsgFromAGVS.SecsItem[CurrentPortStatesItemsIndex] = L(newPortStateItems);
                secondaryMsgFromAGVS.SecsItem.Items.Append(L(newPortStateItems));
            }

            //SVID:2009
            if (PortTypesItems != null)
            {
                int PortTypesIndex = SVIDItemList.FindIndex(item => item == PortTypesItems);
                Item[] portTypes = CreatePortTypesItem();

                Item[] oriPortTypesItems = secondaryMsgFromAGVS.SecsItem[PortTypesIndex].Items;
                List<Item> newPortTypesItems = new List<Item>();
                newPortTypesItems.AddRange(oriPortTypesItems);

                foreach (var item in portTypes)
                    newPortTypesItems.Add(item);

                //secondaryMsgFromAGVS.SecsItem[PortTypesIndex] = L(newPortTypesItems);
                secondaryMsgFromAGVS.SecsItem.Items.Append(L(newPortTypesItems));

            }
        }

        private static Item[] CreatePortTypesItem()
        {
            //< L[2]
            //  A <PortID>
            //  U2<PortTransferState> 0=out of service; 1= in service
            List<clsConverterPort> ports = DevicesManager.GetAllPorts();

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
