<template>
  <div class="map-view h-100 d-flex flex-row my-4">
    <div class="opts-container mx-3 p-3 border">
      <el-form label-width="80px" label-position="left">
        <el-form-item label="模式">
          <el-radio-group v-model="mode_selected">
            <el-radio-button label="檢視" />
            <el-radio-button label="編輯" />
          </el-radio-group>
        </el-form-item>
        <el-form-item label="編輯動作">
          <el-radio-group v-model="action_selected">
            <el-radio-button label="無" />
            <el-radio-button label="新增點位" />
            <el-radio-button label="移除點位" />
            <el-radio-button label="編輯點位" />
          </el-radio-group>
        </el-form-item>
      </el-form>
    </div>
    <MapShow style="height:100%;width: 100%;"></MapShow>
  </div>
</template>

<script>
import MapShow from '@/components/MapShow.vue';
export default {
  components: {
    MapShow,
  },
  data() {
    return {
      mode_selected: '檢視',
      action_selected: '無',
    }
  },
}
</script>

<style lang="scss" scoped>
.map-view {
  .opts-container {
    width: 40%;
  }
}
</style>