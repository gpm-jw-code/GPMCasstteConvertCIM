using GPMCasstteConvertCIM.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPMCasstteConvertCIM.GPM_Modbus
{

    internal interface IModbusHSable
    {
        ModbusTCPServer modbus_server { get; set; }
        bool BuildModbusTCPServer(frmModbusTCPServer ui);
        void SyncRegisterData();
    }
}
