using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyBlog.Common;
using MyBlog.Domain.Entities;
using MyBlog.Domain.IRepository;
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
                    TotalNum = total,
                    CurrentPage = page,
                    Data = _Mapper.Map<IEnumerable<ArticleModel>>(result)
                };
            });
        }

        public async Task<IEnumerable<CategoryEntity>> GetAllCategories()
        {
            return await _CategoriesRepository.All().ToListAsync();
        }

        public async Task<IEnumerable<TagEntity>> GetAllTags()
        {
            return await _TagsRepository.All().ToListAsync();
        }

        public Task<int> AddNewArticle(string title, string category, string[] tags, string content, bool Published, string UserName)
        {
            return Task<int>.Factory.StartNew(() =>
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
                            AnnouncerID = _UserRepository.First(u => u.UserName == UserName).ID
                        };
                        _ArticlesRepository.InsertAsync(post);

                        foreach (var t in tags)
                        {
                            var rela = new PostTagRelationEntity
                            {
                                TagID = t,
                                PostID = post.ID
                            };
                            _PostTagRelationsRepository.InsertAsync(rela);
                        }

                        trans.Commit();
                        return post.ID;
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            });
        }

        public Task UpdateArticle(int PostID, string title, int category, int[] tags, string content, bool Published)
        {
            return Task.Factory.StartNew(() =>
            {
                var article = _ArticlesRepository.First(m => m.ID == PostID);

                article.Title = title;
                article.CategoryID = category;
                article.ModifiedData = DateTime.UtcNow;
                article.Content = content;
                article.Published = Published;

                _ArticlesRepository.Update(article);
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
