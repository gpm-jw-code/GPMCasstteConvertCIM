using GPMCasstteConvertCIM.Alarm;
using GPMCasstteConvertCIM.GPM_SECS;
using GPMCasstteConvertCIM.Utilities;
using Secs4Net;
using Secs4Net.Sml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GPMCasstteConvertCIM.GPM_SECS.SECSMessageHelper;

namespace GPMCasstteConvertCIM.CasstteConverter
{
	public partial class clsConverterPort
	{
		public async Task<bool> SecsEventReport(CEID ceid)
		{
			SecsMessage msgSend = CreateMsgByCEID(ceid);

			if (ceid == CEID.CarrierWaitOut)
				await WaitTransferCompleted();


			try
			{
				SecsMessage msgReply = await MCS.SendMsg(msgSend);
				if (msgReply.IsS9F7())
				{
					AlarmManager.AddWarning(ALARM_CODES.Port_Event_Report_Timeout, Properties.PortID);
					return false;
				}
				else
				{
					if (ceid == CEID.CarrierWaitIn)
					{
						bool mcs_accpet = msgReply.SecsItem.FirstValue<byte>() == 0;
						return mcs_accpet && await WaitTransferTaskDownloaded();
					}
					return true;
				}
			}
			catch (Exception)
			{
				AlarmManager.AddWarning(ALARM_CODES.Port_Event_Report_Code_Error, Properties.PortID);
				return false;
			}

		}


		private SecsMessage CreateMsgByCEID(CEID ceid)
		{
			string carrier_id = Previous_WIPINFO_BCR_ID;
			string port_id = Properties.PortID;
			bool isAutoMode = EPortAutoStatus == Enums.AUTO_MANUAL_MODE.AUTO;
			switch (ceid)
			{
				case CEID.CarrierWaitIn:
					return EventsMsg.CarrierWaitIn(carrier_id, port_id);
				case CEID.CarrierWaitOut:
					return EventsMsg.CarrierWaitOut(carrier_id, port_id);
				case CEID.CarrierInstallCompletedReport:
					return EventsMsg.CarrierInstalled(carrier_id, port_id, isAutoMode);
				case CEID.PortOutOfServiceReport:
					return EventsMsg.PortService(port_id, false);
				case CEID.PortInServiceReport:
					return EventsMsg.PortService(port_id, true);
				case CEID.PortTypeInputReport:
					return EventsMsg.PortType(port_id, PortUnitType.Input);
				case CEID.PortTypeOutputReport:
					return EventsMsg.PortType(port_id, PortUnitType.Output);
				case CEID.CarrierRemovedCompletedReport:
					return EventsMsg.CarrierRemovedCompleted(carrier_id, port_id, isAutoMode);
				default:
					throw new NotImplementedException();
			}
		}

		/// <summary>
		/// 等待
		/// </summary>
		/// <returns></returns>
		private async Task WaitTransferCompleted(int timeout_sec = 5)
		{
			//確保Wait Out Event Report在 Transfer Completed 之後
			CancellationTokenSource cts = new CancellationTokenSource(TimeSpan.FromSeconds(timeout_sec));
			while (!Carrier_TransferCompletedFlag)
			{
				if (cts.IsCancellationRequested)
					break;
				await Task.Delay(1);
			}
			Carrier_TransferCompletedFlag = false;
		}


	}
}
