import http from '@/common/http'

export default {
  async login (userName, password) {
    await http.post('/api/login', { username: userName, password: password })
    return true
  }
}
