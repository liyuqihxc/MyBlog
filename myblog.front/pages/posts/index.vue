<template>
  <el-row>
    <el-col :lg="16" :md="24" style="padding:5px">
      <post-list :articles="articles" :loading="loading" :totalPage="totalPage" :tags="allTags" />
    </el-col>
    <el-col :lg="8" class="hidden-md-and-down">
      <side-nav />
    </el-col>
  </el-row>
</template>

<script>
import sidenav from '@/components/side-nav'
import postlist from '@/components/post-list'
import { articles } from '@/api'

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
    }
  },
  async asyncData ({ params }) {
    let payloadArticle = await articles
    // return { title: data.title }
  }
}
</script>
