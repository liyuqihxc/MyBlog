import Vue from 'vue'
import Vuex from 'vuex'
import mutations from './mutations'
import actions from './actions'

import authentication from './modules/authentication'
import articles from './modules/articles'

Vue.use(Vuex)

const createStore = () => {
  return new Vuex.Store({
    actions,
    mutations,
    modules: {
      authentication,
      articles
    }
  })
}

export default createStore
