<template>
  <div class="main-frame" style="height:100%">
    <el-container style="height:100%">
      <el-header class="no-padding" style="margin-bottom:20px">
        <nav-header :categories="menu" />
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
import * as muta from '@/store/mutation-types'
import { mapState } from 'vuex'

export default {
  async fetch ({ store, params }) {
    // let _This = this
    console.log('default.fetch')
    await store.dispatch(muta.AC_ARTICLES_FETCH_ALL_CATEGORIES_AND_TAGS)
    console.log(store.state.articles)
  },
  computed: mapState({
    menu: function (state) {
      let Menus = []
      if (state.articles.allCategories) {
        state.articles.allCategories.forEach(m => {
          Menus.push({ label: m.label, url: '/' })
        })
      }
      return Menus
    }
  }),
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
    }
  },
  created () {
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

<style lang="scss">
html, body {
  height: 100%;
}

#__nuxt, #__layout {
  height: 100%;
}
</style>