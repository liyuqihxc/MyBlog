using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlog.App;
using MyBlog.Domain.Entities;
using MyBlog.Models;
using Newtonsoft.Json.Linq;

namespace MyBlog.Controllers
{
    [Route("api/[controller]"), AllowAnonymous]
    public class ArticlesController : Controller
    {
        private ArticlesApp _ArticlesApp { get; }

        public ArticlesController(ArticlesApp articlesApp)
        {
            _ArticlesApp = articlesApp;
        }

        [HttpGet, Route("list")]
        public Task<PagingModel<IEnumerable<ArticleModel>>> PreviewAllArticles(int page, int count)
        {
            return _ArticlesApp.PreviewAllArticles(page, count);
        }

        [HttpGet, Route("previewbycat")]
        public Task<PagingModel<IEnumerable<ArticleModel>>> PreviewArticlesByCategory(string category, int page, int count)
        {
            throw new NotImplementedException();
        }

        [HttpGet, Route("previewbytag")]
        public Task<PagingModel<IEnumerable<ArticleModel>>> PreviewArticlesByTag(string tag, int page, int count)
        {
            throw new NotImplementedException();
        }

        [HttpGet, Route("allcategories")]
        public Task<IEnumerable<CategoryEntity>> GetAllCategories() => _ArticlesApp.GetAllCategories();

        [HttpGet, Route("alltags")]
        public Task<IEnumerable<TagEntity>> GetAllTags() => _ArticlesApp.GetAllTags();

        //[Authorize]
        [HttpPost, Route("addnew")]
        public async Task<IActionResult> SaveNewPost([FromBody]dynamic Params)
        {
            //string UserName = User.Claims.First(claim => claim.Type == JwtRegisteredClaimNames.Sub).Value;
            string title = (string)Params.title;
            int[] tags = ((JArray)Params.tags).ToObject<int[]>();
            int category = (int)Params.category;
            string content = (string)Params.content;
            await _ArticlesApp.AddNewArticle(title, category, tags, content, "admin");
            return Ok("保存成功。");
        }

        [HttpGet, Route("loadarticle")]
        public Task<ArticleModel> LoadArticle(int id)
        {
            return _ArticlesApp.LoadArticle(id);
        }
    }
}
