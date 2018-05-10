import * as muta from '../mutation-types'
import http from '@/utility/http'

const actions = {
  async [muta.AC_ARTICLES_FETCH_ALL] ({ commit, state }, params) {
    let payload = await http.fetch('/api/articles/list', { params })
    commit(muta.MU_ARTICLES_UPDATE_PAGING, payload)
  },
  async [muta.AC_ARTICLES_FETCH_ALL_CATEGORIES_AND_TAGS] ({ commit, state }) {
    let payloadCats = await http.fetch('/api/articles/allcategories')
    let payloadTags = await http.fetch('/api/articles/alltags')
    commit(muta.MU_ARTICLES_UPDATE_TAGS_CATEGORIES, { payloadTags, payloadCats })
  },
  async [muta.AC_ARTICLES_ADD_NEW] ({ commit, state }, { title, category, tags, content }) {
    await http.post('/api/articles/addnew', { title, category, tags, content })
  },
  async [muta.AC_ARTICLES_LOAD_ARTICLE] ({ commit, state }, id) {
    let result = await http.fetch('/api/articles/loadarticle', { params: { id } })
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
    },
    allTags: [],
    allCategories: []
  },
  actions,
  mutations
}

export default articles
