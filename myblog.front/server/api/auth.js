import { Router } from 'express'
import request from 'request'
// import Proxy from 'http-proxy-agent'
import url from 'url'

const router = Router()
const proxyurl = process.env.PROXY_URL

router.post('/auth/login', function (req, res, next) {
  request({
    // agent: new Proxy('http://127.0.0.1:8888'),
    method: 'POST',
    url: url.resolve(proxyurl, '/api/auth/login'),
    json: req.body
  }, function (error, response, body) {
    if (!error && response.statusCode === 200) {
      req.session.access_token = body.access_token
      req.session.token_expires_on = body.expires_on
      // console.log(req.session);
    } else {
    }
  }).pipe(res)
})

export default router
