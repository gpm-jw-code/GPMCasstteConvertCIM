<template>
  <div class="alarm-display w-100 border" v-bind:class="position">
    <transition name="el-zoom-in-bottom">
      <div v-show="mode=='show'" class="show-mode border d-flex flex-row">
        <div class="w-100 d-flex flex-row">
          <b-button v-if="collaseable" squared variant="secondary" @click="mode='hidden'">
            <i class="bi bi-chevron-double-down"></i>
          </b-button>
          <div class="alarm-container w-100">
            <table class="w-100">
              <tbody class="w-100">
                <tr class="header-tr">
                  <td style="width:210px">時間</td>
                  <td style="width:210px">Level</td>
                  <td style="width:260px">類別</td>
                  <td style="width:210px">設備名稱</td>
                  <td>警報描述</td>
                </tr>
                <tr v-if="displayingAlarm!=undefined" v-bind:class="level_style">
                  <td>{{ TimeFormat(displayingAlarm.Time) }}</td>
                  <td>
                    <el-tag
                      effect="dark"
                      :type="displayingAlarm.Level==1?'warning':'danger'"
                      size="large"
                    >{{ displayingAlarm.Level==1?'Warning':'Alarm'}}</el-tag>
                  </td>
                  <td>{{ displayingAlarm.Classify }}</td>
                  <td>{{ displayingAlarm.EQPName }}</td>
                  <td>{{ displayingAlarm.Description }}</td>
                </tr>
                <tr v-else>
                  <td></td>
                  <td></td>
                  <td></td>
                  <td></td>
                  <td></td>
                </tr>
              </tbody>
            </table>
          </div>
        </div>

        <div>
          <b-button
            squared
            style="width:120px;height:100%;"
            @click="ClearAlarm()"
            variant="danger"
          >異常清除</b-button>
        </div>
      </div>
    </transition>
    <div v-show="mode=='hidden'" class="hidden-mode">
      <b-button squared variant="danger" @click="mode='show'">
        Alarms
        <i class="bi bi-chevron-double-up"></i>
      </b-button>
    </div>
  </div>
</template>

<script>
import bus from '@/event-bus.js'
import { watch, ref } from 'vue';
import { useRoute } from 'vue-router'
import moment from 'moment';
import { ClearAlarm } from '@/api/CimAPI.js'
import { FormatTimeString } from '@/tools/TimeTool.js'
export default {
  setup() {

  },
  props: {
    position: {
      type: String,
      default: 'fixed-bottom'
    },
    collaseable: {
      type: Boolean,
      default: true
    },
    alarms: {
      type: Array,
      default() {
        return [
          {
            Level: 1,
            Time: "2023-06-01T10:00:47.8800429+08:00",
            Description: "上報PORT IN-SERVICE的過程中發生異常",
            Classify: "REPORT TO MCS",
            EQPName: "3F_AGVC02_PORT_2_5",
            Code: 4107,
            Code_int: 4107,
            Duration: 0
          },

        ]
      }
    }
  },
  data() {
    return {
      mode: 'show',//hidden;show,
      dislayAlarmIndex: 0
    }
  },
  mounted() {
    // bus.emit('/router-change', display_name);
    const currentRoute = ref('')
    const route = useRoute()
    watch(
      () => route.path,
      (newValue, oldValue) => {
        if (newValue != "/") {
          this.mode = 'hidden'
        }
        else this.mode = 'show'
      }
    )
    setInterval(() => {
      this.AlarmShowTimerTick();
    }, 1000);
  },
  methods: {
    TimeFormat(time_str) {
      return FormatTimeString(time_str);
    },
    AlarmShowTimerTick() {
      if (this.alarms.length != 0) {
        if (this.dislayAlarmIndex >= this.alarms.length - 1) {
          this.dislayAlarmIndex = 0;
        } else {
          this.dislayAlarmIndex += 1;
        }
      }
    },
    ClearAlarm() {
      ClearAlarm();
    }
  },
  computed: {
    level_style() {
      return this.displayingAlarm.Level == 1 ? 'warning' : 'alarm';
    },
    displayingAlarm() {
      if (this.alarms.length != 0)
        return this.alarms[this.dislayAlarmIndex];
    }
  },
}
</script>

<style lang="scss" scoped>
.alarm-display {
  z-index: 2;
  border-radius: 10px;
  .alarm-container {
    table {
      tr,
      td {
        // color: orange;
        font-size: 16px;
        padding: 3px;
      }
      td {
        border: 3px solid rgb(204, 204, 204);
        .el-tag {
          font-size: 16px;
        }
      }
      .header-tr {
        font-weight: bold;
      }
    }
  }

  .show-mode {
    background: rgb(247, 176, 188);
    // box-shadow: 4px 8px 25px 2px black;
  }
  .hidden-mode {
    background-color: transparent;
    text-align: left;
  }
  button,
  .hidden-mode,
  .show-mode {
    height: 40px;
  }

  .show-mode {
    height: auto;
  }
}
.warning {
  background-color: rgb(255, 254, 78);
}
.alarm {
  background-color: rgb(253, 16, 55);
  color: white;
}
</style>