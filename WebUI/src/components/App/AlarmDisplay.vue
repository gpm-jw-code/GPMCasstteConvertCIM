<template>
  <div class="alarm-display w-100 fixed-bottom">
    <transition name="el-zoom-in-bottom">
      <div v-show="mode=='show'" class="show-mode border">
        <div class="d-flex flex-row">
          <b-button squared variant="secondary" @click="mode='hidden'">
            <i class="bi bi-chevron-double-down"></i>
          </b-button>
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
export default {
  setup() {

  },
  data() {
    return {
      mode: 'show' //hidden;show
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

  },
}
</script>

<style lang="scss" scoped>
.alarm-display {
  z-index: 2;
  .show-mode {
    background: pink;
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
    height: 90px;
  }
}
</style>