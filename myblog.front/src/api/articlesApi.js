import http from '@/common/http'

export default {
  async listAll (params) {
    let result = await http.fetch('/api/articles/list', { params })
    return result
  },
  async loadCategories () {
    let result = await http.fetch('/api/articles/allcategories')
    return result
  },
  async loadTags () {
    let result = await http.fetch('/api/articles/alltags')
    return result
  }
}
