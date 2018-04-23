import http from '@/common/http'

export default {
  /* eslint-disable-next-line */
  async login ({ username, password, g_recaptcha_response }) {
    let result = await http.post('/api/auth/login', { username, password, g_recaptcha_response })
    return result
  }
}
