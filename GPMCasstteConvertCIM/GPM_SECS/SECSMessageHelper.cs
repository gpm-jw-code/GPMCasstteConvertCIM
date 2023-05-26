using Secs4Net;
using static Secs4Net.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Security.Policy;
using System.Xml.Linq;
using Item = Secs4Net.Item;

namespace GPMCasstteConvertCIM.GPM_SECS
{
    public class SECSMessageHelper
    {
        private static uint _DataID_Cylic_Use = 1;
        public static uint DataID_Cylic_Use
        {
            get
            {
                _DataID_Cylic_Use += 1;
                if (_DataID_Cylic_Use >= uint.MaxValue)
                    _DataID_Cylic_Use = 1;
                return _DataID_Cylic_Use;
            }
        }

        public static void DefineReport(SecsMessage primaryMessage)
        {
            Item reportList = primaryMessage.SecsItem.Items[1];
            foreach (Item report in reportList.Items)
            {
                ushort RPTID = report.Items[0].FirstValue<ushort>();//RPTID

                foreach (Item item in report.Items[1].Items)
                {
                    ushort VID = item.FirstValue<ushort>();
                }

            }
        }

        public static void LinkEventReport(SecsMessage primaryMessage)
        {
            Item reportList = primaryMessage.SecsItem.Items[1];
            foreach (Item report in reportList.Items)
            {
                ushort CEID = report.Items[0].FirstValue<ushort>();//RPTID

                foreach (Item item in report.Items[1].Items)
                {
                    ushort RPTID = item.FirstValue<ushort>();
                }

            }
        }

        internal static SecsMessage S9F7_IllegalDataMsg()
        {
            return new SecsMessage(9, 7)
            {
                SecsItem = B(1)
            };
        }


        /// <summary>
        /// 連線/通訊相關
        /// </summary>
        public struct COMMUNICATION
        {

            /// <summary>
            /// S1, F13 Establish Communication Request S,H←→E, 需要 Reply.
            /// </summary>
            /// <returns></returns>
            public static SecsMessage EstablishCommunicationRequestMessage(string MDLN, string SOFTREV)
            {
                var msg = new SecsMessage(1, 13, replyExpected: true)
                {
                    SecsItem = L(
                                  A(MDLN),
                                  A(SOFTREV)
                               )
                };
                return msg;
            }
            /// <summary>
            /// S1, F14 Establish Communication Request Acknowledge S,H←→E
            /// </summary>
            /// <returns></returns>
            public static SecsMessage EstablishCommunicationRequestAcknowledgeMessage(COMMACK ack, string MDLN, string SOFTREV)
            {
                var msg = new SecsMessage(1, 14, replyExpected: false)
                {
                    SecsItem = L(
                                  B((byte)ack),
                                  L(
                                    A(MDLN),
                                    A(SOFTREV)
                                  )
                               )
                };
                return msg;
            }


        }

        /// <summary>
        /// 設備上線下線相關
        /// </summary>
        public struct ONOFFLINE
        {

            /// <summary>
            /// Description: The Host requests that the equipment transition to the OFF-Line state.
            /// Structure: Header only.
            /// </summary>
            /// <returns></returns>
            public static SecsMessage OffLineRequestMessage()
            {
                var msg = new SecsMessage(1, 15, replyExpected: true)
                {
                };
                return msg;
            }

            public static SecsMessage OffLineRequestAcknowledgeMessage(OFLACK ack = OFLACK.Accepted)
            {
                var msg = new SecsMessage(1, 16, replyExpected: false)
                {
                    SecsItem = B((byte)ack)
                };
                return msg;
            }

            /// <summary>
            /// Description: The Host requests that the equipment transition to the ON-Line state.
            /// Structure: Header only.
            /// </summary>
            /// <returns></returns>
            public static SecsMessage OnLineRequestMessage()
            {
                var msg = new SecsMessage(1, 17, replyExpected: true)
                {
                };
                return msg;
            }

            public static SecsMessage OnLineRequestAcknowledgeMessage(ONLACK ack)
            {
                var msg = new SecsMessage(1, 18, replyExpected: false)
                {
                    SecsItem = B((byte)ack)
                };
                return msg;
            }
        }


        /// <summary>
        /// RCMD 相關
        /// </summary>
        public struct RemoteCommand
        {
            public static SecsMessage PortTypeChange(string port_id, PortUnitType portUnitType)
            {
                SecsMessage msg = new SecsMessage(2, 41)
                {
                    SecsItem = L(
                                A(RCMD.PORTTYPECHG.ToString()),
                                L(
                                    L(
                                        A("PROTID"),
                                        A(port_id)
                                    ),
                                    L(
                                        A("PORTUNITTYPE"),
                                        A(((short)portUnitType).ToString())
                                    )
                                 )
                            )
                };
                return msg;
            }
        }

        /// <summary>
        /// 事件上報相關
        /// </summary>
        public struct EventsMsg
        {
            ////Structure:
            //L,3 
            //1.<DATAID> 
            //2.<CEID> 
            //3.L,a # “a” is always 1 for this system. 
            //  1. L,2 
            //      1.<RPTID> 
            //      2.L,b 
            //          1.<V1> #Variable data 1
            //          : 
            //          b.<Vb> #Variable data b
            //
            ///////////////////////////


            public static SecsMessage ChangeOfflineModeEventReportMessage(ushort DATAID, string EqpName)
            {

                var msg = new SecsMessage(6, 11)
                {
                    SecsItem = L(
                                U4(DATAID),//DATAID,
                                U2((ushort)CEID.OffLineModeChangeReport), //CEID
                                L(
                                    L(
                                     U2(2),//RPTID,
                                     L(
                                         A(EqpName)
                                       )
                                     )
                                  )
                               )
                };
                return msg;
            }

            public static SecsMessage ChangeOnLineLocalModeEventReportMessage(ushort DATAID, string EqpName)
            {
                var msg = new SecsMessage(6, 11)
                {
                    SecsItem = L(
                                U4(DATAID),//DATAID,
                                U2((ushort)CEID.OnLineLocalModeChangeReport), //CEID
                                L(
                                    L(
                                     U2(2),//RPTID,
                                     L(
                                         A(EqpName)
                                       )
                                     )
                                  )
                               )
                };
                return msg;
            }

            public static SecsMessage ChangeOnLineRemoteModeEventReportMessage(ushort DATAID, string EqpName)
            {

                var msg = new SecsMessage(6, 11)
                {

                    SecsItem = L(
                                  U4(DATAID),//DATAID,
                                  U2((ushort)CEID.OnLineRemoteModeChangeReport), //CEID
                                  L(
                                      L(
                                          U2(2),//RPTID,//這裡是內容
                                          L(            //這裡是內容
                                              A(EqpName)//這裡是內容
                                            )           //這裡是內容
                                       )
                                   )
                               )
                };
                return msg;
            }

            public static SecsMessage CarrierWaitIn(string carrier_ID, string carrier_Loc, string carrier_ZoneName)
            {

                Item[] VIDList = new Item[]
                {
                    A(carrier_ID),
                    A(carrier_Loc),
                    A(carrier_ZoneName)
                };

                return CreateEventMsg((ushort)CEID.CarrierWaitIn, RPTID: 5, VIDList, "Carrier_Wait_In");
            }

            public static SecsMessage CarrierWaitOut(string carrier_ID, string carrier_Loc, string carrier_ZoneName)
            {
                Item[] VIDList = new Item[]
                {
                    A(carrier_ID),
                    A(carrier_Loc),
                    A(carrier_ZoneName)
                };

                return CreateEventMsg((ushort)CEID.CarrierWaitOut, RPTID: 5, VIDList, "Carrier_Wait_Out");
            }

            public static SecsMessage CarrierInstalled(string carrier_ID, string carrier_Loc, bool IsAutoMode, string carrier_ZoneName = "")
            {
                Item[] VIDList = new Item[]
                {
                    A(carrier_ID),
                    A(carrier_Loc),
                    A(carrier_ZoneName),
                    U2((ushort)(IsAutoMode? 1:0))
                };

                return CreateEventMsg((ushort)CEID.CarrierInstallCompletedReport, RPTID: 4, VIDList, "CarrierInstalled");
            }
            public static SecsMessage CarrierRemovedCompleted(string carrier_ID, string carrier_Loc, string carrier_ZoneName, bool IsAutoMode)
            {
                Item[] VIDList = new Item[]
               {
                    A(carrier_ID),
                    A(carrier_Loc),
                    A(carrier_ZoneName),
                    U2((ushort)(IsAutoMode? 1:0))
               };

                return CreateEventMsg((ushort)CEID.CarrierRemovedCompletedReport, RPTID: 4, VIDList, "Carrier_Removed_Completed");
            }



            public static SecsMessage CreateEventMsg(ushort CEID, ushort RPTID, Item[] VIDLIST, string name = "")
            {

                SecsMessage msg = new(6, 11)
                {
                    Name = name,
                    SecsItem = L(
                                  U4(DataID_Cylic_Use),//DATAID,
                                  U2(CEID), //CEID
                                  L(
                                      L(
                                        U2(RPTID),
                                        L(VIDLIST)
                                        )
                                   )
                               )
                };
                return msg;

            }


            public static SecsMessage ACK6(ACKC6 ack)
            {
                var msg = new SecsMessage(6, 12, false)
                {
                    SecsItem = B((byte)ack)
                };
                return msg;
            }


        }
    }
}
