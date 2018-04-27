<template>
  <el-row>
    <el-col :lg="16" :md="24" style="padding:5px">
      <router-view></router-view>
    </el-col>
    <el-col :lg="8" class="hidden-md-and-down">
      <side-nav />
    </el-col>
  </el-row>
</template>

<script>
import sidenav from '@/components/side-nav'
import 'element-ui/lib/theme-chalk/display.css'

export default {
  components: {
    'side-nav': sidenav
  }
}
</script>
