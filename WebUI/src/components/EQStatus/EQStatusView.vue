<template>
  <div class="eq-status mt-2">
    <div>
      <EQElementVue v-for="(data,index) in EQStatusData" :key="index" :data="data"></EQElementVue>
    </div>
  </div>
</template>

<script>
import WebSocketHelp from '@/api/WebSocketHepler'
import EQElementVue from './Components/EQElement.vue'
import param from '@/gpm_param.js'
export default {
  components: {
    EQElementVue,
  },
  data() {
    return {
      EQStatusData: [
        {
          EqName: "",
          Connected: false,
          IsRun: true,
          IsDown: false,
          IsIdle: true,
          Ports: [
            {
              PortID: "3F_AGVC02_PORT_2_7",
              IsInService: true,
              PortType: 0,
              DIOSignalsState: {
                LoadRequest: true,
                UnloadRequest: false,
                PortExist: false,
                PortStatusDown: true,
                LDUpPose: false,
                LDDownPose: true
              },
              HSSignalsState: {
                L_REQ: false,
                U_REQ: false,
                EQ_BUSY: false,
                EQ_READY: false
              }
            }
          ]
        },
      ]
    }
  },
  mounted() {
    var _websocket = new WebSocketHelp('eq_status', param.websocket_url);
    _websocket.Connect();
    var that = this;
    _websocket.wssocket.onmessage = (evt) => {
      that.EQStatusData = JSON.parse(evt.data);
    };
  }
}
</script>

<style lang='scss'>
.eq-status {
}
</style>