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
    public class TagsRepository : BaseRepository<TagModel>
    {
        public TagsRepository(BlogDbContext dbc) : base(dbc)
        {

        }

        public override IQueryable<TagModel> All()
        {
            return _DbContext.Tags;
        }

        public override bool Any(Expression<Func<TagModel, bool>> predicate)
        {
            return _DbContext.Tags.Any(predicate);
        }
    }
}
