<template>
  <div class="port-element border mx-3 my-1" v-bind:style="bgStyle">
    <div class="port-info d-flex flex-row border-bottom">
      <div v-bind:style="portIDStyle">
        <b>{{data.PortID}}</b>
      </div>
      <div class="flex-fill"></div>
      <div class="auto-states">
        <b-button
          class="border"
          squared
          :variant="data.AutoState==1? 'secondary':'warning'"
          size="sm"
        >MANUAL</b-button>
        <b-button
          class="border"
          squared
          :variant="data.AutoState==1? 'primary':'secondary'"
          size="sm"
        >AUTO</b-button>
      </div>
    </div>
    <div class="d-flex flex-row">
      <div class="port-exist-state border rounded m-3 p-1">
        <!-- {{ data.PortExist?'EXIST':'EMPTY' }} -->
        <div v-show="data.DIOSignalsState.PortExist" class="img exist"></div>
        <div v-show="!data.DIOSignalsState.PortExist" class="img empty">Empty</div>
      </div>

      <div class="io-states d-flex flex-column mt-3">
        <div class="eq-io d-flex flex-row m-1">
          <div class="io-title"># Port Type</div>
          <el-tag
            effect="dark"
            :type="data.PortType==0?'success':'warning'"
          >{{data.PortType==0?'INPUT':'OUTPUT'}}</el-tag>
          <el-button @click="ChangePortType(0)" size="small">To_INPUT</el-button>
          <el-button @click="ChangePortType(1)" size="small">To_OUTPUT</el-button>
        </div>

        <div class="eq-io d-flex flex-row m-1">
          <div class="io-title"># Carrier ID</div>
          <div v-if="data.Carrier_ID===''">(None)</div>
          <el-tag v-else effect="dark">{{data.Carrier_ID}}</el-tag>
          <el-button
            v-if="data.Carrier_ID!=''"
            class="mx-2"
            @click="RemoveCarrierID"
            size="small"
          >清帳</el-button>
        </div>

        <div class="eq-io d-flex flex-row m-1">
          <div class="io-title"># 狀態IO</div>

          <div class="d-flex flex-column">
            <div class="sio1 text-start">
              <el-tag
                effect="dark"
                :type="data.DIOSignalsState.PortStatusDown?'success':'danger'"
              >正常運行</el-tag>
              <el-tag effect="dark" :type="data.DIOSignalsState.LoadRequest?'success':'danger'">載入需求</el-tag>
              <el-tag
                effect="dark"
                :type="data.DIOSignalsState.UnloadRequest?'success':'danger'"
              >移出需求</el-tag>
            </div>
            <div class="sio2">
              <el-tag effect="dark" :type="data.DIOSignalsState.PortExist?'success':'danger'">載具在席</el-tag>
              <el-tag effect="dark" :type="data.DIOSignalsState.LDUpPose?'success':'danger'">撈爪上位</el-tag>
              <el-tag effect="dark" :type="data.DIOSignalsState.LDDownPose?'success':'danger'">撈爪下位</el-tag>
            </div>
          </div>
        </div>
        <div class="eq-io d-flex flex-row m-1">
          <div class="io-title"># 交握IO</div>
          <el-tag effect="dark" :type="data.HSSignalsState.L_REQ?'success':'danger'">L_REQ</el-tag>
          <el-tag effect="dark" :type="data.HSSignalsState.U_REQ?'success':'danger'">U_REQ</el-tag>
          <el-tag effect="dark" :type="data.HSSignalsState.EQ_READY?'success':'danger'">EQ_READY</el-tag>
          <el-tag effect="dark" :type="data.HSSignalsState.EQ_BUSY?'success':'danger'">EQ_BUSY</el-tag>
        </div>

        <!-- <div class="agvs-io d-flex flex-row m-1">
          <div class="io-title">AGV Handshake IO</div>
          <el-tag effect="dark" :type="data.AGVSignals.VALID?'success':'danger'">VALID</el-tag>
          <el-tag effect="dark" :type="data.AGVSignals.TR_REQ?'success':'danger'">TR_REQ</el-tag>
          <el-tag effect="dark" :type="data.AGVSignals.AGV_READY?'success':'danger'">AGV_READY</el-tag>
          <el-tag effect="dark" :type="data.AGVSignals.BUSY?'success':'danger'">BUSY</el-tag>
          <el-tag effect="dark" :type="data.AGVSignals.COMPT?'success':'danger'">COMPT</el-tag>
        </div>-->
      </div>
    </div>
  </div>
</template>

<script>
import param from '@/gpm_param.js'
import { PortTypeChange } from '@/api/CimAPI.js'
export default {
  props: {
    data: {
      type: Object,
      default() {
        return {
          PortID: "3F_AGVC02_PORT_2_5",
          IsInService: true,
          PortType: 0,
          DIOSignalsState: {
            LoadRequest: false,
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
      }
    },
  },
  computed: {
    bgStyle() {
      return {
        backgroundColor: this.data.IsInService ? 'white' : 'pink'
      }
    },
    portIDStyle() {
      return {
        color: this.data.IsInService ? 'rgb(13, 110, 253)' : 'red'
      }
    }
  },
  methods: {
    ChangePortType(type_) {
      PortTypeChange(this.data.PortID, type_);
    },
    RemoveCarrierID() {
      let ws = new WebSocket(`${param.websocket_url}/ui/remove_carrier_data`);
      ws.onopen = (ev) => {
        ws.send(JSON.stringify({
          PortID: this.data.PortID,
          CarrierID: ''
        }));
      }
      ws.onmessage = (ev) => {
        var result = JSON.parse(ev.data)
        this.$swal.fire({
          title: '帳籍移除',
          text: `${result.message}`,
          icon: result.confirm ? 'success' : 'error',
          showCancelButton: false,
          confirmButtonText: 'OK',
          customClass: 'my-sweetalert'
        }).then((result) => {
          // if (result.isConfirmed) {
          //   this.InitializeWorker();
          // }
        })
        ws.close();
      }
    }
  }
}
</script>

<style scoped lang="scss">
.port-element {
  // border-radius: 10px;

  .port-info {
    font-size: 22px;
    padding: 12px;
    border-radius: 2px;
  }
  .port-exist-state {
    .img {
      width: 120px;
      height: 120px;
      border-radius: 10px;
      background-repeat: no-repeat;
      background-size: cover;
    }
    .exist {
      background-image: url("@/assets/images/port-exist.png");
      background-color: seagreen;
    }
    .empty {
      background-image: none;
      background-color: rgb(202, 202, 202);
      color: white;
    }
  }
  .io-states {
    .el-tag {
      margin-right: 3px;
    }
    .io-title {
      width: 100px;
      text-align: left;
    }
  }
}
</style>