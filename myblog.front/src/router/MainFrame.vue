<template>
  <div class="main-frame" style="height:100%">
    <el-container style="height:100%">
      <el-header class="no-padding" style="margin-bottom:20px">
        <nav-header :classes="menu" />
      </el-header>
      <el-main class="no-padding" style="height:100%">
        <el-row type="flex" justify="center" style="min-height:100%">
          <el-col :md="15" :sm="24">
            <div class="main">
              <router-view></router-view>
            </div>
          </el-col>
        </el-row>
      </el-main>
      <el-footer class="no-padding">
        <site-footer />
      </el-footer>
    </el-container>
  </div>
</template>

<script>
import NavHeader from '@/components/nav-header'
import SiteFooter from '@/components/site-footer'

export default {
  name: 'MainFrame',
  components: {
    'nav-header': NavHeader,
    'site-footer': SiteFooter
  },
  data () {
    return {
      menu: [
        { name: '电子技术', url: '/' },
        { name: 'Linux', url: '/' }
      ]
    }
  },
  methods: {
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style lang="scss" scoped>

</style>
