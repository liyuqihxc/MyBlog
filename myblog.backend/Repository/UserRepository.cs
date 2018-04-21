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
    public class UserRepository : BaseRepository<UserEntity>
    {
        public UserRepository(BlogDbContext dbc) : base(dbc)
        {
            
        }

        public override UserEntity FirstOrDefault(Expression<Func<UserEntity, bool>> predicate)
        {
            return _DbContext.Users.FirstOrDefault(predicate);
        }

        public override UserEntity First(Expression<Func<UserEntity, bool>> predicate)
        {
            return _DbContext.Users.First(predicate);
        }

        public override IQueryable<UserEntity> Where(Expression<Func<UserEntity, bool>> predicate)
        {
            return _DbContext.Users.Where(predicate);
        }
    }
}
