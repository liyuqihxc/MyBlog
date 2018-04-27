import * as muta from '../mutation-types'
import articlesApi from '@/api/articlesApi'

const actions = {
  async [muta.AC_ARTICLES_FETCH_ALL] ({ commit, state }, param) {
    let payload = await articlesApi.listAll(param)
    commit(muta.MU_ARTICLES_UPDATE_PAGING, payload)
  },
  async [muta.AC_ARTICLES_FETCH_ALL_TAGS] ({ commit, state }) {
    let payloadTags = await articlesApi.loadTags()
    return payloadTags
  },
  async [muta.AC_ARTICLES_FETCH_ALL_CATEGORIES] ({ commit, state }) {
    let payloadCats = await articlesApi.loadCategories()
    return payloadCats
  },
  async [muta.AC_ARTICLES_ADD_NEW] ({ commit, state }, { title, category, tags, content }) {
    await articlesApi.addNewPost({ title, category, tags, content })
  },
  async [muta.AC_ARTICLES_LOAD_ARTICLE] ({ commit, state }, id) {
    let result = await articlesApi.loadArticle(id)
    return result
  }
}

const mutations = {
  [muta.MU_ARTICLES_UPDATE_PAGING] (state, payload) {
    state.articlePaging.list = payload.data
    state.articlePaging.totalPage = payload.totalPage
  },
  [muta.MU_ARTICLES_UPDATE_TAGS_CATEGORIES] (state, { payloadTags, payloadCats }) {
    state.allTags = payloadTags
    state.allCategories = payloadCats
  }
}

const articles = {
  state: {
    articlePaging: {
      list: [],
      totalPage: 0
    }
  },
  actions,
  mutations
}

export default articles
