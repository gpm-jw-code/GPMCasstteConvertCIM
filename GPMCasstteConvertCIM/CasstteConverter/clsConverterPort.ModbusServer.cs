using GPMCasstteConvertCIM.Forms;
using GPMCasstteConvertCIM.GPM_Modbus;
using GPMCasstteConvertCIM.GPM_SECS;
using GPMCasstteConvertCIM.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GPMCasstteConvertCIM.CasstteConverter.Data.clsMemoryAddress;

namespace GPMCasstteConvertCIM.CasstteConverter
{
    public partial class clsConverterPort
    {
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
                return true;
            }
            catch (Exception ex)
            {
                error_msg = ex.Message;
                return false;
            }

        }
        public bool BuildModbusTCPServer(frmModbusTCPServer ui)
        {
            try
            {
                modbus_server = new ModbusTCPServer();
                modbus_server.CoilsOnChanged += Modbus_server_CoilsOnChanged;
                modbus_server.linkedCasstteConverter = EQParent;
                ui.ModbusTCPServer = modbus_server;
                modbus_server.Active(Properties.ModbusServer_IP, Properties.ModbusServer_PORT, ui);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private bool _AGV_VALID = false;
        private bool _AGV_READY = false;
        private bool _AGV_TR_REQ = false;
        private bool _AGV_BUSY = false;
        private bool _AGV_COMPT = false;
        private bool _To_EQ_Up = false;
        private bool _To_EQ_Low = false;
        private bool _CMD_Reserve_Up = false;
        private bool _CMD_Reserve_Low = false;

        public bool AGV_VALID
        {
            get => _AGV_VALID;
            set
            {
                if (_AGV_VALID != value)
                {
                    _AGV_VALID = value;
                    LogAGVHandshakeSignalChange("AGV_VALID", value);
                }
            }
        }

        public bool AGV_READY
        {
            get => _AGV_READY;
            set
            {
                if (_AGV_READY != value)
                {
                    _AGV_READY = value;
                    LogAGVHandshakeSignalChange("AGV_READY", value);
                }
            }
        }
        public bool AGV_TR_REQ
        {
            get => _AGV_TR_REQ;
            set
            {
                if (_AGV_TR_REQ != value)
                {
                    _AGV_TR_REQ = value;
                    LogAGVHandshakeSignalChange("AGV_TR_REQ", value);
                }
            }
        }
        public bool AGV_BUSY
        {
            get => _AGV_BUSY;
            set
            {
                if (_AGV_BUSY != value)
                {
                    _AGV_BUSY = value;
                    LogAGVHandshakeSignalChange("AGV_BUSY", value);
                }
            }
        }
        public bool AGV_COMPT
        {
            get => _AGV_COMPT;
            set
            {
                if (_AGV_COMPT != value)
                {
                    _AGV_COMPT = value;
                    LogAGVHandshakeSignalChange("AGV_COMPT", value);
                }
            }
        }

        public bool To_EQ_UP
        {
            get => _To_EQ_Up;
            set
            {
                if (_To_EQ_Up != value)
                {
                    _To_EQ_Up = value;
                    LogAGVHandshakeSignalChange("To_EQ_UP", value);
                }
            }
        }

        public bool To_EQ_Low
        {
            get => _To_EQ_Low;
            set
            {
                if (_To_EQ_Low != value)
                {
                    _To_EQ_Low = value;
                    LogAGVHandshakeSignalChange("To_EQ_Low", value);
                }
            }
        }

        public bool CMD_Reserve_Up
        {
            get => _CMD_Reserve_Up;
            set
            {
                if (_CMD_Reserve_Up != value)
                {
                    _CMD_Reserve_Up = value;
                    LogAGVHandshakeSignalChange("CMD_Reserve_Up", value);
                }
            }
        }

        public bool CMD_Reserve_Low
        {
            get => _CMD_Reserve_Low;
            set
            {
                if (_CMD_Reserve_Low != value)
                {
                    _CMD_Reserve_Low = value;
                    LogAGVHandshakeSignalChange("CMD_Reserve_Low", value);
                }
            }
        }

        private void LogAGVHandshakeSignalChange(string name, bool state)
        {
            Utility.SystemLogger.Info($"{PortName} --> AGV Handshake Signal-{name} Changed to {(state ? "1" : "0")}");
        }

        protected virtual void Modbus_server_CoilsOnChanged(object? sender, ModbusProtocol e)
        {
            ///要把Coil Data同步到PLC Memory 
            Task.Factory.StartNew(() =>
            {
                string portNoName = $"PORT{Properties.PortNo + 1}";
                List<CasstteConverter.Data.clsMemoryAddress> CIMLinkAddress = EQParent.LinkBitMap.FindAll(ad => ad.EOwner == OWNER.CIM && ad.EScope.ToString() == portNoName && ad.Link_Modbus_Register_Number != -1);
                foreach (var item in CIMLinkAddress)
                {
                    int register_num = item.Link_Modbus_Register_Number;
                    var localCoilsAry = modbus_server.coils.localArray;
                    bool state = localCoilsAry[register_num + 1];
                    CIMMemoryTable.WriteOneBit(item.Address, state);

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

                    EQParent.CIMMemOptions.memoryTable.WriteOneBit(item.Address, state);
                }

            });
        }

        public virtual void SyncRegisterData()
        {
            Task.Factory.StartNew(async () =>
            {
                while (true)
                {
                    await Task.Delay(10);
                    foreach (Data.clsMemoryAddress item in EQModbusLinkBitAddress)
                    {
                        bool bolState = EQParent.EQPMemOptions.memoryTable.ReadOneBit(item.Address);
                        if (item.EProperty == Enums.PROPERTY.Port_Status_Down)
                        {
                            if ((bool)item.Value == false && PortStatusDownForceOn)
                                bolState = true; //強制PortStatusDown ON
                        }
                        if (Utility.SysConfigs.EQLoadUnload_RequestSimulation)
                        {
                            if (item.EProperty == Enums.PROPERTY.Load_Request | item.EProperty == Enums.PROPERTY.Unload_Request)
                                bolState = true;
                        }
                        modbus_server.discreteInputs.localArray[item.Link_Modbus_Register_Number] = bolState;
                    }

                    foreach (Data.clsMemoryAddress item in EQModbusLinkWordAddress)
                    {

                        int value = EQParent.EQPMemOptions.memoryTable.ReadBinary(item.Address);
                        modbus_server.holdingRegisters.localArray[item.Link_Modbus_Register_Number] = (short)value;
                    }


                    foreach (var item in CIMModbusLinkWordAddress)
                    {
                        int value = EQParent.CIMMemOptions.memoryTable.ReadBinary(item.Address);
                        modbus_server.holdingRegisters.localArray[item.Link_Modbus_Register_Number] = (short)value;
                    }
                }

            });
        }


    }
}
