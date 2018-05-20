<template>
  <div class="content-editor">
      <showdown-editor v-if="allTags && allCategories" :tags="allTags" :categories="allCategories" v-model="article" @save="savePost"></showdown-editor>
  </div>
</template>

<script>
import { mapState } from 'vuex'
import showdown from '@/components/showdown-editor'
import * as muta from '@/store/mutation-types'

export default {
  head: {
    title: '添加新文章 - 石榴骑士的小站'
  },
  data () {
    return {
      article: {
        title: '',
        content: '',
        tags: [],
        category: undefined
      }
    }
  },
  components: {
    'showdown-editor': showdown
  },
  computed: mapState({
    allTags: state => state.articles.allTags,
    allCategories: state => state.articles.allCategories
  }),
  methods: {
    savePost () {
      this.$store.dispatch(muta.AC_ARTICLES_ADD_NEW, this.article)
    }
  }
}
</script>

<style lang="scss">
.call-out {
  display: none;
}
</style>

<style lang="scss" scoped>
.content-editor {
  display: flex;
  flex: 1;
  flex-direction: column;
  height: 100%;
}
</style>
