import hljs from 'highlight.js'
import Vue from 'vue'

const highlight = {
  deep: true,
  bind: function (el, binding) {
    // on first bind, highlight all targets
    let targets = el.querySelectorAll('pre code')
    targets.forEach((target) => {
      // if a value is directly assigned to the directive, use this
      // instead of the element content.
      if (binding.value) {
        target.textContent = binding.value
      }
      if (target.attributes.length !== 0) {
        hljs.highlightBlock(target)
      }
    })
  },
  componentUpdated: function (el, binding) {
    // after an update, re-fill the content and then highlight
    let targets = el.querySelectorAll('pre code')
    targets.forEach((target) => {
      if (binding.value) {
        target.textContent = binding.value
        if (target.attributes.length !== 0) {
          hljs.highlightBlock(target)
        }
      }
    })
  }
}

export default () => {
  Vue.directive('highlight', highlight)
}
