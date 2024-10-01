using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPMCasstteConvertCIM.CasstteConverter.Data
{
    public static class Extensions
    {
        /// <summary>
        /// 是否為AGV交握訊號
        /// </summary>
        /// <param name="pROPERTY"></param>
        /// <returns></returns>
        public static bool IsAGVHSSignal(this Enums.PROPERTY pROPERTY)
        {
            return pROPERTY == Enums.PROPERTY.VALID
                    || pROPERTY == Enums.PROPERTY.TR_REQ
                    || pROPERTY == Enums.PROPERTY.BUSY
                    || pROPERTY == Enums.PROPERTY.AGV_READY
                    || pROPERTY == Enums.PROPERTY.COMPT;
        }
    }
}
