import { Router } from 'express'
import request from 'request'
// import Proxy from 'http-proxy-agent'
import url from 'url'

const router = Router()
const proxyurl = process.env.PROXY_URL

const checkForBotsProc = function (recaptchaResponse, remoteAddress, callback, callbackState) {
  request({
    method: 'POST',
    url: 'https://www.recaptcha.net/recaptcha/api/siteverify',
    qs: {
      secret: '6LeIxAcTAAAAAGG-vFI1TnRWxMZNFuojJ4WifJWe',
      response: recaptchaResponse,
      remoteip: remoteAddress
    }
  }, function (error, response, body) {
    if (!error && response.statusCode === 200) {
      var ret = JSON.parse(body)
      // console.log(body)
      if (ret.success !== true) {
        callbackState.originalResponse.json({ succeeded: false, message: '登录失败，reCAPTCHA验证失败。' })
        return
      }
      callback(callbackState)
    }
  })
}

const loginProc = function ({originalRequest, originalResponse}) {
  request({
    // agent: new Proxy('http://127.0.0.1:8888'),
    method: 'POST',
    url: url.resolve(proxyurl, '/api/auth/login'),
    json: originalRequest.body
  }, function (error, response, body) {
    if (error && error.code === 'ECONNREFUSED') {
      console.error('无法连接到后端服务，请检查后端程序是否启动。')
      originalResponse.statusCode = 503
      originalResponse.json({message: 'Service Unabailable.', data: null})
      originalResponse.end()
      return
    }

    if (response.statusCode === 401) {
      originalRequest.session.checkForBots = true
      response.pipe(originalResponse)
      return
    }

    if (!error && response.statusCode === 200) {
      delete response.headers['server']

      originalRequest.session.checkForBots = false
      originalRequest.session.access_token = body.access_token
      originalRequest.session.token_expires_on = body.expires_on
      originalRequest.session.user_nick_name = body.nick_name
      // console.log(originalRequest.session);
      originalResponse.json({ succeeded: true, message: '登录成功。', nick_name: body.nick_name })
    } else {
      response.pipe(originalResponse)
    }
  })
}

router.post('/auth/login', function (req, res, next) {
  if (req.session.checkForBots && req.session.checkForBots === true) {
    checkForBotsProc(req.body.g_recaptcha_response, req.socket.remoteAddress, loginProc, {originalRequest: req, originalResponse: res})
  } else {
    loginProc({originalRequest: req, originalResponse: res})
  }
})

export default router
