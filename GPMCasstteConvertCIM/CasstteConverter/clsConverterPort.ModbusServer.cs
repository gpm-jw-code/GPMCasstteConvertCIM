using GPMCasstteConvertCIM.Alarm;
using GPMCasstteConvertCIM.CasstteConverter.Data;
using GPMCasstteConvertCIM.Devices;
using GPMCasstteConvertCIM.Forms;
using GPMCasstteConvertCIM.GPM_Modbus;
using GPMCasstteConvertCIM.GPM_SECS;
using GPMCasstteConvertCIM.Utilities;
using Modbus.Device;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GPMCasstteConvertCIM.CasstteConverter.Data.clsMemoryAddress;
using static GPMCasstteConvertCIM.CasstteConverter.Enums;

namespace GPMCasstteConvertCIM.CasstteConverter
{
    public partial class clsConverterPort
    {
        public clsStatusIOModbusGateway agv_handshake_modbus_master = new clsStatusIOModbusGateway();
        public ModbusTCPServer modbus_server { get; set; }

        /// <summary>
        /// MCS要求切換的Port Type
        /// </summary>
        public PortUnitType MCSReservePortType { get; internal set; }
        public bool PortStatusDownForceOn { get; set; } = false;
        private bool _IsCarrierInstallReported = false;
        public bool IsCarrierInstallReported
        {
            get
            {
                Utility.SystemLogger.Info($"Get IsCarrierInstallReported ? => {_IsCarrierInstallReported}");
                return _IsCarrierInstallReported;
            }
            set
            {
                _CarrierRemovedReportedFlag = !value;
                _IsCarrierInstallReported = value;
                Utility.SystemLogger.Info($"_IsCarrierInstallReported  => {_IsCarrierInstallReported}");
            }
        }

        public event EventHandler<Tuple<string, string, string>> OnMCSNoTransferNotify;


        public bool BuildModbusTCPServer(string ip, int port, out string error_msg)
        {
            error_msg = string.Empty;
            if ($"{ip}:{port}" == ModbusHost)
                return true;

            try
            {

                modbus_server.Close();
                modbus_server.Active(ip, port, modbus_server.UI);
                Properties.ModbusServer_IP = ip;
                Properties.ModbusServer_PORT = port;
                modbus_server.tcpHandler.OnTcpIPClientConnected += HandleTcpIPClientConnected;

                return true;
            }
            catch (Exception ex)
            {
                error_msg = ex.Message;
                return false;
            }

        }

        private void HandleTcpIPClientConnected(object? sender, System.Net.Sockets.TcpClient client)
        {
            Utility.SystemLogger.Info($"ModbusTCP Server-(Port:{modbus_server.Port}):: CLIENT= {client.Client.RemoteEndPoint.ToString()} Connected");
        }

        public bool BuildModbusTCPServer(frmModbusTCPServer ui)
        {
            try
            {
                modbus_server = new ModbusTCPServer();
                modbus_server.linkedCasstteConverter = EQParent;
                ui.ModbusTCPServer = modbus_server;
                modbus_server.Active(Properties.ModbusServer_IP, Properties.ModbusServer_PORT, ui);
                modbus_server.OnServerListenStarted += (s, e) => modbus_server.tcpHandler.OnTcpIPClientConnected += HandleTcpIPClientConnected;
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        internal bool ActiveAGVHSModbusGateway(out string error_msg)
        {
            error_msg = string.Empty;
            Properties.AGVHandshakeModbusGatewayActive = true;
            DevicesManager.SaveDeviceConnectionOpts();

            agv_handshake_modbus_master.OnAGVOutputsChanged += Agv_handshake_modbus_master_OnAGVOutputsChanged;
            return agv_handshake_modbus_master.StartGateway(Properties.AGVHandshakeModbus_PORT, out error_msg);

        }


        internal void DisableAGVHSModbusGateway()
        {
            Properties.AGVHandshakeModbusGatewayActive = false;
            DevicesManager.SaveDeviceConnectionOpts();
            agv_handshake_modbus_master.OnAGVOutputsChanged -= Agv_handshake_modbus_master_OnAGVOutputsChanged;
            agv_handshake_modbus_master.Close();
        }

        private void LogAGVHandshakeSignalChange(string name, bool state)
        {
            //Utility.SystemLogger.Info($"|{PortName}| --> AGV Handshake Signal-|{name}| Changed to {(state ? "1" : "0")}");
        }

        protected void AGVHandshakeIO(clsMemoryAddress item, bool state)
        {
            if (item.EProperty == Enums.PROPERTY.VALID)
                AGV_VALID = state;
            if (item.EProperty == Enums.PROPERTY.TR_REQ)
                AGV_TR_REQ = state;
            if (item.EProperty == Enums.PROPERTY.BUSY)
                AGV_BUSY = state;
            if (item.EProperty == Enums.PROPERTY.COMPT)
                AGV_COMPT = state;
            if (item.EProperty == Enums.PROPERTY.AGV_READY)
                AGV_READY = state;


            if (item.EProperty == Enums.PROPERTY.To_EQ_Up)
                To_EQ_UP = state;
            if (item.EProperty == Enums.PROPERTY.To_EQ_Low)
                To_EQ_Low = state;
            if (item.EProperty == Enums.PROPERTY.CMD_reserve_Up)
                CMD_Reserve_Up = state;
            if (item.EProperty == Enums.PROPERTY.CMD_reserve_Low)
                CMD_Reserve_Low = state;
        }

        public virtual void SyncModbusDataWorker()
        {
            Task.Factory.StartNew(async () =>
            {
                while (true)
                {
                    await Task.Delay(50);
                    SyncEQHoldingRegistersWorker();
                    await Task.Delay(50);
                    SyncAGVSHoldingRegistersWorker();
                    await Task.Delay(50);
                    SyncAGVSCoilsDataWorker();
                    await Task.Delay(100);
                    SyncAGVSInputsWorker();

                }
            });

            Task.Factory.StartNew(() =>
            {
                CheckDiscardInputWriteResultBackgroundWorker();
            });
        }


        private bool[] last_cim_write_outputs = new bool[32];
        private bool[] last_agvs_write_inputs = new bool[32];

        protected async void CheckDiscardInputWriteResultBackgroundWorker()
        {
            bool connected = modbus_server.modbus_client_checker.Connected;
            var logger = EQParent._IOLogger;
            while (true)
            {
                await Task.Delay(50);

                if (!connected)
                {
                    connected = modbus_server.modbus_client_checker.Connect();
                    continue;
                }

                bool[] cim_write_outputs = new bool[32];
                try
                {
                    cim_write_outputs = modbus_server.modbus_client_checker.ReadDiscreteInputs(0, 32);
                }
                catch (Exception ex)
                {
                    modbus_server.modbus_client_checker.Disconnect();
                    connected = false;
                    logger?.Trace($"[{PortName}_Modbus Inputs Check:Port={modbus_server.Port}] Server Read Fail...Close Connection:{ex.Message}", PortName);
                    continue;
                }

                if (last_cim_write_outputs != null && !cim_write_outputs.SequenceEqual(last_cim_write_outputs))
                {

                    for (int i = 0; i < cim_write_outputs.Length; i++)
                    {
                        var plc_address = EQModbusLinkBitAddress.FirstOrDefault(add => add.Link_Modbus_Register_Number == i + 1);
                        if (last_cim_write_outputs[i] != cim_write_outputs[i])
                        {
                            int state = cim_write_outputs[i] ? 1 : 0;
                            logger?.Trace($"[{PortName}_Modbus Inputs Check:Port={modbus_server.Port}]-Input[{i}]_EQ/CIM Bit Trigger-{plc_address?.Address}-({plc_address?.EProperty}) change to [{state}]", PortName);
                        }
                    }
                }
                last_cim_write_outputs = cim_write_outputs;

                //AGVS Write input
                bool[] agvs_write_inputs = new bool[32];
                try
                {
                    agvs_write_inputs = modbus_server.modbus_client_checker.ReadCoils(0, 32);
                }
                catch (Exception ex)
                {
                    modbus_server.modbus_client_checker.Disconnect();
                    connected = false;
                    logger?.Trace($"[{PortName}_Modbus Inputs Check:Port={modbus_server.Port}] Server Read Fail...Close Connection:{ex.Message}", PortName);
                    continue;
                }

                if (last_agvs_write_inputs != null && !agvs_write_inputs.SequenceEqual(last_agvs_write_inputs))
                {

                    for (int i = 0; i < agvs_write_inputs.Length; i++)
                    {
                        var plc_address = CIMModbusLinkBitAddress.FirstOrDefault(add => add.Link_Modbus_Register_Number == i);
                        if (last_agvs_write_inputs[i] != agvs_write_inputs[i])
                        {
                            int state = agvs_write_inputs[i] ? 1 : 0;
                            logger?.Trace($"[{PortName}_Modbus Inputs Check:Port={modbus_server.Port}]-Input[{i}]_AGVS Bit Trigger-{plc_address?.Address}-({plc_address?.EProperty}) change to [{state}]", PortName);
                        }
                    }
                }
                last_agvs_write_inputs = agvs_write_inputs;
            }
        }

        protected virtual void SyncAGVSHoldingRegistersWorker()
        {
            foreach (var item in CIMModbusLinkWordAddress)
            {
                try
                {
                    int value = EQParent.CIMMemOptions.memoryTable.ReadBinary(item.Address);
                    modbus_server.holdingRegisters.localArray[item.Link_Modbus_Register_Number] = (short)value;
                }
                catch (Exception ex)
                {
                    Utility.SystemLogger.Error($"[{PortName}] SyncAGVSHoldingRegistersWorker Error Occur {item.Address}_Holding Regist[{item.Link_Modbus_Register_Number}]", ex);
                }
            }
        }

        protected virtual void SyncEQHoldingRegistersWorker()
        {
            foreach (Data.clsMemoryAddress item in EQModbusLinkWordAddress)
            {
                try
                {
                    int value = EQParent.EQPMemOptions.memoryTable.ReadBinary(item.Address);
                    modbus_server.holdingRegisters.localArray[item.Link_Modbus_Register_Number] = (short)value;
                }
                catch (Exception ex)
                {
                    Utility.SystemLogger.Error($"[{PortName}] SyncEQHoldingRegistersWorker Error Occur {item.Address}_Holding Regist[{item.Link_Modbus_Register_Number}]", ex);
                }
            }
        }

        protected virtual void SyncAGVSInputsWorker()
        {
            foreach (Data.clsMemoryAddress item in EQModbusLinkBitAddress)
            {
                try
                {
                    var mRindex = item.Link_Modbus_Register_Number;
                    bool bolState = IsIOSimulating ? (bool)item.ControlValue : EQParent.EQPMemOptions.memoryTable.ReadOneBit(item.Address);

                    if (item.EProperty == Enums.PROPERTY.EQ_BUSY && AGV_READY_WAITING_EQ_BUSYON_INTER_LOCKING)
                    {
                        bolState = EQ_BUSY_CIM_CONTROL;
                        if (!EQ_BUSY_CIM_CONTROL && !AGV_READY)
                        {
                            AGV_READY_WAITING_EQ_BUSYON_INTER_LOCKING = false;
                        }
                    }

                    modbus_server.discreteInputs.localArray[mRindex] = bolState;
                    if (modbus_server.discreteInputs.localArray[mRindex] != bolState)
                    {
                        Utility.SystemLogger.Warning($"[{PortName}] SyncAGVSInputsWorker- {item.Address} sync to Inputs[{mRindex}] fail.");
                    }
                }
                catch (Exception ex)
                {
                    Utility.SystemLogger.Error($"[{PortName}] SyncAGVSInputsWorker Error Occur {item.Address}", ex);
                }
            }
        }

        protected virtual void SyncAGVSCoilsDataWorker()
        {
            string portNoName = $"PORT{Properties.PortNo + 1}";
            List<clsMemoryAddress> CIMLinkAddress = EQParent.LinkBitMap.FindAll(ad => ad.EOwner == OWNER.CIM && ad.EScope.ToString() == portNoName && ad.Link_Modbus_Register_Number != -1);
            foreach (var item in CIMLinkAddress)
            {
                int register_num = item.Link_Modbus_Register_Number + 1;
                try
                {
                    var localCoilsAry = modbus_server.coils.localArray;
                    bool state = localCoilsAry[register_num];
                    AGVHandshakeIO(item, state);
                    CIMMemoryTable.WriteOneBit(item.Address, state);
                }
                catch (Exception ex)
                {
                    Utility.SystemLogger.Error($"[{PortName}] SyncAGVSCoilsDataWorker Error Occur {item.Address}_localCoilsAry[{register_num}]", ex);
                }
            }
        }
        private void Agv_handshake_modbus_master_OnAGVOutputsChanged(object? sender, bool[] agv_inputs)
        {
            //要寫到PLC 
            agv_hs_status.AGV_VALID = agv_inputs[0];
            agv_hs_status.AGV_TR_REQ = agv_inputs[1];
            agv_hs_status.AGV_BUSY = agv_inputs[2];
            agv_hs_status.AGV_READY = agv_inputs[3];
            agv_hs_status.AGV_COMPT = agv_inputs[4];

            Utility.SystemLogger.Warning($"[{PortName}] AGV Handshake Signal Changed-{agv_hs_status.ToJson()}.");

            WriteAGVHandshakeStatusToPLC(agv_hs_status);
        }

        protected virtual void WriteAGVHandshakeStatusToPLC(clsAGVHandshakeState agv_hs_status)
        {

            CIMMemoryTable.WriteOneBit(PortCIMBitAddress[PROPERTY.VALID], agv_hs_status.AGV_VALID);
            CIMMemoryTable.WriteOneBit(PortCIMBitAddress[PROPERTY.TR_REQ], agv_hs_status.AGV_TR_REQ);
            CIMMemoryTable.WriteOneBit(PortCIMBitAddress[PROPERTY.BUSY], agv_hs_status.AGV_BUSY);
            CIMMemoryTable.WriteOneBit(PortCIMBitAddress[PROPERTY.AGV_READY], agv_hs_status.AGV_READY);
            CIMMemoryTable.WriteOneBit(PortCIMBitAddress[PROPERTY.COMPT], agv_hs_status.AGV_COMPT);


        }

    }
}
