<template>
  <div class="content-editor">
      <showdown-editor></showdown-editor>
  </div>
</template>

<script>
import showdown from '@/components/showdown-editor'

export default {
  data () {
    return {
    }
  },
  components: {
    'showdown-editor': showdown
  }
}
</script>

<style lang="scss" scoped>
.content-editor {
  display: flex;
  flex: 1;
  flex-direction: column;
  height: 100%;
}
</style>
