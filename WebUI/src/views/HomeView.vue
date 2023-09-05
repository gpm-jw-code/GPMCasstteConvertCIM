<template>
  <div class="bg-light text-start d-flex flex-row justify-content-between conn-state px-2">
    <div>
      <el-tag
        style="font-size:20px"
        size="large"
        effect="dark"
        :type="system_state.IsAGVSSecsConnected?'success': 'danger'"
      >AGVS</el-tag>
      <el-tag
        style="font-size:20px"
        size="large"
        effect="dark"
        :type="system_state.IsMCSSecsConnected?'success':'danger'"
      >MCS</el-tag>
    </div>
    <div>
      <el-tag
        v-if="system_state.IsOnlineMode"
        style="font-size:20px"
        size="large"
        effect="dark"
        type="success"
      >ONLINE</el-tag>
      <el-tag v-else style="font-size:20px" size="large" effect="dark" type="danger">OFFLINE</el-tag>

      <el-tag
        v-if="system_state.IsRemoteMode"
        style="font-size:20px"
        size="large"
        effect="dark"
        type="success"
      >REMOTE</el-tag>
      <el-tag v-else style="font-size:20px" size="large" effect="dark" type="danger">LOCAL</el-tag>
    </div>
  </div>
  <AlarmDisplayVue :alarms="system_state.Alarms" :collaseable="false" position="none"></AlarmDisplayVue>
  <div class="home-view h-100 d-flex flex-row">
    <EQStatusViewVue class="w-100"></EQStatusViewVue>
  </div>
</template>

<script>
import EQStatusViewVue from '@/components/EQStatus/EQStatusView.vue'
import WebSocketHelp from '@/api/WebSocketHepler'
import param from '@/gpm_param'
import AlarmDisplayVue from '@/components/App/AlarmDisplay.vue'
export default {
  components: {
    EQStatusViewVue, AlarmDisplayVue
  },
  data() {
    return {
      system_state: {
        IsAGVSSecsConnected: false,
        IsMCSSecsConnected: false,
        IsOnlineMode: false,
        IsRemoteMode: false,
        Alarms: []
      }
    }
  },
  mounted() {
    var ws = new WebSocketHelp('system_state', param.websocket_url)
    ws.Connect();
    ws.wssocket.onmessage = (ev) => {
      this.system_state = JSON.parse(ev.data)
    }
  },
}
</script>

<style lang="scss" scoped>
.conn-state {
  .el-tag {
    margin: 3px;
  }
}
.home-view {
  .left-col {
    overflow-y: scroll;
  }
}
</style>