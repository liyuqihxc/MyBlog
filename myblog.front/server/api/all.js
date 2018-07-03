import { Router } from 'express'
import request from 'request'
// import Proxy from 'http-proxy-agent'
import url from 'url'

const router = Router()
const proxyurl = process.env.PROXY_URL

router.all('/*', function (req, res) {
  // var _This = this

  var headers = req.headers
  if (req.session.access_token) {
    headers['Authorization'] = 'Bearer ' + req.session.access_token
  }
  req.pipe(request({
    // agent: new Proxy('http://127.0.0.1:8888'),
    method: req.method,
    url: url.resolve(proxyurl, req.originalUrl),
    headers,
    body: JSON.stringify(req.body)
  }), { end: false }).on('error', function (error) {
    if (error.code === 'ECONNREFUSED') {
      console.error('无法连接到后端服务，请检查后端程序是否启动。')
      res.statusCode = 503
      res.json({message: 'Service Unabailable.', data: null})
      res.end()
    }
  }).on('response', function (pres) {
    delete pres.headers['server']
  }).pipe(res)
})

export default router
