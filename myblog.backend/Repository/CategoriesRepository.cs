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
    public class CategoriesRepository : BaseRepository<CategoryEntity>
    {
        public CategoriesRepository(BlogDbContext dbc) : base(dbc)
        {

        }

        public override IQueryable<CategoryEntity> All()
        {
            return _DbContext.Categories;
        }

        public override bool Any(Expression<Func<CategoryEntity, bool>> predicate)
        {
            return _DbContext.Categories.Any(predicate);
        }
    }
}
