<template>
  <div class="w-100 bg-light">
    <el-tag style="font-size:20px" size="large" effect="dark" type="success">ONLINE</el-tag>
    <el-tag style="font-size:20px" size="large" effect="dark" type="danger">OFFLINE</el-tag>
  </div>
  <div class="home-view h-100 d-flex flex-row">
    <EQStatusViewVue class="w-100"></EQStatusViewVue>
  </div>
</template>

<script>
import EQStatusViewVue from '@/components/EQStatus/EQStatusView.vue'
export default {
  components: {
    EQStatusViewVue
  },
  data() {
    return {

    }
  },
}
</script>

<style lang="scss" scoped>
.home-view {
  .left-col {
    overflow-y: scroll;
  }
}
</style>