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

        public enum COMMACK : byte
        {
            Accepted = 0,
            Denied_Try_Again

        }
        public enum ONLACK : byte
        {
            Accepted = 0,
            Not_Allowed,
            Already_Online
        }

        public enum OFLACK : byte
        {
            Accepted = 0,
        }

        public enum ACKC6 : byte
        {
            Accpeted = 0,
            System_Error = 65
        }
        /// <summary>
        /// Host Command Parameter Acknowledge
        ///        Code, 1 byte
        ///0 = Acknowledge, Command has been performed
        ///1 = Command does not exist
        ///2 = Cannot perform now.
        ///3 = At least one parameter is invalid.
        ///4 = Acknowledge, command will be perform with completion signaled later by an event
        ///5 = Rejected, Already in desired condition
        ///6 = Not such object exists
        ///64 = CPNAME and CPVAL is insufficient
        ///65 = System Error
        /// </summary>
        public enum HCACK : byte
        {

        }
        public enum RCMD
        {
            CANCEL,
            ABORT,
            PAUSE,
            RESUME,
            SCAN,
            PRIORITYUPDATE,
            PORTTYPECHG,
            INSTALL,
            REMOVE,
            CDAPURGE,
            RESERVE,
            RESERVESTORAGE,
            CANCELRESERVESTORAGE,
            TRANSFER,
            NOTRANSFER
        }
        public enum CEID : ushort
        {
            OffLineModeChangeReport = 1,
            OnLineLocalModeChangeReport = 2,
            OnLineRemoteModeChangeReport = 3,
            AlarmClearedReport = 51,
            AlarmSetReport = 52,
            SCAutoCompletedReport = 53,
            SCAutoInitiatedReport = 54,
            SCPauseCompletedReport = 55,
            SCPausedReport = 56,
            SCPauseInitiatedReport = 57,
            TransferAbortCompletedReport = 101,
            TransferAbortFailedReport = 102,
            TransferAbortInitiatedReport = 103,
            TransferCancelCompletedReport = 104,
            TransferCancelFailedReport = 105,
            TransferCancelInitiatedReport = 106,
            TransferCompletedReport = 107,
            TransferInitiatedReport = 108,
            TransferPaused = 109,
            TransferResumed = 110,
            Transferring = 1111,

            CarrierInstallCompletedReport = 151,
            CarrierRemovedCompletedReport,
            CarrierRemovedCompletedReport_DELETEED,
            CarrierResumedReport,
            CarrierStoredReport,
            CarrierStoredAltReport,
            ShelfStatusChangeReport,
            CarrierWaitIn,
            CarrierWaitOut,
            CarrierTransfering,
            Crane_VehicleActive = 201,
            Crane_VehicleOutOfService = 205,
            Crane_VehicleInService,
            Crane_VehicleAcquireStarted = 210,
            Crane_VehicleAcquireCompleted,
            Crane_VehicleDepositStarted,
            Crane_VehicleDepositCompleted,
            Crane_VehicleAssigned = 220,
            Crane_VehicleUnassinged,
            VehicleDeparted,
            VehicleArrived,
            VehicleChargeStarted,
            VehicleChargeEnd = 231,
            VehicleCoordinateChanged = 241,
            CarrierIDReadReport = 251,
            ZoneCapacityChange = 252,

            EqLoadReqReport = 602,
            EqUnloadReqReport = 603,
            EqNoReqReport = 604,

            PortOutOfServiceReport = 701,
            PortInServiceReport = 702,
            PortTypeInputReport = 703,
            PortTypeOutputReport = 704,

            CDAPurgeStartReport = 800,
            CDAPurgeEndReport = 801,
            OperatorInitiatedAction = 810,


        }

        /// <summary>
        /// Port方向
        /// </summary>
        public enum PortUnitType
        {
            /// <summary>
            /// 進入系統
            /// </summary>
            Input = 0,
            /// <summary>
            /// 離開系統
            /// </summary>
            Output = 1,
            /// <summary>
            /// 離開系統
            /// </summary>
            Input_Output = 2,

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
                //TODO What is 'MDLN'?
                //TODO What is 'SOFTREV'?

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
        public struct EVENT_REPORT
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

            public static SecsMessage CarrierWaitInReportMessage(string carrier_ID, string carrier_Loc, string carrier_ZoneName)
            {
                Item[] VIDList = new Item[]
                {
                    A(carrier_ID),
                    A(carrier_Loc),
                    A(carrier_ZoneName)
                };

                return CreateEventMsg(1, (ushort)CEID.CarrierWaitIn, RPTID: 5, VIDList);
            }

            public static SecsMessage CarrierWaitOutReportMessage(string carrier_ID, string carrier_Loc, string carrier_ZoneName)
            {
                Item[] VIDList = new Item[]
                {
                    A(carrier_ID),
                    A(carrier_Loc),
                    A(carrier_ZoneName)
                };

                return CreateEventMsg(1, (ushort)CEID.CarrierWaitOut, RPTID: 5, VIDList);
            }





            public static SecsMessage CreateEventMsg(ushort DATAID, ushort CEID, ushort RPTID, Item[] VIDLIST)
            {

                SecsMessage msg = new(6, 11)
                {
                    SecsItem = L(
                                  U4(DATAID),//DATAID,
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


            public static SecsMessage EventReportAcknowledgeMessage(ACKC6 ack)
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
