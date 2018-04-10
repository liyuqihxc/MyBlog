<template>
  <post-list articles=""></post-list>
</template>

<script>
import post_list from '@/components/post-list'

export default {
  data () {
    return {
    }
  },
  components: {
    'post-list': post_list
  }
}
</script>
