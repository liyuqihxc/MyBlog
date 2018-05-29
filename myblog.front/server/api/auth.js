import { Router } from 'express'
import request from 'request'
import Proxy from 'http-proxy-agent'
import url from 'url'

const router = Router()
const proxyurl = process.env.PROXY_URL

const checkForBotsProc = function (recaptchaResponse, remoteAddress, callback, callbackState) {
  request({
    agent: new Proxy('http://127.0.0.1:8888'),
    method: 'POST',
    url: 'https://www.recaptcha.net/recaptcha/api/siteverify',
    qs: {
      secret: '',
      response: recaptchaResponse,
      remoteip: remoteAddress
    }
  }, function (error, response, body) {
    if (!error && response.statusCode === 200 && body.success) {
      callback(callbackState)
    }
  })
}

const loginProc = function ({originalRequest, originalResponse}) {
  request({
    agent: new Proxy('http://127.0.0.1:8888'),
    method: 'POST',
    url: url.resolve(proxyurl, '/api/auth/login'),
    json: originalRequest.body
  }, function (error, response, body) {
    delete response.headers['server']

    if (!error && response.statusCode === 200) {
      if (body.access_token.length === 0) {
        originalRequest.session.checkForBots = true
        originalResponse.json({succeeded: true, message: '登录失败。'})
        return
      }
      originalRequest.session.checkForBots = false
      originalRequest.session.access_token = body.access_token
      originalRequest.session.token_expires_on = body.expires_on
      // console.log(originalRequest.session);
      originalResponse.json({succeeded: true, message: '登录成功。'})
    } else {
      response.pipe(originalResponse)
    }
  })
}

router.post('/auth/login', function (req, res, next) {
  if (req.session.checkForBots && req.session.checkForBots === true) {
    checkForBotsProc(req.body.g_recaptcha_response, req.socket.remoteAddress, loginProc, {originalRequest: req, originalResponse: res})
  } else {
    loginProc(req)
  }
})

export default router
