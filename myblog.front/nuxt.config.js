module.exports = {
  // https://github.com/justyeh/justyeh.com
  head: {
    titleTemplate: '%s - 石榴骑士的小站',
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
    'element-ui/lib/theme-chalk/index.css',
    { src: '~assets/scss/site.scss', lang: 'scss' }
  ],
  loading: {
    color: 'cyan',
    height: '3px'
  },
  env: {
    proxyUrl: process.env.PROXY_URL || 'http://127.0.0.1:18089'
  },
  plugins: [
    { src: '~/plugins/directives.js', ssr: false },
    { src: '~/plugins/axios.js', ssr: true },
    { src: '~/plugins/event-bus.js', ssr: false },
    { src: '~/plugins/element-ui.js', ssr: true },
    { src: '~/plugins/fontawesome.js', ssr: false }
  ],
  build: {
    analyze: true,
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
