<template>
  <article class="">
  </article>
</template>

<script>
import showdown from 'showdown'
import hljs from 'highlight.js'
import * as muta from '@/store/mutation-types'
import 'highlight.js/styles/default.css'
const Converter = new showdown.Converter()

export default {
  data () {
    return {
      article: {
        title: '',
        content: '',
        announcer: '',
        tags: [],
        category: '',
        coverImageID: '',
        createDate: ''
      }
    }
  },
  mounted () {
    this.$store.dispatch(muta.AC_ARTICLES_LOAD_ARTICLE, this.$route.params.id).then(function (article123) {
      console.log(article123)
    })
  }
}
</script>
