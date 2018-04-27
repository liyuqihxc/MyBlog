import axios from 'axios'

let handleHttpError = function (error) {
  let httpStatusCode = error.response.status
  let msg = error.response.data

  switch (httpStatusCode) {
    case 500:
      global.eventBus.$emit('notify', {
        title: 'HTTP 接口错误(500)',
        message: msg,
        type: 'error'
      })
      break
    case 404:
      global.eventBus.$emit('notify', {
        title: '请求的资源不存在(404)',
        message: msg,
        type: 'error'
      })
      break
    case 400:
      global.eventBus.$emit('notify', {
        title: '请求无效(400)',
        message: msg,
        type: 'error'
      })
      break
  }
  throw error
}

export default {
  async fetch (url, config) {
    try {
      let result = await axios.get(url, config)
      return result.data
    } catch (error) {
      handleHttpError(error)
    }
  },
  async put (url, data, config) {
    try {
      let result = await axios.put(url, data, config)
      return result.data
    } catch (error) {
      handleHttpError(error)
    }
  },
  async post (url, data, config) {
    try {
      let result = await axios.post(url, data, config)
      return result.data
    } catch (error) {
      handleHttpError(error)
    }
  },
  async delete (url, config) {
    try {
      let result = await axios.delete(url, config)
      return result.data
    } catch (error) {
      handleHttpError(error)
    }
  }
}
