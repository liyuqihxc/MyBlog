<template>
  <post-list :articles="articles" :loading="loading" :totalPage="totalPage"></post-list>
</template>

<script>
import postList from '@/components/post-list'
import * as types from '@/store/mutation-types'
import { mapState } from 'vuex'

export default {
  components: {
    'post-list': postList
  },
  data () {
    return {
      currentPage: 1,
      loading: false
    }
  },
  computed: mapState({
    articles: state => state.articles.articlePaging.list,
    totalPage: state => state.articles.articlePaging.totalPage
  }),
  mounted () {
    this.getAllArticles()
  },
  methods: {
    getAllArticles (page) {
      let _this = this
      _this.currentPage = page || _this.currentPage
      _this.loading = true
      _this.$store.dispatch(types.AC_ARTICLES_FETCH_ALL, {
        page: _this.currentPage,
        count: 10
      }).then(function () {
        _this.loading = false
      })
    }
  }
}
</script>
