<template>
  <div class="content-editor">
      <showdown-editor v-if="allTags && allCategories" :tags="allTags" :categories="allCategories" v-model="article" @save="savePost"></showdown-editor>
  </div>
</template>

<script>
import showdown from '@/components/showdown-editor'
import * as muta from '@/store/mutation-types'

export default {
  data () {
    return {
      article: {
        title: '',
        content: '',
        tags: [],
        category: undefined
      },
      allTags: [],
      allCategories: []
    }
  },
  components: {
    'showdown-editor': showdown
  },
  created () {
    let _This = this
    _This.$store.dispatch(muta.AC_ARTICLES_FETCH_ALL_TAGS).then(function (allTags) {
      _This.allTags = allTags
    })
    _This.$store.dispatch(muta.AC_ARTICLES_FETCH_ALL_CATEGORIES).then(function (allCategories) {
      console.log(allCategories)
      _This.allCategories = allCategories
    })
  },
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
