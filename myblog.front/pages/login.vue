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
        <div id="recaptcha" class="g-recaptcha" data-sitekey="6Lc5DlMUAAAAAEpS3STxlbnjO4kJvFVWQ2QZDGi3" v-if="checkForBots"></div>
        <el-form-item style="width:100%;">
          <el-button type="primary" style="width:100%;" @click.native.prevent="handleSubmit2" :loading="logining">登录</el-button>
          <!--<el-button @click.native.prevent="handleReset2">重置</el-button>-->
        </el-form-item>
      </el-form>
      <remote-js src="https://www.recaptcha.net/recaptcha/api.js"></remote-js>
  </el-container>
</template>

<script>
import SiteFooter from '@/components/site-footer'
import { mapState } from 'vuex'
import * as muta from '@/store/mutation-types'

export default {
  head: {
    title: '博主登录'
  },
  data () {
    return {
      logining: false,
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
  beforeRouteUpdate (to, from, next) {
    // react to route changes...
    next()
  },
  components: {
    'site-footer': SiteFooter,
    'remote-js': {
      render (createElement) {
        return createElement('script', {attrs: { type: 'text/javascript', src: this.src, async: 'async', defer: 'defer' }})
      }
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
          let loginParams = {
            username: _This.ruleForm2.account,
            password: _This.ruleForm2.checkPass,
            g_recaptcha_response: _This.widgetId ? window.grecaptcha.getResponse(_This.widgetId) : ''
          }
          _This.$store.dispatch(muta.AC_LOGIN, loginParams).then(function () {
            _This.logining = false
            if (_This.logined) {
              _This.$router.push({path: '/'})
            } else if (_This.checkForBots && window.grecaptcha) {
              _This.widgetId = window.grecaptcha.render('recaptcha', {
                'sitekey': '6Lc5DlMUAAAAAEpS3STxlbnjO4kJvFVWQ2QZDGi3'
              })
            }
          })
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
