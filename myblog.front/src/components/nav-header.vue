<template>
  <div class="navbar">
    <el-row>
      <el-col :md="{span:15,offset:4}" :sm="24">
        <div style="display:inline; float:left">
          <img src="/static/img/avatar.jpg" class="avatar" />
          <span class="site-desc">
              <h1>石榴骑士的小站</h1>
              <h2>面向工资编程</h2>
          </span>
        </div>
        <el-menu style="border:0; float:right" mode="horizontal" background-color="#383F42" text-color="#fff" active-text-color="#ffd04b">
        <el-menu-item index="1">
            博客
        </el-menu-item>
        <el-submenu index="2">
            <template slot="title">文章分类</template>
            <!-- eslint-disable-next-line -->
            <el-menu-item :index="'2-' + index" v-for="(m, index) in classes" :key="index" :route="m.url">{{m.name}}</el-menu-item>
        </el-submenu>
        <el-menu-item index="3">
            <a href="mailto:liyuqihxc@gmail.com" title="Email我"><fa-icon :icon="['fas','envelope']" size="lg"/></a>
        </el-menu-item>
        <el-menu-item index="4">
            <a href="https://github.com/liyuqihxc" title="关注GitHub"><fa-icon :icon="['fab','github']" size="lg"/></a>
        </el-menu-item>
        </el-menu>
      </el-col>
    </el-row>
  </div>
</template>

<script>
export default {
  props: {
    classes: {
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
}
</style>
