<template>
  <div class=main-frame>
    <el-container>
      <el-header class="no-padding" style="margin-bottom:20px">
        <nav-header :classes="menu" />
      </el-header>
      <el-row>
        <el-col :md="{span:15,offset:4}" :sm="24">
          <el-main class="no-padding">
            <div class="main">
              <div class="call-out"></div>
              <keep-alive>
                <router-view></router-view>
              </keep-alive>
            </div>
          </el-main>
        </el-col>
      </el-row>
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
<style scoped>
</style>
