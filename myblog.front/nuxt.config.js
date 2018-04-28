module.exports = {
  /*
  ** Headers of the page
  */
  head: {
    title: 'starter',
    meta: [
      { charset: 'utf-8' },
      { name: 'viewport', content: 'width=device-width, initial-scale=1' },
      { hid: 'description', name: 'description', content: 'Nuxt.js project' },
      { 'http-equiv': 'X-UA-Compatible', content: 'IE=edge,chrome=1' }
    ],
    link: [
      { rel: 'icon', type: 'image/x-icon', href: '/favicon.ico' }
    ]
  },
  css: [
    // '~/assets/css/main.css',
    'element-ui/lib/theme-chalk/display.css',
    { src: '~assets/scss/site.scss', lang: 'scss' }
  ],
  router: {
    extendRoutes (routes) {
      routes.push({
        path: '/',
        redirect: '/posts',
        component: require('path').resolve('pages/index.vue')
      })
    }
  },
  loading: {
    color: 'cyan',
    height: '4px'
  },
  plugins: [
    '~/plugins/event-bus.js',
    '~/plugins/element-ui.js',
    '~/plugins/fontawesome.js'
  ],
  build: {
    vendor: [
      'axios',
      'element-ui',
      'showdown',
      'highlight.js',
      '@fortawesome/fontawesome',
      '@fortawesome/vue-fontawesome',
      '@fortawesome/fontawesome-free-solid',
      '@fortawesome/fontawesome-free-regular',
      '@fortawesome/fontawesome-free-brands'
    ],
    /*
    ** Run ESLINT on save
    */
    extend (config, ctx) {
      if (ctx.isClient) {
        config.module.rules.push({
          enforce: 'pre',
          test: /\.(js|vue)$/,
          loader: 'eslint-loader',
          exclude: /(node_modules)/
        })
      }
    }
  }
}
