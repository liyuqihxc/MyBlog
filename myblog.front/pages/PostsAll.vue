<template>
  <post-list :articles="articles" :loading="loading" :totalPage="totalPage" :tags="allTags"></post-list>
</template>

<script>
import postList from '@/components/post-list'
import * as muta from '@/store/mutation-types'
import { mapState } from 'vuex'

export default {
  components: {
    'post-list': postList
  },
  data () {
    return {
      currentPage: 1,
      loading: false,
      allTags: []
    }
  },
  computed: mapState({
    articles: state => state.articles.articlePaging.list,
    totalPage: state => state.articles.articlePaging.totalPage
  }),
  created () {
    let _This = this
    _This.$store.dispatch(muta.AC_ARTICLES_FETCH_ALL_TAGS).then(function (allTags) {
      _This.allTags = allTags
    })
    _This.getAllArticles()
  },
  methods: {
    getAllArticles (page) {
      let _this = this
      _this.currentPage = page || _this.currentPage
      _this.loading = true
      _this.$store.dispatch(muta.AC_ARTICLES_FETCH_ALL, {
        page: _this.currentPage,
        count: 10
      }).then(function () {
        _this.loading = false
      })
    }
  }
}
</script>
