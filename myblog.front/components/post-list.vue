<template>
  <div class="article-list">
    <div class="post" v-for="(article,ia) in articles" :key="ia">
      <h1><router-link :to="{path:`/posts/viewpost/${article.id}`}">{{ article.title }}</router-link></h1>
      <p class="post-date">{{ article.createDate }}&nbsp;-&nbsp;{{ article.announcer }}</p>
      <div class="tags">
        <fa-icon :icon="['fas','tags']"></fa-icon>
        <!-- <router-link v-for="tag in article.tags" :key="tag" :to="{path:`/posts?tags=/${tags.find(e => e.key === tag)['label']}`}">
          <span class="tag padded-sm img-rounded margin-sm-right">{{ tags.find(e => e.key === tag)['label'] }}</span>
        </router-link> -->
      </div>
      <div class="clearfix">
        <img :src="'/api/attachments/images?id='.concat(article.coverImageID)" class="pull-left margin-right" />
        <div> {{ convertMakrdown(article.content) }}</div>
      </div>
      <div class="continue-reading clearfix">
        <router-link class="pull-right el-button el-button--primary" :to="{path:'/post',query:{postid:article.id}}" tag="button">Read More</router-link>
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
    'totalPage',
    'tags'
  ],
  // created () {
  //   console.log('created')
  //   console.log(this.tags)
  //   console.log(this.articles)
  //   console.log(this.loading)
  // },
  mounted () {
    console.log('post-list.mounted')
    console.log(this.tags)
    console.log(this.articles)
    console.log(this.loading)
  },
  methods: {
    convertMakrdown (str) {
      return Converter.makeHtml(str).replace(/<[^>]+>/g, '')
    }
  }
}
</script>
