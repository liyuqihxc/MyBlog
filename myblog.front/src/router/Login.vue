<template>
  <el-container>
    <el-main>
      <div>Login</div>
    </el-main>
    <el-footer class="no-padding">
      <site-footer />
    </el-footer>
  </el-container>
</template>

<script>
import SiteFooter from '../components/site-footer'

export default {
  name: '',
  components: {
    'site-footer': SiteFooter
  }
}
</script>
