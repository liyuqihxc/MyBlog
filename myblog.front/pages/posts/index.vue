<template>
  <el-row>
    <el-col :lg="16" :md="24" style="padding:5px">
      <post-list :articles="articles" :totalPage="totalPage" :tags="$store.state.articles.allTags" />
    </el-col>
    <el-col :lg="8" class="hidden-md-and-down">
      <side-nav />
    </el-col>
  </el-row>
</template>

<script>
import { mapState } from 'vuex'

import sidenav from '@/components/side-nav'
import postlist from '@/components/post-list'
import { articles as articlesApi } from '@/api'

export default {
  head: {
    title: '石榴骑士的小站 - 博客首页'
  },
  components: {
    'side-nav': sidenav,
    'post-list': postlist
  },
  data () {
    return {
      // loading: true,
      // articles: [],
      // totalPage: 0
    }
  },
  computed: mapState({
    // loading: state => state.articles.allTags.length === 0,
    // allTags: state => state.articles.allTags
  }),
  async asyncData ({ params }) {
    let payloadArticle = await articlesApi.listAll(1, 10)
    return {
      articles: payloadArticle.data,
      totalPage: payloadArticle.totalNum / 10 + (payloadArticle.totalNum % 10) === 0 ? 0 : 1
    }
  },
  mounted () {
    // this.loading = false
    console.log('postsindex.mounted')
    console.log(this.$store.state.articles.allTags)
    console.log(this.articles)
  }
}
</script>
