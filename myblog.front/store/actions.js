import * as muta from './mutation-types'

export default {
  async nuxtServerInit ({ dispatch }, { req }) {
    await dispatch(muta.AC_ARTICLES_FETCH_ALL_CATEGORIES_AND_TAGS)
  }
}
