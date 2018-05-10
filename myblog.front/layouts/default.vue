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
  // async asyncData ({ req, params }) {
  //   let cats = await axios.get('/api/categories')
  //   return {
  //     cats: ''
  //   }
  // },
  computed: mapState({
    menu: function (state) {
      let Menus = []
      state.articles.allCategories.forEach(m => {
        Menus.push({ label: m.label, url: '/' })
      })
      return Menus
    }
  }),
  created () {
    let _This = this
    _This.$store.dispatch(muta.AC_ARTICLES_FETCH_ALL_CATEGORIES_AND_TAGS)
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
    }
  },
  mounted: function () {
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