<template>
  <div class="content-editor">
    <showdown-editor v-if="allTags && allCategories" v-model="article" :categories="allCategories" :tags="allTags" @save="savePost" @publish="publishPost"></showdown-editor>
  </div>
</template>

<script>
import { mapState } from 'vuex'
import showdown from '@/components/showdown-editor'
import { articles as articlesApi } from '@/api'

export default {
  head: {
    title: '添加新文章',
    meta: [
      { hid: 'description', name: 'description', content: '创建博文' }
    ]
  },
  data () {
    return {
      article: {
        id: '',
        title: '',
        content: '',
        tags: [],
        category: undefined,
        updated: false // content 内容是否更改
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
      let _This = this
      articlesApi.addNewPost(
        this.article.title,
        this.article.tags,
        this.article.category,
        this.article.content
      ).then(function (result) {
        alert(result.message)
        if (result.ID) {
          _This.id = result.ID
          // _This.$router.push('/posts/viewpost/'.concat(result.ID))
        }
      }).catch(function (error) {
        console.error(error)
      })
    },
    publishPost () {

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
