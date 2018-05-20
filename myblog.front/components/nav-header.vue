<template>
  <div class="navbar">
    <el-row>
      <el-col :md="{span:15,offset:4}" :sm="24">
        <div style="display:inline; float:left">
          <img src="/img/avatar.jpg" class="avatar" />
          <span class="site-desc">
            <h1>石榴骑士的小站</h1>
            <h2>面向工资编程</h2>
          </span>
        </div>
        <el-menu style="border:0; float:right" mode="horizontal" background-color="#383F42" text-color="#fff" active-text-color="#ffd04b">
          <el-menu-item index="1">
            <nuxt-link to="/posts">博客</nuxt-link>
          </el-menu-item>
          <el-submenu index="2">
            <template slot="title">文章分类</template>
            <nuxt-link :to="{path: cat.url}" v-for="(cat, index) in categories" :key="index">
              <el-menu-item :index="'2-' + index">{{ cat.label }}</el-menu-item>
            </nuxt-link>
          </el-submenu>
          <el-menu-item index="3">
            <a href="mailto:liyuqihxc@gmail.com" title="Email我"><fa-icon :icon="['fas','envelope']" size="lg"/></a>
          </el-menu-item>
          <el-menu-item index="4">
            <a href="https://github.com/liyuqihxc" title="关注GitHub" target="_blank"><fa-icon :icon="['fab','github']" size="lg"/></a>
          </el-menu-item>
        </el-menu>
      </el-col>
    </el-row>
  </div>
</template>

<script>
export default {
  props: {
    categories: {
      type: Array,
      default () {
        return []
      }
    }
  }
}
</script>

<style lang="scss" scoped>
.navbar {
  height: 60px;
  border-bottom: 6px solid #3080B0;
  background-color: #383F42;

  .avatar {
    height: 60px;
    vertical-align: top;
    display: inline-block;
  }

  .site-desc {
    display: inline-block;

    > h1 {
      font-size: 16px;
      font-weight: 500;
      padding: 0;
      margin: 6px 0;
      color: #FFF;
    }

    > h2 {
      font-size: 15px;
      font-weight: 500;
      font-style: italic;
      padding: 0;
      margin: 1px 0;
      color: #FFF;
    }
  }

  .el-menu {
    .el-menu-item {
      &:hover {
        color: rgb(255, 208, 75) !important;
        border-bottom-color: rgb(255, 208, 75) !important;
        background-color: rgb(56, 63, 66) !important;
      }

      &:focus:not(:hover), &.is-active:not(:hover) {
        color: rgb(255, 255, 255) !important;
        border-bottom-color: transparent !important;
        background-color: rgb(56, 63, 66) !important;
      }
    }
  }
}
</style>

<style lang="scss">
.navbar {
  .el-submenu {
    .el-submenu__title {
      color: rgb(255, 255, 255) !important;
      border-bottom-color: transparent !important;
      background-color: rgb(56, 63, 66) !important;
    }
  }
}
</style>
