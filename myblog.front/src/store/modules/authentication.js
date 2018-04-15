import * as muta from '../mutation-types'
import auth from '@/api/authApi'

const actions = {
  async [muta.AC_LOGIN] ({ commit, state }, loginParams) {
    let jwt = await auth.login(loginParams)
    commit(muta.MU_LOGIN, jwt)
  },
  async loadAccessToken ({ commit, state }, arg) {

  }
}

const mutations = {
  [muta.MU_LOGIN] (state, jwt) {
    if (!jwt.access_token) {
      state.checkForBots = true
      return
    }
    state.logined = true
    window.localStorage.setItem('access_token', JSON.stringify(jwt))
  }
}

const authentication = {
  state: {
    logined: false, // 登录后状态为true
    checkForBots: false,
    access_token: ''
  },
  actions,
  mutations
}

export default authentication
