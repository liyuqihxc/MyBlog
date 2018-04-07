<template>
  <div class="editor">
      <div class="editor-title">
          <input type="text" :value="article.title" placeholder="文章标题" autocomplete="off" tabindex="1" spellcheck="false" maxlength="128" />
      </div>
      <!--<div class="editor-toolbar">
        <div class="toolbar-item">
          <el-dropdown trigger="click">
            <el-button size="mini" type="text">文件</el-button>
            <el-dropdown-menu slot="dropdown">
            </el-dropdown-menu>
          </el-dropdown>
        </div>
      </div>-->
      <div class="editor-content">
        <div class="textarea-wrapper">
          <div class="content-editable" contenteditable="true">{{deliveryLocation}}</div>
          <textarea v-model="deliveryLocation" @change="trimSpacesAndUppercase($event, 'deliveryLocation')" class="field-textarea" placeholder="请输入详细地址"></textarea>
        </div>
        <textarea :value="article.content"></textarea>
      </div>
  </div>
</template>

<script>
export default {
  data () {
    return {
      article: {
        title: '',
        content: ''
      }
    }
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
    height: 30px;
    .toolbar-item {
      //position: relative;
      display: inline-block;
      font-size: 14px;
      line-height: 18px;
      padding: 0 10px;
      text-align: center;
      border: 1px solid transparent;
      background: #fff;
      cursor: pointer;
      border-radius: 4px 4px;
      margin-right: 4px;
      &:hover {
        border: 1px solid transparent;
        background: #f5f5f5;
      }
    }
  }
  .editor-content {
    padding: 5px 15px;
    textarea {
      resize: none;
      width: 100%;
      border: none;
      padding: 0;
      font-size: 19px;
      font-weight: normal;
      &:focus {
        border: none;
        outline: none;
      }
    }
  }
}
</style>
