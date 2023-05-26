using GPMCasstteConvertCIM.Forms;
using GPMCasstteConvertCIM.GPM_Modbus;
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

        public event EventHandler<Tuple<string, string>> OnMCSNoTransferNotify;

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

        private void Modbus_server_CoilsOnChanged(object? sender, ModbusProtocol e)
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

        public void SyncRegisterData()
        {
            Task.Run(async () =>
            {
                while (true)
                {

                    foreach (var item in EQModbusLinkBitAddress)
                    {
                        bool bolState = EQParent.EQPMemOptions.memoryTable.ReadOneBit(item.Address);
                        modbus_server.discreteInputs.localArray[item.Link_Modbus_Register_Number] = bolState;
                    }

                    foreach (var item in EQModbusLinkWordAddress)
                    {
                        int value = EQParent.EQPMemOptions.memoryTable.ReadBinary(item.Address);
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

        internal void NoTransferNotifyInovke(string carrier_id, string cstid)
        {
            OnMCSNoTransferNotify?.Invoke(this, new Tuple<string , string >(carrier_id, cstid));
        }
    }
}
