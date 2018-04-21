using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyBlog.Common;
using MyBlog.DataAccess.Entities;
using MyBlog.IRepository;
using MyBlog.Models;

namespace MyBlog.App
{
    public class ArticlesApp
    {
        private IMapper _Mapper { get; }
        private IBaseRepository<PostEntity> _ArticlesRepository { get; }
        private IBaseRepository<TagEntity> _TagsRepository { get; }
        private IBaseRepository<CategoryEntity> _CategoriesRepository { get; }
        private IBaseRepository<PostTagRelationEntity> _PostTagRelationsRepository { get; }
        private IBaseRepository<UserEntity> _UserRepository { get; }

        public ArticlesApp(
            IMapper mapper,
            IBaseRepository<PostEntity> articlesRepository,
            IBaseRepository<TagEntity> tagsRepository,
            IBaseRepository<CategoryEntity> categoriesRepository,
            IBaseRepository<PostTagRelationEntity> postTagRelationsRepository,
            IBaseRepository<UserEntity> userRepository
        )
        {
            _Mapper = mapper;
            _ArticlesRepository = articlesRepository;
            _TagsRepository = tagsRepository;
            _CategoriesRepository = categoriesRepository;
            _PostTagRelationsRepository = postTagRelationsRepository;
            _UserRepository = userRepository;
        }

        public Task<PagingModel<IEnumerable<ArticleModel>>> PreviewAllArticles(int page, int count)
        {
            return Task<PagingModel<IEnumerable<ArticleModel>>>.Factory.StartNew(() => 
            {
                int total = _ArticlesRepository.Where(p => p.Published).Count();
                var result = _ArticlesRepository.Where(p => p.Published)
                    .OrderByDescending(p => p.CreateDate)
                    .Include(p => p.Category)
                    .Include(p => p.Announcer)
                    .Include(p => p.TagRelations)
                    .Skip((page - 1) * count)
                    .Take(count)
                    .ToArray();

                foreach(var article in result)
                {
                    article.Content = string.Join("", article.Content.Split(new[]{"\r\n","\r","\n"}, StringSplitOptions.None).Take(15));
                }

                return new PagingModel<IEnumerable<ArticleModel>>
                {
                    TotalPage = (total / count) + (total % count) == 0 ? 0 : 1,
                    CurrentPage = page,
                    Data = _Mapper.Map<IEnumerable<ArticleModel>>(result)
                };
            });
        }

        public Task<IEnumerable<CategoryEntity>> GetAllCategories()
        {
            return Task<IEnumerable<CategoryEntity>>.Factory.StartNew(() =>
            {
                return _CategoriesRepository.All().ToArray();
            });
        }

        public Task<IEnumerable<TagEntity>> GetAllTags()
        {
            return Task<IEnumerable<TagEntity>>.Factory.StartNew(() =>
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

                var tagModelList = new List<TagEntity>();
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
                        PostEntity post = new PostEntity
                        {
                            Title = title,
                            Published = true,
                            CreateDate = now,
                            ModifiedData = now,
                            Content = content,
                            CategoryID = category,
                            AnnouncerID = _UserRepository.First(u => u.Name == UserName).ID
                        };
                        _ArticlesRepository.Add(post);

                        foreach (var t in tags)
                        {
                            var rela = new PostTagRelationEntity
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

        public Task<ArticleModel> LoadArticle(int id)
        {
            return Task<ArticleModel>.Factory.StartNew(() =>
            {
                var article = _ArticlesRepository
                    .All()
                    .Include(p => p.Announcer)
                    .Include(p => p.TagRelations)
                    .First(p => p.ID == id);
                return _Mapper.Map<ArticleModel>(article);
            });
        }
    }
}
