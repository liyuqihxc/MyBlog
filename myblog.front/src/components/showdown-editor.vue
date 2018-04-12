<template>
  <div class="editor">
    <div class="editor-title">
        <input type="text" v-model="value.title" placeholder="文章标题" autocomplete="off" tabindex="1" spellcheck="false" maxlength="128" />
    </div>
    <div class="editor-toolbar">
      <el-button-group>
        <el-button @click="togglePreview" v-if="!preview"><fa-icon :icon="['far','file-alt']"/>&nbsp;预览</el-button>
        <el-button @click="togglePreview" v-if="preview"><fa-icon :icon="['far','file-alt']"/>&nbsp;编辑</el-button>
        <el-button @click="riseSaveEvent"><fa-icon :icon="['far','save']"/>&nbsp;保存</el-button>
      </el-button-group>
      <el-select v-model="value.category" size="small" placeholder="请选择分类">
        <el-option
          v-for="item in categories"
          :key="item.key"
          :label="item.label"
          :value="item.key">
        </el-option>
      </el-select>
      <el-select multiple filterable remote reserve-keyword :multiple-limit="3" :remote-method="filterTags" v-model="value.tags" size="small" placeholder="请选择标签">
        <el-option
          v-for="item in tags"
          :key="item.key"
          :label="item.label"
          :value="item.key">
        </el-option>
      </el-select>
      <el-button-group>
        <el-button><fa-icon :icon="['far','paper-plane']"/>&nbsp;发布</el-button>
      </el-button-group>
      <el-dropdown style="float:right">
        <el-button>
          &nbsp;&nbsp;帮助&nbsp;&nbsp;<i class="el-icon-arrow-down el-icon--right"></i>
        </el-button>
        <el-dropdown-menu slot="dropdown">
          <el-dropdown-item><fa-icon :icon="['fas','code']"/>&nbsp;Markdown</el-dropdown-item>
          <el-dropdown-item>&nbsp;<fa-icon :icon="['far','lightbulb']"/>&nbsp;&nbsp;LaTeX</el-dropdown-item>
        </el-dropdown-menu>
      </el-dropdown>
    </div>
    <div class="editor-content active" v-show="!preview">
      <pre><span>{{ value.content }}</span><br></pre>
      <textarea v-model="value.content"></textarea>
    </div>
    <div class="previewer" v-if="preview" v-html="previewContent" v-highlight>
    </div>
  </div>
</template>

<script>
import showdown from 'showdown'
import hljs from 'highlight.js'
import 'highlight.js/styles/default.css'
const Converter = new showdown.Converter()

export default {
  props: [
    'tags',
    'categories',
    'value'
  ],
  directives: {
    highlight: {
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
  },
  data () {
    return {
      preview: false
    }
  },
  computed: {
    previewContent: function () {
      return Converter.makeHtml(this.value.content)
    }
  },
  watch: {
    value: {
      handler (New, Old) {
        this.$emit('input', New)
      },
      deep: true
    }
  },
  methods: {
    riseSaveEvent () {
      this.$emit('save', this.value)
    },
    filterTags (query) {
    },
    togglePreview () {
      let _This = this
      _This.preview = !_This.preview
    }
  }
}
</script>

<style lang="scss">
ul div.popper__arrow {
  display: none!important;
}

.previewer {
  pre {
    display: block;
    padding: 9.5px;
    margin: 0 0 10px;
    font-size: 13px;
    line-height: 1.42857143;
    color: #333;
    word-break: break-all;
    word-wrap: break-word;
    background-color: #f5f5f5;
    border: 1px solid #ccc;
    border-radius: 4px;
    code {
      padding: 0;
      font-size: inherit;
      color: inherit;
      white-space: pre-wrap;
      background-color: transparent;
      border-radius: 0;
    }
  }
}
</style>

<style lang="scss" scoped>
input[type=text], textarea {
  font-family: Tahoma For Number,Chinese Quote,-apple-system,BlinkMacSystemFont,Segoe UI,Roboto,PingFang SC,Hiragino Sans GB,Microsoft YaHei,Helvetica Neue,Helvetica,Arial,sans-serif;
}

.editor {
  background-color: #fff;
  display: flex;
  flex-direction: column;
  height: 100%;
  .editor-title {
    padding: 48px 60px 15px;
    border-bottom: 1px solid #e8e8e8;
    input[type=text] {
      font-size: 36px;
      outline: none;
      border: none;
      box-shadow: none;
      display: block;
      width: 100%;
      line-height: 50px;
      color: #262626;
      text-align: center;
      font-weight: 700;
      overflow: visible;
      background-color: #fff
    }
  }
  .editor-toolbar {
    padding: 5px 50px;
    background: transparent;
    border-bottom: 1px solid #e8e8e8;
    .el-button {
      padding: 7px;
    }
  }
  .editor-content, .previewer {
    padding: 5px 15px;
    position: relative;
    bottom: 0;
    height: 100%;
  }
  .editor-content {
    display: flex;
    cursor: text;
    textarea,  pre {
      margin: 0;
      padding: 0;
      outline: 0;
      border: 0;
      padding: 5px;
      background: transparent;
      /* Make the text soft-wrap */
      white-space: pre-wrap;
      word-wrap: break-word;
    }
    &.active {
      textarea {
        /* Hide any scrollbars */
        overflow: hidden;
        position: absolute;
        top: 0;
        left: 0;
        height: 100%;
        /* Remove WebKit user-resize widget */
        resize: none;
        overflow-y: scroll;
      }
      pre {
        display: block;
        /* Hide the text; just using it for sizing */
        visibility: hidden;
        overflow: hidden;
      }
    }
    pre {
      display: none;
    }
    textarea {
      /* The border-box box model is used to allow
      * padding whilst still keeping the overall width
      * at exactly that of the containing element. */
      -webkit-box-sizing: border-box;
      -moz-box-sizing: border-box;
      -ms-box-sizing: border-box;
      box-sizing: border-box;
      width: 100%;
      /* This height is used when JS is disabled */
      height: 100px;
    }
  }
  .previewer {
    overflow-x: hidden;
    overflow-y: scroll;
  }
}
</style>
