import * as axios from 'axios'

export default ({ app, store, redirect }) => {
  // The server-side needs a full url to works
  if (process.server) {
    axios.defaults.baseURL = process.env.PROXY_URL || 'http://localhost:3000'
  }
}
