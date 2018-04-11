using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlog.App;
using MyBlog.DataAccess.Models;
using MyBlog.ViewModels;

namespace MyBlog.Controllers
{
    [Route("api/[controller]"), AllowAnonymous]
    public class ArticlesController
    {
        private ArticlesApp _ArticlesApp { get; }

        public ArticlesController(ArticlesApp articlesApp)
        {
            _ArticlesApp = articlesApp;
        }

        [HttpGet, Route("list")]
        public Task<PagingVM<IEnumerable<ArticlePreviewVM>>> PreviewAllArticles(int page, int count)
        {
            return _ArticlesApp.PreviewAllArticles(page, count);
        }

        [HttpGet, Route("previewbycat")]
        public Task<PagingVM<IEnumerable<ArticlePreviewVM>>> PreviewArticlesByCategory(string category, int page, int count)
        {
            throw new NotImplementedException();
        }

        [HttpGet, Route("previewbytag")]
        public Task<PagingVM<IEnumerable<ArticlePreviewVM>>> PreviewArticlesByTag(string tag, int page, int count)
        {
            throw new NotImplementedException();
        }

        [HttpGet, Route("allcategories")]
        public Task<IEnumerable<CategoryModel>> GetAllCategories() => _ArticlesApp.GetAllCategories();

        [HttpGet, Route("alltags")]
        public Task<IEnumerable<TagModel>> GetAllTags() => _ArticlesApp.GetAllTags();
    }
}
