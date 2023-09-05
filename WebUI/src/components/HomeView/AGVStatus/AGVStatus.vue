<template>
  <div class="agv-status card-like">
    <div class="title">
      <i class="bi bi-robot">AGV STATUS</i>
    </div>
    <el-table :data="tableData" size="large" empty-text="沒有AGV">
      <el-table-column label="AGV Name" prop="AGV_Name"></el-table-column>
      <!-- <el-table-column label="AGV ID" prop="AGV_ID"></el-table-column> -->
      <!-- <el-table-column label="通訊狀態"></el-table-column> -->
      <el-table-column label="Online Status" prop="Online_Status">
        <template #default="scope">
          <div class="online-status-div">
            <el-tag
              effect="dark"
              @click="ShowOnlineStateChangeModal(scope.row.AGV_Name,scope.row.Online_Status)"
              :type="scope.row.Online_Status =='Offline'?'danger':'success'"
            >{{ scope.row.Online_Status }}</el-tag>
          </div>
        </template>
      </el-table-column>
      <el-table-column label="運轉狀態" prop="Running_Status"></el-table-column>
      <el-table-column label="目前位置" prop></el-table-column>
      <el-table-column label="Carrier ID" prop="Carrier_ID"></el-table-column>
      <el-table-column label="電量" prop="Battery_Level">
        <template #default="scope">
          <div>
            <el-progress :percentage="scope.row.Battery_Level"></el-progress>
          </div>
        </template>
      </el-table-column>
      <el-table-column label="操作">
        <template #default="scope">
          <div>
            <b-button @click="ShowTaskAllocationView(scope.row)" size="sm" variant="primary">任務派送</b-button>
          </div>
        </template>
      </el-table-column>
    </el-table>
  </div>
  <!--Modals-->
  <div class="modals">
    <b-modal
      v-model="ShowOnlineStateChange"
      title="Online/Offline Change"
      :centered="true"
      @ok="SendOnlineStateChangeRequest"
    >
      <p ref="online_status_change_noti_txt"></p>
    </b-modal>
  </div>
</template>

<script>
import { clsAgvStatus } from '@/ViewModels/WebViewModels.js'
import Notifier from '@/api/NotifyHelper';
import bus from '@/event-bus';
export default {
  mounted() {
    this.tableData[0].AGV_Name = 'AGV_1';
    this.tableData[1].AGV_Name = 'AGV_2';
  },
  data() {
    return {
      ShowOnlineStateChange: false,
      tableData: [
        new clsAgvStatus(),
        new clsAgvStatus(),
      ],
      OnlineStatusReq: {
        AGV_Name: '',
        Online_Status: '',
      }
    }
  },
  methods: {
    ShowTaskAllocationView(clsAgvStatus) {
      // if (clsAgvStatus.Online_Status == 'Offline') {
      //   Notifier.Warning(`${clsAgvStatus.AGV_Name} Offline`);
      // }
      bus.emit('bus-show-task-allocation', clsAgvStatus);
    },
    ShowOnlineStateChangeModal(agv_name, current_online_status) {

      this.OnlineStatusReq.AGV_Name = agv_name;
      this.OnlineStatusReq.Online_Status = current_online_status == 'Offline' ? 'Online' : 'Offline';
      this.$refs['online_status_change_noti_txt'].innerHTML = `<h4>確定要將 ${this.OnlineStatusReq.AGV_Name}  ${this.OnlineStatusReq.Online_Status}?</h4>`;
      this.ShowOnlineStateChange = true;
    },
    SendOnlineStateChangeRequest() {
      Notifier.Success(`${this.OnlineStatusReq.AGV_Name} - ${this.OnlineStatusReq.Online_Status} 請求已送出`, 'top', 3000);
    }
  },
}
</script>

<style lang="scss" scoped>
.agv-status {
  height: 60%;

  .online-status-div:hover {
    cursor: pointer;
  }
}
</style>