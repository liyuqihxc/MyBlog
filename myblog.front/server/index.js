import express from 'express'
import session from 'express-session'
import bodyParser from 'body-parser'
import { Nuxt, Builder } from 'nuxt'

import api from './api'

const app = express()
const host = process.env.HOST || '127.0.0.1'
const port = process.env.PORT || 3000

app.set('port', port)

// for parsing application/json
app.use(bodyParser.json())

// for parsing application/x-www-form-urlencoded
app.use(bodyParser.urlencoded({ extended: true }))

app.use(session({
  secret: 'jinhe',
  name: 'sid',
  resave: false,
  saveUninitialized: true
}))

// bodyParser 必须在 Routes 之前配置
// Import API Routes
app.use('/api', api)

// Import and Set Nuxt.js options
let config = require('../nuxt.config.js')
config.dev = !(process.env.NODE_ENV === 'production')

// Init Nuxt.js
const nuxt = new Nuxt(config)

// Build only in dev mode
if (config.dev) {
  new Builder(nuxt).build()
}

// Give nuxt middleware to express
app.use(nuxt.render)

// Listen the server
let server = app.listen(app.get('port'), host, function () {
  console.log('Server listening on http://%s:%d', server.address().address, server.address().port) // eslint-disable-line no-console
})
