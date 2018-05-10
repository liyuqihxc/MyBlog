import * as muta from '../mutation-types'
import http from '@/utility/http'

const actions = {
  /* eslint-disable-next-line */
  async [muta.AC_LOGIN] ({ commit, state }, { username, password, g_recaptcha_response }) {
    let jwt = await http.post('/api/auth/login', { username, password, g_recaptcha_response })
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
