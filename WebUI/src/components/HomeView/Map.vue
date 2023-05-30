<template>
  <div class="map card-like">
    <div class="title">
      <i class="bi bi-map">MAP SHOW</i>
    </div>
    <MapShow style="height:95%"></MapShow>
  </div>
</template>

<script>
import MapShow from '../MapShow.vue';
export default {
  components: {
    MapShow,
  },
}
</script>

<style lang="scss" scoped>
.map {
}
</style>