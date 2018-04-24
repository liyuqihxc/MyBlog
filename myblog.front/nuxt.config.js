module.exports = {
  /*
  ** Headers of the page
  */
  head: {
    title: 'myblog.front',
    meta: [
      { charset: 'utf-8' },
      { name: 'viewport', content: 'width=device-width, initial-scale=1' },
      { hid: 'description', name: 'description', content: 'Nuxt.js project' }
    ],
    link: [
      { rel: 'icon', type: 'image/x-icon', href: '/favicon.ico' }
    ]
  },
  css: [
    'element-ui/lib/theme-chalk/index.css'
  ],
  /*
  ** Customize the progress bar color
  */
  loading: { color: '#3B8070' },
  plugins: [
    '@/plugins/dependencies',
    '@/plugins/event-bus'
  ],
  /*
  ** Build configuration
  */
  build: {
    vendor: [
      'axios', 'showdown', 'highlight.js', 'element-ui',
      '@fortawesome/vue-fontawesome',
      '@fortawesome/fontawesome-free-solid',
      '@fortawesome/fontawesome-free-regular',
      '@fortawesome/fontawesome-free-brands',
      '@fortawesome/fontawesome'
    ],
    /*
    ** Run ESLint on save
    */
    extend (config, { isDev, isClient }) {
      if (isDev && isClient) {
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
