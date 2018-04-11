<template>
  <div class="article-list">
    <div class="post" v-for="(article,ia) in articles" :key="ia">
      <h1><router-link :to="{path:'/post',query:{postid:article.id}}">{{ article.title }}</router-link></h1>
      <p class="post-date">{{ article.createDate }}&nbsp;-&nbsp;{{ article.announcer }}</p>
      <div class="tags">
        <fa-icon :icon="['fas','tags']"></fa-icon>
        <router-link v-for="(tag,it) in article.tags" :key="it" :to="{path:'/'}">
          <span class="tag padded-sm img-rounded margin-sm-right">{{ tag }}</span>
        </router-link>
      </div>
      <div class="clearfix">
        <img src="" class="pull-left margin-right">
        <div> {{ convertMakrdown(article.content) }}</div>
      </div>
      <div class="continue-reading clearfix">
        <el-button class="pull-right" type="primary"><router-link :to="{path:'/post',query:{postid:article.id}}" style="color:write;">Read More</router-link></el-button>
      </div>
    </div>
  </div>
</template>

<script>
import showdown from 'showdown'
const Converter = new showdown.Converter()

export default {
  props: [
    'articles',
    'loading',
    'totalPage'
  ],
  methods: {
    convertMakrdown (str) {
      return Converter.makeHtml(str).replace(/<[^>]+>/g, '')
    }
  }
}
</script>
