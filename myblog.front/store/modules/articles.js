import * as muta from '../mutation-types'
import { articles as articlesApi } from '@/api'

const actions = {
  async [muta.AC_ARTICLES_FETCH_ALL_CATEGORIES_AND_TAGS] ({ commit, state }) {
    let payloadCats = await articlesApi.loadCategories()
    let payloadTags = await articlesApi.loadTags()
    commit(muta.MU_ARTICLES_UPDATE_TAGS_CATEGORIES, {
      tags: payloadTags,
      cats: payloadCats
    })
  }
}

const mutations = {
  [muta.MU_ARTICLES_UPDATE_TAGS_CATEGORIES] (state, { tags, cats }) {
    state.allTags = tags
    state.allCategories = cats
  }
}

const articles = {
  state: {
    allTags: [],
    allCategories: []
  },
  actions,
  mutations
}

export default articles
