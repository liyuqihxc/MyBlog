<template>
  <div class="child-view" style="height:100%">
    <nuxt/>
  </div>
</template>

<script>
export default {
  head: {
    htmlAttrs: {
      lang: 'zh-cn'
    },
    bodyAttrs: {
      'class': 'background blog'
    }
  },
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

#__nuxt, #__layout {
  height: 100%;
}
</style>