import * as muta from '../mutation-types'
import auth from '@/api/authApi'

const actions = {
  async login ({ commit, state }, loginModel) {
    let logined = await auth.login(loginModel.userName, loginModel.password)
    commit(muta.LOGIN, logined)
  }
}

const mutations = {
  [muta.LOGIN] (state, logined) {
    state.logined = logined
  }
}

const authentication = {
  state: {
    logined: false// 登录后状态为true
  },
  actions,
  mutations
}

export default authentication
