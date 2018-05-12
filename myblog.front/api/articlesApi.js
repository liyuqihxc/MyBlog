import http from '@/utility/http'

export default {
  listAll (params) {
    let result = http.fetch('/api/articles/list', { params })
    return result
  },
  loadCategories () {
    return http.fetch('/api/articles/allcategories')
  },
  loadTags () {
    return http.fetch('/api/articles/alltags')
  },
  async addNewPost (params) {
    return http.post('/api/articles/addnew', params)
  },
  loadArticle (id) {
    return http.fetch('/api/articles/loadarticle', {
      params: {
        id
      }
    })
  }
}
