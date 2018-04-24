import Vue from 'vue'

const eventBus = {
  install ({ vue }) {
    vue.prototype.$bus = new Vue()
  }
}

export default () => {
  Vue.use(eventBus)
}
