<template>
  <el-container style="height:100%">
    <el-main>
      <el-form :model="ruleForm2" :rules="rules2" ref="ruleForm2" label-position="left" label-width="0px" class="demo-ruleForm login-container">
        <h3 class="title">博主登录</h3>
        <el-form-item prop="account">
          <el-input type="text" v-model="ruleForm2.account" auto-complete="off" placeholder="账号"></el-input>
        </el-form-item>
        <el-form-item prop="checkPass">
          <el-input type="password" v-model="ruleForm2.checkPass" auto-complete="off" placeholder="密码"></el-input>
        </el-form-item>
        <div class="g-recaptcha" data-sitekey="6Lc5DlMUAAAAAEpS3STxlbnjO4kJvFVWQ2QZDGi3" v-if="1===2"></div>
        <el-form-item style="width:100%;">
          <el-button type="primary" style="width:100%;" @click.native.prevent="handleSubmit2" :loading="logining">登录</el-button>
          <!--<el-button @click.native.prevent="handleReset2">重置</el-button>-->
        </el-form-item>
      </el-form>
      <remote-js src="https://www.recaptcha.net/recaptcha/api.js"></remote-js>
    </el-main>
    <el-footer class="no-padding">
      <site-footer />
    </el-footer>
  </el-container>
</template>

<script>
import SiteFooter from '../components/site-footer'

export default {
  data () {
    return {
      logining: false,
      ruleForm2: {
        account: 'admin',
        checkPass: '123456'
      },
      rules2: {
        account: [
          { required: true, message: '请输入账号', trigger: 'blur' }
          // { validator: validaePass }
        ],
        checkPass: [
          { required: true, message: '请输入密码', trigger: 'blur' }
          // { validator: validaePass2 }
        ]
      }
    }
  },
  components: {
    'site-footer': SiteFooter,
    'remote-js': {
      render (createElement) {
        return createElement('script', {attrs: { type: 'text/javascript', src: this.src }})
      }
    }
  },
  methods: {
    handleReset2 () {
      this.$refs.ruleForm2.resetFields()
    },
    handleSubmit2 (ev) {
      this.$refs.ruleForm2.validate((valid) => {
        if (valid) {
          // _this.$router.replace('/table')
          this.logining = true
          // NProgress.start()
          // let loginParams = { username: this.ruleForm2.account, password: this.ruleForm2.checkPass }
        } else {
          console.log('error submit!!')
          return false
        }
      })
    }
  }
}
</script>

<style lang="scss" scoped>
  .login-container {
    /*box-shadow: 0 0px 8px 0 rgba(0, 0, 0, 0.06), 0 1px 0px 0 rgba(0, 0, 0, 0.02);*/
    -webkit-border-radius: 5px;
    border-radius: 5px;
    -moz-border-radius: 5px;
    background-clip: padding-box;
    margin: 180px auto;
    width: 350px;
    padding: 35px 35px 15px 35px;
    background: #fff;
    border: 1px solid #eaeaea;
    box-shadow: 0 0 25px #cac6c6;
    .title {
      margin: 0px auto 40px auto;
      text-align: center;
      color: #505458;
    }
    .g-recaptcha {
      margin-bottom: 22px;
      transform:scale(1.16);
      transform-origin:0 0;
    }
    .remember {
      margin: 0px 0px 35px 0px;
    }
  }
</style>
