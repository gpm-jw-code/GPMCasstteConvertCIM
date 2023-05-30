<template>
  <div class="eq-element border my-2 p-1">
    <div
      class="eq-info text-light d-flex flex-row mb-1"
      v-bind:class="data.Connected?'bg-primary':'bg-danger'"
    >
      <div class="eq-name">
        <b>{{data.Ports.length ==1? '單一轉換架':'平對平組'}}</b>
        <b class="mx-1" style="font-size:16px" v-if="!data.Connected">(DISCONNECT)</b>
      </div>
      <div class="flex-fill"></div>

      <div class="alive-index mx-1">
        <el-tag
          style="width:50px;height:29px;position:relative;top:-2px"
          size="small"
          effect="dark"
          :type="data.Connected? 'primary': 'danger'"
        >{{ data.InterfaceClock }}</el-tag>
      </div>

      <div class="run-states">
        <b-button class="border" squared :variant="data.IsRun? 'success':'secondary'" size="sm">RUN</b-button>
        <b-button
          class="border"
          squared
          :variant="data.IsIdle? 'warning':'secondary'"
          size="sm"
        >IDLE</b-button>
        <b-button class="border" squared :variant="data.IsDown? 'danger':'secondary'" size="sm">DOWN</b-button>
      </div>
    </div>
    <div class="d-flex row">
      <PortElement class="col-lg-4" v-for="(data,index) in data.Ports" :key="index" :data="data"></PortElement>
    </div>
  </div>
</template>

<script>
import PortElement from './PortElement.vue'
export default {
  components: {
    PortElement,
  },
  props: {
    data: {
      type: Object,
      default() {
        return {
          InterfaceClock: 0,
          Ports: []
        }
      }
    },
  },
}
</script>

<style scoped lang="scss">
.eq-element {
  border-radius: 8px;
  .eq-info {
    text-align: left;
    padding: 10px;
    font-size: 28px;
    border-radius: 5px;
  }
}
</style>