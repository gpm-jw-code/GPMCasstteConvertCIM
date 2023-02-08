using GPMCasstteConvertCIM.CasstteConverter;
using GPMCasstteConvertCIM.Devices;
using GPMCasstteConvertCIM.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GPMCasstteConvertCIM.CasstteConverter.Data.clsMemoryAddress;

namespace GPMCasstteConvertCIM.GPM_Modbus
{
    public class ModbusTCPServer : ModbusServerBase
    {
        internal enum HOLDING_REGISTER_TYPE
        {
            R40001 = 40001,
            R400001 = 400001,
        }

        internal clsCasstteConverter linkedCasstteConverter { get; private set; }

        private frmModbusTCPServer UI;
        private LoggerBase logger;
        internal int ConnectedClientNum => tcpHandler == null ? 0 : tcpHandler.NumberOfConnectedClients;
        internal void Active(InitialOption modbusTcpServer_opt, clsCasstteConverter linkedCasstteConverter)
        {
            this.linkedCasstteConverter = linkedCasstteConverter;
            UI = (frmModbusTCPServer)modbusTcpServer_opt.mainUI;
            UI.ModbusTCPServer = this;
            logger = new LoggerBase(modbusTcpServer_opt.logRichTextBox, Path.Combine(Utility.SysConfigs.Log.SyslogFolder, "Modbus TCP Server"));
            NumberOfConnectedClientsChanged += ModbusTCPServer_NumberOfConnectedClientsChanged;
            Port = modbusTcpServer_opt.Port;
            Listen();
            UI.Port = Port;
            CoilsOnChanged += ModbusTCPServer_CoilsOnChanged;
            HoldingRegisterOnChanged += ModbusTCPServer_HoldingRegisterOnChanged;

            logger.Info($"Modbus TCP Server Listening...(tcp://0.0.0.0:{Port})");

            SyncPLCMemory();
        }


        private void SyncPLCMemory()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    Thread.Sleep(1);
                    List<CasstteConverter.Data.clsMemoryAddress> EQLinkBitAddress = linkedCasstteConverter.LinkBitMap.FindAll(ad => ad.EOwner == OWNER.EQP && ad.Link_Modbus_Register_Number != -1);
                    foreach (var item in EQLinkBitAddress)
                    {
                        bool bolState = linkedCasstteConverter.EQPMemOptions.memoryTable.ReadOneBit(item.Address);
                        discreteInputs.localArray[item.Link_Modbus_Register_Number] = bolState;
                    }

                    List<CasstteConverter.Data.clsMemoryAddress> EQLinkWordAddress = linkedCasstteConverter.LinkWordMap.FindAll(ad => ad.EOwner == OWNER.EQP && ad.Link_Modbus_Register_Number != -1);
                    foreach (var item in EQLinkWordAddress)
                    {
                        int value = linkedCasstteConverter.EQPMemOptions.memoryTable.ReadBinary(item.Address);
                        holdingRegisters.localArray[item.Link_Modbus_Register_Number] = (short)value;
                    }


                    List<CasstteConverter.Data.clsMemoryAddress> CIMLinkWordAddress = linkedCasstteConverter.LinkWordMap.FindAll(ad => ad.EOwner == OWNER.CIM && ad.Link_Modbus_Register_Number != -1);
                    foreach (var item in CIMLinkWordAddress)
                    {
                        int value = linkedCasstteConverter.CIMMemOptions.memoryTable.ReadBinary(item.Address);
                        holdingRegisters.localArray[item.Link_Modbus_Register_Number] = (short)value;
                    }

                }
            });
            //linkedCasstteConverter.memOptions.memoryTable.ReadOneBit(,);
        }

        public void WriteDI(int startAddress, bool[] states)
        {
            Array.Copy(states, 0, discreteInputs.localArray, startAddress, states.Length);
        }
        private void ModbusTCPServer_HoldingRegisterOnChanged(object? sender, int function_code)
        {
            var holdings = holdingRegisters.localArray;
            Task.Factory.StartNew(() =>
            {
                List<CasstteConverter.Data.clsMemoryAddress> CIMLinkAddress = linkedCasstteConverter.LinkWordMap.FindAll(ad => ad.EOwner == OWNER.CIM && ad.Link_Modbus_Register_Number != -1);
                foreach (var item in CIMLinkAddress)
                {
                    int register_num = item.Link_Modbus_Register_Number;
                    int _value = holdingRegisters.localArray[register_num];
                    linkedCasstteConverter.CIMMemOptions.memoryTable.WriteBinary(item.Address, _value);
                }

            });
        }


        private void ModbusTCPServer_CoilsOnChanged(object? sender, int function_code)
        {
            ///要把Coil Data同步到PLC Memory 
            Task.Factory.StartNew(() =>
            {
                List<CasstteConverter.Data.clsMemoryAddress> CIMLinkAddress = linkedCasstteConverter.LinkBitMap.FindAll(ad => ad.EOwner == OWNER.CIM && ad.Link_Modbus_Register_Number != -1);
                foreach (var item in CIMLinkAddress)
                {
                    int register_num = item.Link_Modbus_Register_Number;
                    bool state = coils.localArray[register_num];
                    linkedCasstteConverter.CIMMemOptions.memoryTable.WriteOneBit(item.Address, state);
                }

            });
        }

        private void ModbusTCPServer_NumberOfConnectedClientsChanged()
        {
            var tcph = tcpHandler;
            //logger.Warning("Client ");
        }

        internal void Close()
        {
            tcpHandler.Disconnect();
        }
    }
}
