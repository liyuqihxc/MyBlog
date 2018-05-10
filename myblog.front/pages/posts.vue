<template>
  <el-row type="flex" justify="center" style="min-height:100%">
    <el-col class="main" :md="15" :sm="24">
      <nuxt-child/>
    </el-col>
  </el-row>
</template>

<script>
export default {
  data () {
    return {
    }
  }
}
</script>
