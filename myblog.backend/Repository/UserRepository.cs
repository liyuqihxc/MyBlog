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
    public class UserRepository : BaseRepository<UserModel>, IUserRepository
    {
        public UserRepository(BlogDbContext dbc) : base(dbc)
        {
            
        }

        public override UserModel FirstOrDefault(Expression<Func<UserModel, bool>> predicate)
        {
            return _DbContext.Users.FirstOrDefault(predicate);
        }

        public override UserModel First(Expression<Func<UserModel, bool>> predicate)
        {
            return _DbContext.Users.First(predicate);
        }

        public override IQueryable<UserModel> Where(Expression<Func<UserModel, bool>> predicate)
        {
            return _DbContext.Users.Where(predicate);
        }
    }
}
