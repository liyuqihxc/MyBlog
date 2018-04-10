using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MyBlog.DataAccess;
using MyBlog.DataAccess.Models;
using MyBlog.IRepository;

namespace MyBlog.Repository
{
    public class ArticlesRepository : BaseRepository<PostModel>, IArticlesRepository
    {
        public ArticlesRepository(BlogDbContext dbc) : base(dbc)
        {

        }

        public override Task<IEnumerable<PostModel>> Where(Expression<Func<PostModel, bool>> predicate)
        {
            return Task<IEnumerable<PostModel>>.Factory.StartNew(() =>
            {
                return _DbContext.Posts.Where(predicate);
            });
        }
    }
}
