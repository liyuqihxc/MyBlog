<template>
  <div style="padding: 15px">
    <h1 class="article-title">{{ article.title }}</h1>
    <div class="tags">
      <span class="post-date">{{ article.createDate }} | {{ article.announcer }}&nbsp;&nbsp;</span>
      <fa-icon :icon="['fas','tags']" class="icon-tag"></fa-icon>
      <router-link v-for="tag in article.tags" :key="tag" :to="{path:`/posts?tag=${allTags.find(e => e.key === tag)['label']}`}">
        <span class="tag padded-sm img-rounded margin-sm-right">{{ allTags.find(e => e.key === tag)['label'] }}</span>
      </router-link>
    </div>
    <article class="article" v-if="article.content" v-html="htmlContent" v-highlight></article>
  </div>
</template>

<script>
import showdown from 'showdown'
import 'highlight.js/styles/default.css'
import { mapState } from 'vuex'

import { articles as articlesApi } from '@/api'
import '@/assets/scss/article.scss'
const Converter = new showdown.Converter()

export default {
  head () {
    return {
      title: this.article.title
    }
  },
  async asyncData ({ route }) {
    let article = await articlesApi.loadArticle(route.params.postid)
    return { article }
  },
  computed: {
    ...mapState({
      allTags: state => state.articles.allTags
    }),
    htmlContent () {
      return Converter.makeHtml(this.article.content)
    }
  },
  mounted () {

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

  .icon-tag {
    margin: 0 0.5em
  }
}

</style>
