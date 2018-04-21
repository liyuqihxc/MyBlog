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
    public class TagsRepository : BaseRepository<TagEntity>
    {
        public TagsRepository(BlogDbContext dbc) : base(dbc)
        {

        }

        public override IQueryable<TagEntity> All()
        {
            return _DbContext.Tags;
        }

        public override bool Any(Expression<Func<TagEntity, bool>> predicate)
        {
            return _DbContext.Tags.Any(predicate);
        }
    }
}
