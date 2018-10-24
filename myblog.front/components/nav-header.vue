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
          <slot name="menu"></slot>
        </el-menu>
      </el-col>
    </el-row>
  </div>
</template>

<script>
export default {
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

<style lang="scss">
.navbar {
  .el-submenu {
    .el-submenu__title {
      color: white !important;
      border-bottom-color: transparent !important;
      background-color: #383F42 !important;
    }
  }
}
</style>
