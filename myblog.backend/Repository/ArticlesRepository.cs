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
    public class ArticlesRepository : BaseRepository<PostModel>
    {
        public ArticlesRepository(BlogDbContext dbc) : base(dbc)
        {

        }

        public override IQueryable<PostModel> All()
        {
            return _DbContext.Posts;
        }

        public override IQueryable<PostModel> Where(Expression<Func<PostModel, bool>> predicate)
        {
            return _DbContext.Posts.Where(predicate);
        }
    }
}
