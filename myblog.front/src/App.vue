<template>
  <div id="app">
    <router-view class="child-view"></router-view>
  </div>
</template>

<script>
export default {
  name: 'App',
  mounted: function () {
    global.eventBus.$on('notify', (msg) => {
      console.log(msg)
      this.$notify({
        title: msg.title,
        message: msg.message,
        type: msg.type,
        duration: 2000
      })
    })
  }
}
</script>
