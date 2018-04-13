import * as muta from '../mutation-types'
import auth from '@/api/authApi'

const actions = {
  async login ({ commit, state }, loginModel) {
    let jwt = await auth.login(loginModel.userName, loginModel.password)
    commit(muta.LOGIN, jwt)
  }
}

const mutations = {
  [muta.LOGIN] (state, jwt) {
    state.logined = jwt
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
