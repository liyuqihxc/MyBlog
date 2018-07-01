<template>
  <div class="content-editor">
      <showdown-editor v-if="allTags && allCategories" :tags="allTags" :categories="allCategories" v-model="article" @save="savePost"></showdown-editor>
  </div>
</template>

<script>
import { mapState } from 'vuex'
import showdown from '@/components/showdown-editor'
import { articles as articlesApi } from '@/api'

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
      articlesApi.addNewPost(
        this.article.title,
        this.article.tags,
        this.article.category,
        this.article.content
      ).then(function (result) {
        alert(result.message)
      }).catch(function (error) {
        console.error(error)
      })
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
