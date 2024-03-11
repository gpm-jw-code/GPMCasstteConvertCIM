using GPMCasstteConvertCIM.Utilities;
using Modbus.Data;
using Modbus.Device;
using Modbus.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace GPMCasstteConvertCIM.CasstteConverter
{
    public class clsStatusIOModbusGateway
    {
        private ModbusTcpSlave slave;
        public int Port { get; set; }

        public event EventHandler<bool[]> OnAGVOutputsChanged;

        public virtual bool StartGateway(int port, out string error_messge)
        {
            error_messge = string.Empty;
            try
            {

                Port = port;
                Utility.SystemLogger.Info($"[clsStatusIOModbusGateway] Try serve modbus salve, port = {Port}");
                slave = ModbusTcpSlave.CreateTcp(0, new TcpListener(Port));
                //slave.ModbusSlaveRequestReceived += Master_ModbusSlaveRequestReceived;
                slave.ModbusSlaveRequestReceived += Slave_ModbusSlaveRequestReceived;
                slave.DataStore = DataStoreFactory.CreateDefaultDataStore();
                slave.ListenAsync();
                return true;
            }
            catch (Exception ex)
            {
                error_messge = ex.Message;
                Utility.SystemLogger.Info($"[clsStatusIOModbusGateway] Try serve modbus salve, port = {Port},FAIL={error_messge}");
                return false;
            }
        }

        public void StoreEQOutpus(bool[] outputs)
        {
            if (slave == null)
                return;
            for (int i = 0; i < outputs.Length; i++)
            {
                slave.DataStore.InputDiscretes[i + 1] = outputs[i];
            }
        }
        private bool[] last_agv_write_coils = new bool[0];
        private void Slave_ModbusSlaveRequestReceived(object sender, ModbusSlaveRequestEventArgs e)
        {
            if (e.Message is WriteMultipleCoilsRequest request)
            {
                ushort startAddress = request.StartAddress;
                bool[] coils = request.Data.ToArray();
                ushort coilCount = (ushort)coils.Length;
                if (!coils.SequenceEqual(last_agv_write_coils))
                    OnAGVOutputsChanged?.Invoke(this, coils);
                last_agv_write_coils = coils;
                try
                {
                    for (int i = 0; i < coilCount; i++)
                    {
                        bool value = coils[i];
                        slave.DataStore.CoilDiscretes[startAddress + i] = value;
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }

        internal void Close()
        {
            try
            {
                slave.Transport.Dispose();
                slave.Dispose();
            }
            catch (Exception)
            {
            }
        }
    }
}
