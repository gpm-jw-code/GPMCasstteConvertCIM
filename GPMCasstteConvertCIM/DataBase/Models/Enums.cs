using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPMCasstteConvertCIM.Database
{
    public enum ONLINE_STATE
    {
        OFFLINE = 0,
        ONLINE,
    }
    public enum AUTO_STATE
    {
        AUTO,
        MANUAL
    }

    public enum RUN_STATE
    {
        IDLE = 1,
        RUN,
        DOWN,
        Charging

    }
    public enum ACTION_TYPE
    {
        MOVE = 0,
        LOAD = 1,
        UNLOAD = 2,
        TRANSFER = 3,
        CHARGE = 4,
        PARK = 5
    }
}
