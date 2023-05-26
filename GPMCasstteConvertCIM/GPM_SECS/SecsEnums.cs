using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPMCasstteConvertCIM.GPM_SECS
{
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
        Acknowledge = 0,
        Command_does_not_exist = 1,
        Cannot_Perform_Now = 2,
        At_least_one_parameter_is_invalid = 3,
        Acknowledge_Perform_Later = 4,
        Rejected_Already_in_desired_condition = 5,
        Not_such_object_exists = 6,
        CPNAME_and_CPVAL_is_insufficient = 64,
        System_Error = 65

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
        NOTRANSFERNOTIFY
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
    public enum PortUnitType : ushort
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


}
