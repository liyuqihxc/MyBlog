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
