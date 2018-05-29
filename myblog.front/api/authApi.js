import http from '@/utility/http'

export default {
  /* eslint-disable-next-line */
  async login (params) {
    let result = await http.post('/api/auth/login', { username: params.username, password: params.password, g_recaptcha_response: params.g_recaptcha_response })
    return result
  }
}
