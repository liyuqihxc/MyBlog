<template>
  <div class="main-frame" style="height:100%">
    <el-container style="height:100%">
      <el-header v-if="showHeader" class="no-padding" style="margin-bottom:20px">

        <nav-header>
          <template slot="menu">
            <el-menu-item index="1">
              <nuxt-link to="/posts">首页</nuxt-link>
            </el-menu-item>
            <el-submenu index="2" :popper-append-to-body="false">
              <template slot="title">文章分类</template>
              <nuxt-link :to="{path: cat.url}" v-for="(cat, index) in cats" :key="index">
                <el-menu-item :index="'2-' + index">{{ cat.label }}</el-menu-item>
              </nuxt-link>
            </el-submenu>
            <el-submenu index="3" :popper-append-to-body="false" v-if="logined">
              <template slot="title">{{ userName }}</template>
              <nuxt-link to="/global_config">
                <el-menu-item index="3-1">博客设置</el-menu-item>
              </nuxt-link>
              <nuxt-link to="/logout">
                <el-menu-item index="3-2">退出登录</el-menu-item>
              </nuxt-link>
            </el-submenu>
            <el-menu-item index="3" v-else>
              <nuxt-link to="/login">博主登录</nuxt-link>
            </el-menu-item>
            <el-menu-item index="4">
              <a href="mailto:liyuqihxc@gmail.com" title="Email我"><fa-icon :icon="['fas','envelope']" size="lg"/></a>
            </el-menu-item>
            <el-menu-item index="5">
              <a href="https://github.com/liyuqihxc" title="关注GitHub" target="_blank"><fa-icon :icon="['fab','github']" size="lg"/></a>
            </el-menu-item>
          </template>
        </nav-header>

      </el-header>
      <el-main class="no-padding" style="height:100%">
        <nuxt/>
      </el-main>
      <el-footer class="no-padding"><site-footer /></el-footer>
    </el-container>
  </div>
</template>

<script>
import NavHeader from '@/components/nav-header'
import SiteFooter from '@/components/site-footer'
// import * as muta from '@/store/mutation-types'
import { mapState } from 'vuex'

export default {
  fetch () {
    return new Promise(function (resolve, reject) {
      // layout组件的 fetch 方法似乎是不会被调用的
      resolve()
    })
  },
  computed: {
    ...mapState({
      cats: function (state) {
        let Menus = []
        if (state.articles.allCategories) {
          state.articles.allCategories.forEach(m => {
            Menus.push({ label: m.label, url: `/posts/${m.label}` })
          })
        }
        return Menus
      },
      logined: state => state.authentication.logined,
      userName: state => state.authentication.username
    }),
    showHeader: function () {
      return this.$route.name !== 'login'
    }
  },
  components: {
    'nav-header': NavHeader,
    'site-footer': SiteFooter
  },
  head: {
    htmlAttrs: {
      lang: 'zh-cn'
    },
    bodyAttrs: {
      'class': 'background blog'
      // 'class': 'blog'
    }
  },
  beforeMount () {
    let _This = this
    global.eventBus.$on('notify', (msg) => {
      _This.$notify({
        title: msg.title,
        message: msg.message,
        type: msg.type,
        duration: 2000
      })
    })
  }
}
</script>

<style lang="scss" scoped>
.el-menu-item {
  &:hover {
    > * {
      color: inherit !important;
    }
    color: #ffd04b !important;
    border-bottom-color: transparent !important;
    background-color: #383F42;
  }

  &:focus:not(:hover), &.is-active:not(:hover) {
    color: white !important;
    border-bottom-color: transparent !important;
    background-color: #383F42 !important;
  }
}
</style>


<style lang="scss">
html, body {
  height: 100%;
}

#__nuxt, #__layout {
  height: 100%;
}
</style>
