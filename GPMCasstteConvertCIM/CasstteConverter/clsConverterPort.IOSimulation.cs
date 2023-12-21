using GPMCasstteConvertCIM.CasstteConverter.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPMCasstteConvertCIM.CasstteConverter
{
    public partial class clsConverterPort
    {
        private LDULD_STATUS _LDULD_Status_Simulation = LDULD_STATUS.DOWN;
        public LDULD_STATUS LDULD_Status_Simulation
        {
            get => _LDULD_Status_Simulation;
            set
            {
                if (value == LDULD_STATUS.LOADABLE)
                    LoadableSimulate();
                if (value == LDULD_STATUS.UNLOADABLE)
                    UnloadableSimulate();
                if (value == LDULD_STATUS.DOWN)
                    StatusDownSimulate();
                _LDULD_Status_Simulation = value;
            }
        }
        public enum LDULD_STATUS
        {
            UNLOADABLE,
            LOADABLE,
            DOWN
        }
        /// <summary>
        /// 貨物可移入模擬
        /// </summary>
        public void LoadableSimulate()
        {
            load_request_address.ControlValue = true;
            unload_request_address.ControlValue = false;
            port_status_down_address.ControlValue = true;
            ld_up_pose_address.ControlValue = false;
            ld_down_pose_address.ControlValue = true;
            port_exist_address.ControlValue = false;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LoadRequest"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PortStatusDown"));
        }
        /// <summary>
        /// 貨物可載出模擬
        /// </summary>
        public void UnloadableSimulate()
        {
            load_request_address.ControlValue = false;
            unload_request_address.ControlValue = true;
            port_status_down_address.ControlValue = true;
            ld_up_pose_address.ControlValue = true;
            ld_down_pose_address.ControlValue = false;
            port_exist_address.ControlValue = true;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LoadRequest"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PortStatusDown"));
        }

        /// <summary>
        /// Port當機模擬
        /// </summary>
        public void StatusDownSimulate()
        {
            load_request_address.ControlValue = false;
            unload_request_address.ControlValue = false;
            port_status_down_address.ControlValue = false;
            ld_up_pose_address.ControlValue = false;
            ld_down_pose_address.ControlValue = true;
            port_exist_address.ControlValue = false;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PortStatusDown"));
        }

    }
}
