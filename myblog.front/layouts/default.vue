<template>
  <div id="app" style="height:100%">
    <nuxt class="child-view"></nuxt>
  </div>
</template>

<script>
export default {
  mounted: function () {
    let _This = this
    _This.$bus.$on('notify', (msg) => {
      _This.$notify({
        title: msg.title,
        message: msg.message,
        type: msg.type,
        duration: 2000
      })
    })
  }
}
</script>

<style lang="scss">
html, body {
  height: 100%;
}
</style>