import * as muta from '../mutation-types'
import { auth as authApi } from '@/api'

const actions = {
  /* eslint-disable-next-line */
  async [muta.AC_LOGIN] ({ commit, state }, params) {
    let payload = await authApi.login(params)
    if (payload.data === null) {
      global.eventBus.$emit('notify', {
        title: '无法登陆',
        message: payload.message,
        type: 'error'
      })
    } else {
      commit(muta.MU_LOGIN, payload)
    }
  }
}

const mutations = {
  /* eslint-disable-next-line */
  [muta.MU_LOGIN] (state, { succeeded, message, nick_name }) {
    if (succeeded === true) {
      state.logined = true
      /* eslint-disable-next-line */
      state.username = nick_name
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
