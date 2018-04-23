// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
import Vue from 'vue'
import App from './App'
import router from './router'
import store from './store'
import eui from 'element-ui'
import euilocal from 'element-ui/lib/locale/lang/zh-CN'
import 'element-ui/lib/theme-chalk/index.css'
import './assets/scss/site.scss'
// 引用scss只需要 npm install sass-loader node-sass --save-dev

import fontawesome from '@fortawesome/fontawesome'
import FontAwesomeIcon from '@fortawesome/vue-fontawesome'
import solid from '@fortawesome/fontawesome-free-solid'
import regular from '@fortawesome/fontawesome-free-regular'
import brands from '@fortawesome/fontawesome-free-brands'

fontawesome.library.add(solid)
fontawesome.library.add(regular)
fontawesome.library.add(brands)
Vue.component('fa-icon', FontAwesomeIcon)

Vue.use(eui, { euilocal })
Vue.config.productionTip = false

global.eventBus = new Vue()

/* eslint-disable no-new */
new Vue({
  el: '#app',
  router,
  store,
  template: '<App/>',
  components: {
    App
  }
})
