import * as muta from './mutation-types'

export default {
  async nuxtServerInit ({ commit, dispatch }, { req }) {
    await dispatch(muta.AC_ARTICLES_FETCH_ALL_CATEGORIES_AND_TAGS)

    if (req.session && req.session.checkForBots) {
      commit(muta.MU_CHECKFORBOTS, req.session.checkForBots)
    } else if (req.session) {
      req.session.checkForBots = true
    }
  }
}
