using Newtonsoft.Json;

namespace GPMCasstteConvertCIM.CasstteConverter
{
    public class Enums
    {
        public enum CONVERTER_TYPE
        {
            /// <summary>
            /// 表示單一轉換架
            /// </summary>
            IN_SYS = 1,
            /// <summary>
            /// 表示平對平組
            /// </summary>
            SYS_2_SYS = 2
        }

        public enum AUTO_MANUAL_MODE
        {
            AUTO = 1,
            MANUAL = 2,
            Unknown = 0
        }


        public enum AGVS_CONNECT_STATUS
        {
            DISCONNECT = 0,
            CONNECT = 1,
            Unknown = 999
        }

        public enum EQ_SCOPE
        {
            Unknown,
            AGVS, EQ, PORT1, PORT2
        }

        public enum PROPERTY
        {
            Unknown,
            EQP_RUN,
            EQP_IDLE,
            EQP_DOWN,
            L_REQ,
            U_REQ,
            EQ_READY,
            EQ_BUSY,
            Load_Request,
            Unload_Request,
            Port_Exist,
            Port_Status_Down,
            LD_UP_POS,
            LD_DOWN_POS,
            Door_Opened,
            TB_DOWN_POS,
            Carrier_WaitIn_System_Request,
            Carrier_WaitOut_System_Report,
            Carrier_Removed_Completed_Report,
            Carrier_Force_In_System_Request,
            AGV_Booking_Accept,
            AGV_Booking_Reject,
            AGV_CancelBooking_Accept,
            AGV_Booking_Status,
            Port_Mode_Change_Accept,
            Port_Mode_Changed_Refuse,
            Port_Mode_Changed_Report,
            Port_Disabled_Report,
            Port_Enabled_Report,

            Interface_Clock,
            EQP_ON_OFFLine_Mode_Status,
            Port_Type_Status,
            Port_Auto_Manual_Mode_Status,
            WIP_Information_BCR_1,
            WIP_Information_BCR_2,
            WIP_Information_BCR_3,
            WIP_Information_BCR_4,
            WIP_Information_BCR_5,
            WIP_Information_BCR_6,
            WIP_Information_BCR_7,
            WIP_Information_BCR_8,
            WIP_Information_BCR_9,
            WIP_Information_BCR_10,
            Warning_Report_Index,
            Warning_Code_1_16,
            Warning_Code_17_32,
            Warning_Code_33_48,
            Alarm_Report_Index,
            Alarm_Code_1_16,
            Alarm_Code_17_32,
            Alarm_Code_33_48,


            VALID,
            TR_REQ,
            BUSY,
            COMPT,
            AGV_READY,

            Port_Mode_Change_Request,
            Port_Mode_Changed_Report_Reply,
            Port_Disabled_Report_Reply,
            Port_Enbled_Report_Reply,

            Carrier_WaitIn_System_Reply,
            Carrier_WaitIn_System_Accept,
            Carrier_WaitIn_System_Refuse,
            Carrier_WaitOut_System_Reply,
            Carrier_Removed_Completed_Report_Reply,
            Carrier_Force_In_System_Reply,
            To_EQ_Up,
            To_EQ_Low,
            CMD_reserve_Up,
            CMD_reserve_Low,

        }

    }
}
