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

        public override Task<UserModel> FirstOrDefault(Expression<Func<UserModel, bool>> predicate)
        {
            return Task<UserModel>.Factory.StartNew(() =>
            {
                return _DbContext.Users.FirstOrDefault(predicate);
            });
        }

        public override Task<UserModel> First(Expression<Func<UserModel, bool>> predicate)
        {
            return Task<UserModel>.Factory.StartNew(() =>
            {
                return _DbContext.Users.First(predicate);
            });
        }

        public override Task<IEnumerable<UserModel>> Where(Expression<Func<UserModel, bool>> predicate)
        {
            return Task<IEnumerable<UserModel>>.Factory.StartNew(() =>
            {
                return _DbContext.Users.Where(predicate);
            });
        }
    }
}
