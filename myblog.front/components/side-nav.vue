<template>
  <div class="sidebar-nav">
    <h2>博客</h2>
    <ul class="list-unstyled"><li><h3><nuxt-link to="/posts">最近文章</nuxt-link></h3></li></ul>
    <h2>所有分类</h2>
    <ul class="list-unstyled">
      <li v-for="cat in categories" :key="cat.key">
        <h3><a href="javascript:void(0)">{{ cat.label }}</a></h3>
      </li>
      <li>
        <h3><a href="javascript:void(0)">所有草稿</a></h3>
      </li>
      <li>
        <h3><a href="javascript:void(0)">回收站</a></h3>
      </li>
    </ul>
    <h2>相关博文</h2>
    <div style="margin-bottom: 5px; padding-bottom: 10px; border-bottom: 1px solid #C5DAE8;">
        <i class="fa fa-tag"></i>
        <nuxt-link to="/"><span class="tag padded-sm img-rounded margin-sm-right">GitHub</span></nuxt-link>
    </div>
    <div class="clearfix">
      <h3>
          <nuxt-link to="/">借助GitHub Pages配合Jekyll构建个人博客站点</nuxt-link>
      </h3>
      <img src="/img/2015-04-22-Github_feature.webp" class="feature-image-small pull-left">
      <div>
          Quick Setup Jekyll是基于Ruby的工具，首先需要安装Ruby，Ruby的官方网站可以下载。安装好后会自动弹出命令提示符窗口询问是否安装msys2，因为后面需要用 gem 安装Jekyll，所以这里选择安装 msys2 和 MinGW dev toolchain。之后是gem，gem可以在(rubygems.org)[https://rubygems.org/pages/download]下载，安装完后重新打开命令提示符，用 gem install 命令安装以下几个gem包：
      </div>
    </div>
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
