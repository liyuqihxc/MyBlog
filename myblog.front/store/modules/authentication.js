import * as muta from '../mutation-types'
import { auth as authApi } from '@/api'

const actions = {
  /* eslint-disable-next-line */
  async [muta.AC_LOGIN] ({ commit, state }, params) {
    let payload = await authApi.login(params)
    commit(muta.MU_LOGIN, payload)
  }
}

const mutations = {
  [muta.MU_LOGIN] (state, { succeeded, message }) {
    if (succeeded === false) {
      state.checkForBots = true
    } else if (succeeded === true) {
      state.logined = true
    }
  },
  [muta.MU_CHECKFORBOTS] (state, checkForBots) {
    state.checkForBots = checkForBots
  }
}

const auth = {
  state: {
    logined: false, // 登录后状态为true
    checkForBots: false,
    username: ''
  },
  actions,
  mutations
}

export default auth
