<template>
  <div class="editor">
      <div class="editor-title">
          <input type="text" v-model="title" placeholder="文章标题" autocomplete="off" tabindex="1" spellcheck="false" maxlength="128" />
      </div>
      <div class="editor-toolbar">
        <el-button-group>
          <el-button>预览</el-button>
          <el-button>保存</el-button>
        </el-button-group>
      </div>
      <div class="editor-content active">
        <pre><span>{{ content }}</span><br></pre>
        <textarea v-model="content"></textarea>
      </div>
  </div>
</template>

<script>
export default {
  data () {
    return {
      title: '',
      content: ''
    }
  },
  watch: {
    content: function () {
      return this.content
    }
  },
  mounted () {
  }
}
</script>

<style>
ul div.popper__arrow {
  display: none!important;
}
</style>

<style lang="scss" scoped>
input[type=text], textarea {
  font-family: Tahoma For Number,Chinese Quote,-apple-system,BlinkMacSystemFont,Segoe UI,Roboto,PingFang SC,Hiragino Sans GB,Microsoft YaHei,Helvetica Neue,Helvetica,Arial,sans-serif;
}

.editor {
  background-color: #fff;
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
    padding: 5px 20px 0;
    background: transparent;
    z-index: 200;
  }
  .editor-content {
    padding: 5px 15px;
    position: relative;
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
      }
      pre {
        display: block;
        /* Hide the text; just using it for sizing */
        visibility: hidden;
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
}
</style>
