<template>
  <div class="content-editor">
      <showdown-editor :tags="allTags" :categories="allCategories" v-model="article"></showdown-editor>
  </div>
</template>

<script>
import showdown from '@/components/showdown-editor'
import * as muta from '@/store/mutation-types'
import { mapState } from 'vuex'

export default {
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
  mounted () {
    let _This = this
    _This.$store.dispatch(muta.AC_ARTICLES_FETCH_TAGS_CATEGORIES).then(function () {

    })
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
