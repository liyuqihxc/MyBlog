import http from '@/utility/http'

export default {
  async listAll (page, count) {
    let result = await http.fetch('/api/articles/list', {
      params: { page, count }
    })
    return result
  },
  async loadCategories () {
    let result = await http.fetch('/api/articles/allcategories')
    return result
  },
  async loadTags () {
    let result = await http.fetch('/api/articles/alltags')
    return result
  },
  async addNewPost (params) {
    let result = await http.post('/api/articles/addnew', params)
    return result
  },
  async loadArticle (id) {
    let result = await http.fetch('/api/articles/loadarticle', {
      params: {
        id
      }
    })
    return result
  }
}
