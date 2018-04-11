using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MyBlog.Common;
using MyBlog.DataAccess.Models;
using MyBlog.IRepository;
using MyBlog.ViewModels;

namespace MyBlog.App
{
    public class ArticlesApp
    {
        private IMapper _Mapper { get; }
        private IBaseRepository<PostModel> _ArticlesRepository { get; }
        private IBaseRepository<TagModel> _TagsRepository { get; }
        private IBaseRepository<CategoryModel> _CategoriesRepository { get; }

        public ArticlesApp(IMapper mapper, IBaseRepository<PostModel> articlesRepository, IBaseRepository<TagModel> tagsRepository, IBaseRepository<CategoryModel> categoriesRepository)
        {
            _Mapper = mapper;
            _ArticlesRepository = articlesRepository;
            _TagsRepository = tagsRepository;
            _CategoriesRepository = categoriesRepository;
        }

        public Task<PagingVM<IEnumerable<ArticlePreviewVM>>> PreviewAllArticles(int page, int count)
        {
            return Task<PagingVM<IEnumerable<ArticlePreviewVM>>>.Factory.StartNew(() => 
            {
                int total = _ArticlesRepository.Where(p => p.Published).Count();
                var result = _ArticlesRepository.Where(p => p.Published)
                    .OrderByDescending(p => p.CreateDate)
                    .Skip((page - 1) * count)
                    .Take(count)
                    .ToArray();

                return new PagingVM<IEnumerable<ArticlePreviewVM>>
                {
                    TotalPage = (total / count) + (total % count),
                    CurrentPage = page,
                    Data = _Mapper.Map<IEnumerable<ArticlePreviewVM>>(result)
                };
            });
        }

        public Task<IEnumerable<CategoryModel>> GetAllCategories()
        {
            return Task<IEnumerable<CategoryModel>>.Factory.StartNew(() =>
            {
                return _CategoriesRepository.All().ToArray();
            });
        }

        public Task<IEnumerable<TagModel>> GetAllTags()
        {
            return Task<IEnumerable<TagModel>>.Factory.StartNew(() =>
            {
                return _TagsRepository.All().ToArray();
            });
        }
    }
}
