import * as muta from './mutation-types'

export default {
  async nuxtServerInit ({ commit, dispatch }, { req }) {
    await dispatch(muta.AC_ARTICLES_FETCH_ALL_CATEGORIES_AND_TAGS)

    if (req.session && req.session.checkForBots) {
      commit(muta.MU_CHECKFORBOTS, req.session.checkForBots)
    } else if (req.session) {
      // req.session.checkForBots = true
      // commit(muta.MU_CHECKFORBOTS, req.session.checkForBots)
    }

    if (req.session && req.session.access_token) {
      commit(muta.MU_LOGIN, { succeeded: true, nick_name: req.session.user_nick_name })
    }
  }
}
