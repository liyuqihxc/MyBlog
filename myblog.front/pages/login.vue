<template>
  <el-container>
      <el-form :model="ruleForm2" :rules="rules2" ref="ruleForm2" label-position="left" label-width="0px" class="demo-ruleForm login-container">
        <h3 class="title">博主登录</h3>
        <el-form-item prop="account">
          <el-input type="text" v-model="ruleForm2.account" auto-complete="off" placeholder="账号"></el-input>
        </el-form-item>
        <el-form-item prop="checkPass">
          <el-input type="password" v-model="ruleForm2.checkPass" auto-complete="off" placeholder="密码"></el-input>
        </el-form-item>
        <div id="recaptcha" class="g-recaptcha" :data-sitekey="RecaptchaSitekey" v-if="checkForBots"></div>
        <el-form-item style="width:100%;">
          <el-button type="primary" style="width:100%;" @click.native.prevent="handleSubmit2" :loading="logining">登录</el-button>
          <!--<el-button @click.native.prevent="handleReset2">重置</el-button>-->
        </el-form-item>
      </el-form>
      <!-- <remote-js src="https://www.recaptcha.net/recaptcha/api.js"></remote-js> -->
  </el-container>
</template>

<script>
import SiteFooter from '@/components/site-footer'
import { mapState } from 'vuex'
import * as muta from '@/store/mutation-types'

const RecaptchaSitekey = '6LeIxAcTAAAAAJcZVRqyHh71UMIEGNQ_MXjiZKhI'

export default {
  head: {
    title: '博主登录'
  },
  data () {
    return {
      logining: false,
      RecaptchaSitekey,
      widgetId: '',
      ruleForm2: {
        account: 'admin',
        checkPass: '963852'
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
  computed: mapState({
    checkForBots: state => state.authentication.checkForBots,
    logined: state => state.authentication.logined
  }),
  middleware ({ store, redirect }) {
    if (store.state.authentication.logined === true) {
      return redirect('/posts')
    }
  },
  components: {
    'site-footer': SiteFooter,
    'remote-js': {
      render (createElement) {
        return createElement('script', {attrs: { type: 'text/javascript', src: this.src, async: 'async', defer: 'defer' }})
      }
    }
  },
  mounted () {
    let _This = this
    if (_This.checkForBots) {
      _This.load_reCAPTCHA()
    }
  },
  beforeDestroy () {
    let script = document.getElementById('recaptchaScript')
    if (script) {
      script.remove()
    }
  },
  methods: {
    handleReset2 () {
      this.$refs.ruleForm2.resetFields()
    },
    handleSubmit2 (ev) {
      let _This = this
      _This.$refs.ruleForm2.validate((valid) => {
        if (valid) {
          _This.logining = true
          let grecaptcha = ''
          if (_This.checkForBots && _This.widgetId !== '') {
            grecaptcha = window.grecaptcha.getResponse()
          }
          let loginParams = {
            username: _This.ruleForm2.account,
            password: _This.ruleForm2.checkPass,
            g_recaptcha_response: grecaptcha
          }
          _This.$store.dispatch(muta.AC_LOGIN, loginParams).then(function () {
            if (_This.logined === true) {
              window.location.reload(true)
            } else if (window.grecaptcha) {
              // js已加载
              window.grecaptcha.reset(_This.widgetId)
            } else {
              // js未加载
              _This.load_reCAPTCHA()
            }
          }).finally(function () {
            _This.logining = false
          })
        } else {
          console.log('error submit!!')
          return false
        }
      })
    },
    load_reCAPTCHA () {
      let script = document.createElement('script')
      script.id = 'recaptchaScript'
      script.defer = true
      script.async = true
      script.src = 'https://www.recaptcha.net/recaptcha/api.js'
      document.head.appendChild(script)
      // _This.widgetId = window.grecaptcha.render('recaptcha', {
      //   'sitekey': RecaptchaSitekey
      // })
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
