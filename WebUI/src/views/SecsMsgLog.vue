<template>
  <div class="secs-log d-flex flex-row justify-content-between h-100">
    <el-table :data="secslogs" @row-click="RowClickHandle" size="large" row-key="Time">
      <el-table-column prop="Time" label="Time"></el-table-column>
      <el-table-column prop="Direction" label="Direction"></el-table-column>
      <el-table-column prop="SxFx" label="SxFy"></el-table-column>
      <el-table-column prop="Sml" label="Content">
        <template #default="scope">
          <div>
            <pre>
                {{ scope.row.Sml.substring(0,40) }}
            </pre>
          </div>
        </template>
      </el-table-column>
    </el-table>
    <div class="sml-display border w-50 text-start px-3">
      <div>
        <h3>Function {{ selectedSecsLog.SxFx }}</h3>
        <h3>Sml</h3>
        <pre class="bg-light">
            {{ selectedSecsLog.Sml }}
        </pre>
      </div>
    </div>
  </div>
</template>

<script>
import WebSocketHelp from '@/api/WebSocketHepler'
import param from '@/gpm_param'
import { FormatTimeString } from '@/tools/TimeTool'
export default {
  data() {
    return {
      secslogs: [],
      selectedSecsLog: {
        Time: '',
        Direction: '',
        SxFx: '',
        Sml: ''
      },
    }
  },
  mounted() {
    var ws = new WebSocketHelp('secslog', param.websocket_url)
    ws.Connect();
    ws.wssocket.onmessage = (ev) => {
      var secslog = JSON.parse(ev.data);
      secslog.Time = FormatTimeString(secslog.Time)
      this.secslogs.unshift(secslog)
      if (this.secslogs.length > 10) {
        this.secslogs.pop()
      }
    }
  },
  methods: {
    RowClickHandle(rowData) {
      this.selectedSecsLog = rowData
    }
  },
}
</script>

<style lagn="scss">
.secs-log {
}
</style>