import { Router } from 'express'
import request from 'request'
// import Proxy from 'http-proxy-agent'
import url from 'url'

const router = Router()
const proxyurl = process.env.PROXY_URL

router.all('/*', function (req, res, next) {
  // var _This = this

  var headers = req.headers
  if (req.session.access_token) {
    headers['Authorization'] = 'Bearer ' + req.session.access_token
  }
  request({
    // agent: new Proxy('http://127.0.0.1:8888'),
    method: req.method,
    url: url.resolve(proxyurl, req.originalUrl),
    headers,
    body: JSON.stringify(req.body)
  }).pipe(res)
})

export default router
