<script>
// 首页为 /posts 因此这里直接redirect，调试中发现如果用vue-router的beforeRouteEnter事件来跳转
// 会导致跳转后的页面 asyncData 里的数据无法传到页面里面，所以这里用 middleware 执行跳转
export default {
  middleware ({ store, redirect }) {
    return redirect('/posts')
  }
}
</script>