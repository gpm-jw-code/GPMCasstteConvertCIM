<template>
  <div class="app-header bg-light text-dark border-bottom fixed-top d-flex flex-row">
    <i @click="ToggleMenu" class="bi bi-list menu-toggle-icon text-dark"></i>
    <h2 @click="Refresh">GPM CIM</h2>
    <p class="px-2">V101</p>
    <div class="page-name-display flex-fill">{{current_route_display}}</div>
    <div class="user-account" @click="LoginClickHandler">
      <span>VISITOR</span>
      <i class="bi bi-person-circle"></i>
    </div>
    <Login ref="login"></Login>
  </div>
</template>
  

<script>
import Login from '@/views/Login.vue';
import bus from '@/event-bus.js'
export default {
  components: {
    Login
  },
  data() {
    return {
      current_route_display: 'CIM'
    }
  },
  mounted() {
    bus.on('/router-change', (new_rotue) => {
      this.current_route_display = new_rotue
    });
  },
  methods: {
    ToggleMenu() {
      this.$emit('toggle_click', '');
    },
    Refresh() {
      window.location.reload();
    },
    LoginClickHandler() {
      this.$refs['login'].Show();
    }
  },
}
</script>

<style scoped lang="scss">
.app-header {
  z-index: 2333;
  h2 {
    margin-left: 40px;
  }
  h2:hover {
    cursor: pointer;
  }

  .page-name-display {
    font-size: 25px;
    font-weight: bold;
  }
  .user-account {
    padding-right: 8px;
    :hover {
      cursor: pointer;
    }
    span {
      font-size: 20px;
      margin-right: 10px;
    }
    i {
      font-size: 28px;
      // background-color: green;
    }
  }
}
</style>