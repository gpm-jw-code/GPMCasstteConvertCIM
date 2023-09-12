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
        private bool _IsCarrierInstallReported;
        public bool IsCarrierInstallReported
        {
            get
            {
                Utility.SystemLogger.Info($"Get IsCarrierInstallReported ? => {_IsCarrierInstallReported}");
                return _IsCarrierInstallReported;
            }
            set
            {
                _IsCarrierInstallReported = value;
                Utility.SystemLogger.Info($"_IsCarrierInstallReported  => {_IsCarrierInstallReported}");
            }
        }

        public event EventHandler<Tuple<string, string>> OnMCSNoTransferNotify;

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
                    EQParent.CIMMemOptions.memoryTable.WriteOneBit(item.Address, state);
                }

            });
        }

        public virtual void SyncRegisterData()
        {
            Task.Run(async () =>
            {
                while (true)
                {

                    foreach (Data.clsMemoryAddress item in EQModbusLinkBitAddress)
                    {
                        bool bolState = EQParent.EQPMemOptions.memoryTable.ReadOneBit(item.Address);
                        if (item.EProperty == Enums.PROPERTY.Port_Status_Down)
                        {
                            if ((bool)item.Value == false && PortStatusDownForceOn)
                                bolState = true; //強制PortStatusDown ON
                        }
                        modbus_server.discreteInputs.localArray[item.Link_Modbus_Register_Number] = bolState;
                    }

                    foreach (Data.clsMemoryAddress item in EQModbusLinkWordAddress)
                    {
                        int value = 0;
                        if (Utility.SysConfigs.EQLoadUnload_RequestSimulation)
                        {
                            if (item.EProperty == Enums.PROPERTY.Load_Request | item.EProperty == Enums.PROPERTY.Unload_Request)
                                value = 1;
                        }
                        else
                            value = EQParent.EQPMemOptions.memoryTable.ReadBinary(item.Address);
                        modbus_server.holdingRegisters.localArray[item.Link_Modbus_Register_Number] = (short)value;
                    }


                    foreach (var item in CIMModbusLinkWordAddress)
                    {
                        int value = EQParent.CIMMemOptions.memoryTable.ReadBinary(item.Address);
                        modbus_server.holdingRegisters.localArray[item.Link_Modbus_Register_Number] = (short)value;
                    }

                    await Task.Delay(10);
                }

            });
        }


    }
}
