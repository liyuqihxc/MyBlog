import Vue from 'vue'
import eui from 'element-ui'
import euilocal from 'element-ui/lib/locale/lang/zh-CN'

export default () => {
  Vue.use(eui, { euilocal })
}
