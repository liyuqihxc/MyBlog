import { Router } from 'express'
import request from 'request'
import path from 'path'
import fs from 'fs'

const router = Router()
const proxyurl = process.env.PROXY_URL

router.all('/*', function (req, res, next) {
  console.log('/api/*')
  var _This = this
  request({
    method: req.method,
    url: proxyurl + req.originalUrl,
    headers: {
      'content-type': 'application/json',
      'Authorization': 'Bearer ' + req.session.access_token
    },
    body: JSON.stringify(req.body)
  }, function (error, response, body) {
    if (typeof (response) === 'undefined') {
      res.status(500)
      res.send('后端服务器未返回任何报文,应该是服务器炸了,这个错误是express抛出的')
      return
    }

    if (!error && response.statusCode === 200) {
      res.status(response.statusCode)
      // 没有type的时候默认类型为html
      if (typeof (response.headers['content-type']) === 'undefined') {
        response.headers['content-type'] = 'text/html'
        res.send(body)
        return
      }

      // json类型
      if (response.headers['content-type'].indexOf('application/json') !== -1) {
        res.json(JSON.parse(body))
        return
      }
      // html类型
      if (response.headers['content-type'].indexOf('text/html') !== -1) {
        res.send(body)
        return
      }
      // 文件
      if (response.headers['content-type'].indexOf('application/ms-excel') !== -1) {
        res.end()
        return
      }

      // 文件
      if (response.headers['content-type'].indexOf('application/octet-stream') !== -1) {
        var filename = decodeURI(response.headers['content-disposition'].substr(response.headers['content-disposition'].indexOf('filename=') + 9))
        var fileurl = path.join(__dirname, 'file', filename)
        var stream = fs.createWriteStream(fileurl)
        request({
          url: proxyurl + req.originalUrl,
          headers: {
            'content-type': 'application/json',
            'Authorization': 'Bearer ' + req.session.access_token
          }
        }).pipe(stream).on('close', function () {
          res.download(fileurl, filename)
        })
        // 这里必须return
        return
      }

      res.send(body)
    } else {
      switch (parseInt(response.statusCode)) {
        case 401:
          _This.flushtoken(req, res)
          break
        default:
          res.status(response.statusCode || 500)
          res.send(body)
          break
      }
    }
  })
})

export default router
