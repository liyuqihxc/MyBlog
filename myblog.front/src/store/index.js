import Vue from 'vue'
import Vuex from 'vuex'
import mutations from './mutations'
import actions from './actions'

import authentication from './modules/authentication'

Vue.use(Vuex)

const store = new Vuex.Store({
  actions,
  mutations,
  modules: {
    authentication
  }
})

export default store
