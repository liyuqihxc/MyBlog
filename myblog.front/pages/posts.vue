<template>
  <div class="main-frame" style="height:100%">
    <el-container style="height:100%">
      <el-header class="no-padding" style="margin-bottom:20px">
        <nav-header :classes="menu" />
      </el-header>
      <el-main class="no-padding" style="height:100%">
        <el-row type="flex" justify="center" style="min-height:100%">
          <el-col class="main" :md="15" :sm="24">
            <el-row>
              <el-col :lg="16" :md="24" style="padding:5px">
                <post-list />
              </el-col>
              <el-col :lg="8" class="hidden-md-and-down">
                <side-nav />
              </el-col>
            </el-row>
          </el-col>
        </el-row>
      </el-main>
      <el-footer class="no-padding"><site-footer /></el-footer>
    </el-container>
  </div>
</template>

<script>
import sidenav from '@/components/side-nav'
import postlist from '@/components/post-list'
import NavHeader from '@/components/nav-header'
import SiteFooter from '@/components/site-footer'

export default {
  components: {
    'side-nav': sidenav,
    'post-list': postlist,
    'nav-header': NavHeader,
    'site-footer': SiteFooter
  },
  head: {
    title: '石榴骑士的小站 - 博客首页'
  },
  data () {
    return {
      menu: [
        { name: '电子技术', url: '/' },
        { name: 'Linux', url: '/' }
      ]
    }
  }
}
</script>
