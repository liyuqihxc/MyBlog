<template>
  <div class="sidebar-nav">
    <h2>博客</h2>
    <ul class="list-unstyled">
      <li><h3><nuxt-link to="/posts">最近文章</nuxt-link></h3></li>
      <slot name="custom_link"></slot>
    </ul>
    <h2>所有分类</h2>
    <slot name="categories"></slot>
    <slot name="content_title"><h2>相关博文</h2></slot>
    <slot></slot>
  </div>
</template>

<script>
export default {
  props: {
    related_posts: {
      type: Array,
      default () {
        return []
      }
    },
    categories: {
      type: Array,
      default () {
        return []
      }
    }
  },
  data () {
    return {
      msg: ''
    }
  }
}
</script>

<style lang="scss" scoped>
.sidebar-nav {
    height: 100%;
    padding: 10px;
    .feature-image-small{
        max-width: 100px;
        max-height: 100px;
        margin: 5px 10px 5px 0;
    }
    h2, h3, h4 {
        font-weight: 500;
        line-height: 1.1;
    }
    h2{
        font-size: 2em;
        margin-top: 20px;
        margin-bottom: 10px;
    }
    h3{
        font-size: 1.15em;
        margin: 5px 0;
        padding: 0 0 0 6px;
    }
    h4{
        font-size: 1.2em;
    }
}
</style>
