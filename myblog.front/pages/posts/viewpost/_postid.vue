<template>
  <el-row>
    <el-col :lg="16" :md="24" style="padding:5px">
      <div style="padding: 15px">
        <h1 class="article-title">{{ article.title }}</h1>
        <div class="tags">
          <span class="post-date">{{ article.createDate }} | {{ article.announcer }}&nbsp;&nbsp;</span>
          <fa-icon :icon="['fas','tags']" class="icon-tag"></fa-icon>
          <nuxt-link v-for="tag in article.tags" :key="tag" :to="{path:`/posts?tag=${allTags.find(e => e.key === tag)['label']}`}">
            <span class="tag padded-sm img-rounded margin-sm-right">{{ allTags.find(e => e.key === tag)['label'] }}</span>
          </nuxt-link>
        </div>
        <article class="article" v-if="article.content" v-html="htmlContent" v-highlight></article>
        <div class="well clearfix">
          <div class="share pull-left">
            <span>分享：</span>
            <el-tooltip content="分享至新浪微博" placement="top">
              <el-button class="share-button"><fa-icon :icon="['fab','weibo']" class="icon-tag"></fa-icon></el-button>
            </el-tooltip>
            <el-tooltip content="分享至微信" placement="top">
              <el-button class="share-button"><fa-icon :icon="['fab','weixin']" class="icon-tag"></fa-icon></el-button>
            </el-tooltip>
          </div>
          <p class="pull-right no-margin">Posted @ {{ article.createDate }} by {{ article.announcer }}</p>
        </div>
      </div>
    </el-col>
    <el-col :lg="8" class="hidden-md-and-down">
      <side-nav :categories="allCategories" />
    </el-col>
  </el-row>
</template>

<script>
import showdown from 'showdown'
import 'highlight.js/styles/default.css'
import { mapState } from 'vuex'

import sidenav from '@/components/side-nav'
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
  components: {
    'side-nav': sidenav
  },
  computed: {
    ...mapState({
      allTags: state => state.articles.allTags,
      allCategories: state => state.articles.allCategories
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

.navbar{
	#photograph-small{
		height: 50px;
		vertical-align: top;
	}
}

.share {
	.share-button {
		display: inline-block;
		// margin-right: 10px;
		vertical-align: middle;
		font-size: 25px;
		border: 0;
    padding: 0;
    background: transparent;

    &:hover {
      color: #4DC7B2;
    }

    &:focus:not(:hover) {
      color: #606266;
    }
	}
}
</style>
