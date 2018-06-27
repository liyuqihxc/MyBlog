<template>
  <el-row>
    <el-col :lg="16" :md="24" style="padding:5px">
      <post-list :articles="articles" :loading="loading" :totalPage="totalPage" :tags="$store.state.articles.allTags" />
    </el-col>
    <el-col :lg="8" class="hidden-md-and-down">
      <side-nav>
        <template slot="custom_link" v-if="logined">
          <li><h3><a href="javascript:void(0)">所有草稿</a></h3></li>
          <li><h3><a href="javascript:void(0)">回收站</a></h3></li>
        </template>
        <template slot="categories">
          <ul class="list-unstyled">
            <li v-for="cat in allCategories" :key="cat.key">
              <h3><a href="javascript:void(0)">{{ cat.label }}</a></h3>
            </li>
          </ul>
        </template>
        <h2 slot="content_title">博文档案</h2>
      </side-nav>
    </el-col>
  </el-row>
</template>

<script>
import { mapState } from 'vuex'

import sidenav from '@/components/side-nav'
import postlist from '@/components/post-list'
import { articles as articlesApi } from '@/api'

export default {
  async asyncData ({ store, params }) {
    let payloadArticle = await articlesApi.listAll(1, 10)
    return {
      articles: payloadArticle.data,
      totalPage: payloadArticle.totalNum / 10 + (payloadArticle.totalNum % 10) === 0 ? 0 : 1
    }
  },
  // fetch ({ store }) {
  //   return new Promise(function (resolve, reject) {
  //     console.log('posts.index.fetch')
  //   })
  // },
  head: {
    title: '博客首页'
  },
  components: {
    'side-nav': sidenav,
    'post-list': postlist
  },
  data () {
    return {
      loading: true,
      articles: [],
      totalPage: 0
    }
  },
  computed: mapState({
    // loading: state => state.articles.allTags.length === 0,
    // allTags: state => state.articles.allTags,
    allCategories: state => state.articles.allCategories,
    logined: state => state.authentication.logined
  }),
  mounted () {
    this.loading = false
  }
}
</script>
