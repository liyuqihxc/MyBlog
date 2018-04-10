using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlog.App;
using MyBlog.ViewModels;

namespace MyBlog.Controllers
{
    [Route("api/[controller]"), AllowAnonymous]
    public class ArticlesController
    {
        private IMapper _Mapper { get; }
        private ArticlesApp _ArticlesApp { get; }

        public ArticlesController(IMapper mapper)
        {
            _Mapper = mapper;
        }

        public Task<PagingVM<IEnumerable<ArticlePreviewVM>>> PreviewArticles(int page)
        {
            throw new NotImplementedException();
        }

        [Route("previewbycat/{category}/{page}")]
        public Task<PagingVM<IEnumerable<ArticlePreviewVM>>> PreviewArticlesByCategory(string category, int page)
        {
            throw new NotImplementedException();
        }

        [Route("previewbytag")]
        public Task<PagingVM<IEnumerable<ArticlePreviewVM>>> PreviewArticlesByTag(string tag, int page)
        {
            throw new NotImplementedException();
        }
    }
}
