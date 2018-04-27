<template>
  <div style="padding: 15px">
    <h1 class="article-title">{{ article.title }}</h1>
    <div class="tags">
      <span class="post-date">{{ article.createDate }} | {{ article.announcer }}&nbsp;&nbsp;</span>
      <fa-icon :icon="['fas','tags']"></fa-icon>
      <router-link v-for="tag in article.tags" :key="tag" :to="{path:`/posts/tags/${allTags.find(e => e.key === tag)['label']}`}">
        <span class="tag padded-sm img-rounded margin-sm-right">{{ allTags.find(e => e.key === tag)['label'] }}</span>
      </router-link>
    </div>
    <article class="article" v-if="article.content" v-html="htmlContent" v-highlight>
    </article>
  </div>
</template>

<script>
import showdown from 'showdown'
import highlight from '@/directives/highlight'
import * as muta from '@/store/mutation-types'
import 'highlight.js/styles/default.css'
import '@/assets/scss/article.scss'
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
      },
      allTags: []
    }
  },
  created () {
    let _This = this
    _This.$store.dispatch(muta.AC_ARTICLES_LOAD_ARTICLE, this.$route.params.postid).then(function (article) {
      _This.article = article
      console.log(article.tags)
    })
    _This.$store.dispatch(muta.AC_ARTICLES_FETCH_ALL_TAGS).then(function (allTags) {
      _This.allTags = allTags
    })
  },
  directives: {
    highlight
  },
  computed: {
    htmlContent () {
      return Converter.makeHtml(this.article.content)
    }
  }
}
</script>

<style lang="scss" scoped>
.article-title {
  padding-bottom: 0.3em;
  margin: 0;
  font-size: 1.8em;
  font-weight: bold;
  border-bottom: 1px solid #C5DAE8;
  line-height: 1.1;
}

.tags {
  margin-bottom: 5px;
  padding: 10px 0;
  border-bottom: 1px solid #C5DAE8;
}

</style>
