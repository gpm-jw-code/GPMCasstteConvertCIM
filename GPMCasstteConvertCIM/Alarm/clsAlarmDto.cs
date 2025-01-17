using GPMCasstteConvertCIM.CasstteConverter;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace GPMCasstteConvertCIM.Alarm
{
    public class clsAlarmDto
    {

        [Key]
        public DateTime Time { get; set; }
        public ALARM_LEVEL Level { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Classify { get; set; } = string.Empty;
        public string EQPName { get; set; } = string.Empty;
        public ALARM_CODES Code { get; set; }
        public int Code_int
        {
            get => (int)Code;
            set
            {
                Code = Enum.GetValues(typeof(ALARM_CODES)).Cast<ALARM_CODES>().FirstOrDefault(c => (int)c == value);
            }
        }
        public clsAlarmDto(ALARM_CODES code, string classify, string description)
        {
            Code = code;
            Classify = classify;
            Description = description;
        }
        public clsAlarmDto()
        {

        }
    }


    public enum ALARM_CODES
    {
        CONNECTION_ERROR_CONVERT = 4100,
        CONNECTION_ERROR_MCS,
        CONNECTION_ERROR_AGVS,
        HANDSHAKE_ERROR_CARRIER_WAIT_IN,
        HANDSHAKE_ERROR_CARRIER_WAIT_OUT,
        HANDSHAKE_ERROR_PORT_TYPE_CHANGE,
        ALIVE_CLOCK_EQP_DOWN,
        MCS_PORT_IN_SERVICE_REPORT_FAIL,
        MCS_PORT_OUT_SERVICE_REPORT_FAIL,
        MCS_CARRIER_WAITIN_REPORT_FAIL,
        MCS_CARRIER_WAITOUT_REPORT_FAIL,
        MCS_CARRIER_REMOVED_COMPLETED_REPORT_FAIL,
        CARRIER_WAIT_IN_BUT_MCS_DISCONNECT,
        CARRIER_WAIT_IN_BUT_MCS_REJECT,
        CarrierWaitIn_HS_EQ_Timeout,
        CarrierWaitOut_HS_EQ_Timeout,
        CarrierRemovedCompolete_HS_EQ_Timeout,
        TRANSFER_MCS_MSG_TO_AGVS_BUT_AGVS_NO_REPLY,
        AGVS_REPLY_MCS_MSG_BUT_ERROR_WHEN_REPLY_TO_MCS,
        CODE_EXCEPTION_WHEN_TRANSFER_MSG_TO_AGVS,
        EVENT_REPORT_COMPLETED_BUT_ACK_IS_SYSTEM_ERROR_65,
        MCS_PORT_TYPE_INPUT_REPORT_FAIL,
        MCS_PORT_TYPE_OUTPUT_REPORT_FAIL,
        CIM_HANDLE_S1F3_OCCUR_ERROR,
        ONLINE_MODE_MONITORING_ERROR,
        AGVS_NO_REPLY_FOR_S1F3,
        WAIT_Load_Unload_Request_Bit_ON_When_MCS_Transfering,
        None,
        WAIT_Load_Unload_Request_Bit_ON_When_Carrier_WaitIn_Reply,
        PortTypeChangeRequest_HS_EQ_Timeout,
        Try_CarrierInstalledReport_But_BCRID_Not_Exist,
        Try_CarrierRemovedCompletedReport_But_BCRID_Not_Exist,
        Port_Event_Report_Timeout,
        Port_Event_Report_Code_Error,
        CARRIER_WAIT_IN_BUT_BCR_ID_IS_EMPTY,
        CarrierInstallReportFail,
        CODE_ERROR,
        SYNCMEMDATA_FUNCTION_CODE_ERROR,
        MX_INTERFACE_OPEN_FAIL,
        CARRIER_WAIT_IN_BUT_NO_CARGO_IN_EQ,
        CARRIER_WAIT_OUT_BUT_NO_CARGO_IN_EQ,
        Cannot_InstallCompleteReport_When_CST_Not_Exist,
        PortTypeChangedReport_HS_EQ_Timeout,
        PLC_IF_READ_FAIL,
        PLC_IF_WRITE_FAIL,
        AGV_PING_FAIL,
        AGV_READY_EQ_BUSY_INTERLOCK_CIM_SOLUTION,
        AGV_EQ_Handshake_Fail_AFTER_EQ_BUSY_OFF,
        WebServer_Build_Fail,
        WebServer_Exception_Happend_When_Handling_Request,
        BCRID_SYNC_TO_AGVS_WORD_REGION_FAIL,
        AGVS_DDOS,
        Get_Host_Mode_From_AGVS_FAIL
    }
}
