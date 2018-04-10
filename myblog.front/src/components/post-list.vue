<template>
  <div class="article-list">
    <!-- eslint-disable-next-line -->
    <div class="post" v-for="article in props.articles">
      <h1><router-link to="{path:'/post',query:{postid:article.id}}"></router-link></h1>
      <p class="post-date">{{ article.createdate }}&nbsp;-&nbsp;{{ article.Announcer }}</p>
      <div class="tags">
        <fa-icon :icon="['fas','tags']"></fa-icon>
        <!-- eslint-disable-next-line -->
        <router-link v-for="tag in article.tags">
          <span class="tag padded-sm img-rounded margin-sm-right">{{ tag }}</span>
        </router-link>
	    </div>
      <div class="clearfix">
        <img src="" class="pull-left margin-right">
        <div v-html="convertMakrdown(article.content)"></div>
      </div>
      <div class="continue-reading clearfix pull-right">
        <el-button type="primary"><router-link to="{path:'/post',query:{postid:article.id}}" style="color:write;">Read More</router-link></el-button>
      </div>
    </div>
  </div>
</template>

<script>
import showdown from 'showdown'

export default {
  props: [
    'articles',
  ],
  methods: {
    convertMakrdown (str) {
      return str
    }
  }
}
</script>
