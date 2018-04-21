using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MyBlog.DataAccess;
using MyBlog.DataAccess.Entities;
using MyBlog.IRepository;

namespace MyBlog.Repository
{
    public class ArticlesRepository : BaseRepository<PostEntity>
    {
        public ArticlesRepository(BlogDbContext dbc) : base(dbc)
        {

        }

        public override IQueryable<PostEntity> All()
        {
            return _DbContext.Posts;
        }

        public override IQueryable<PostEntity> Where(Expression<Func<PostEntity, bool>> predicate)
        {
            return _DbContext.Posts.Where(predicate);
        }

        public override PostEntity First(Expression<Func<PostEntity, bool>> predicate)
        {
            return _DbContext.Posts.First(predicate);
        }
    }
}
