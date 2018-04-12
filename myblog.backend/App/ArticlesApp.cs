using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
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
        private IBaseRepository<PostTagRelationModel> _PostTagRelationsRepository { get; }
        private IBaseRepository<UserModel> _UserRepository { get; }

        public ArticlesApp(
            IMapper mapper,
            IBaseRepository<PostModel> articlesRepository,
            IBaseRepository<TagModel> tagsRepository,
            IBaseRepository<CategoryModel> categoriesRepository,
            IBaseRepository<PostTagRelationModel> postTagRelationsRepository,
            IBaseRepository<UserModel> userRepository
        )
        {
            _Mapper = mapper;
            _ArticlesRepository = articlesRepository;
            _TagsRepository = tagsRepository;
            _CategoriesRepository = categoriesRepository;
            _PostTagRelationsRepository = postTagRelationsRepository;
            _UserRepository = userRepository;
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

        public Task AddNewArticle(string title, int category, int[] tags, string content, string UserName)
        {
            return Task.Factory.StartNew(() =>
            {
                if (!_CategoriesRepository.Any(category))
                    throw new ArgumentException("指定的Category不存在。");

                var tagModelList = new List<TagModel>();
                foreach (var t in tags)
                {
                    if (!_TagsRepository.Any(t))
                        throw new ArgumentException("指定的Tag不存在。");
                }

                DateTime now = DateTime.Now;
                using (var trans = _CategoriesRepository.BeginTransaction())
                {
                    try
                    {
                        PostModel post = new PostModel
                        {
                            Title = title,
                            Published = false,
                            CreateDate = now,
                            ModifiedData = now,
                            Content = content,
                            CategoryID = category,
                            AnnouncerID = _UserRepository.First(u => u.Name == UserName).ID
                        };
                        _ArticlesRepository.Add(post);

                        foreach (var t in tags)
                        {
                            var rela = new PostTagRelationModel
                            {
                                TagID = t,
                                PostID = post.ID
                            };
                            _PostTagRelationsRepository.Add(rela);
                        }

                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            });
        }
    }
}
