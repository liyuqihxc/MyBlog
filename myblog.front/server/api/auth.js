import { Router } from 'express'
import request from 'request'
// import Proxy from 'http-proxy-agent'

const router = Router()
const proxyurl = process.env.PROXY_URL

router.post('/auth/login', function (req, res, next) {
  request({
    // agent: new Proxy('http://127.0.0.1:8888'),
    method: 'POST',
    url: proxyurl + 'api/auth/login',
    json: req.body
  }, function (error, response, body) {
    if (typeof (response) === 'undefined') {
      res.status(500)
      res.send('后端服务器未返回任何报文,应该是服务器炸了,这个错误是express抛出的。')
      return
    }

    if (!error && response.statusCode === 200) {
      req.session.access_token = body.access_token
      req.session.token_expires_on = body.expires_on
      // console.log(req.session);
      res.json({ 'Message': 'ok' })
    } else {
      res.status(response.statusCode)
      res.send(body)
    }
  })
})

// router.get('/users/:id', function (req, res, next) {
//   const id = parseInt(req.params.id)
//   if (id >= 0 && id < users.length) {
//     res.json(users[id])
//   } else {
//     res.sendStatus(404)
//   }
// })

export default router
