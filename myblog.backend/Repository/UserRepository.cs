using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyBlog.Common;
using MyBlog.DataAccess;
using MyBlog.DataAccess.Models;
using MyBlog.IRepository;

namespace MyBlog.Repository
{
    public class UserRepository : IUserRepository
    {
        private BlogDbContext _DbContext { get; }

        public UserRepository(BlogDbContext dbc)
        {
            _DbContext = dbc;
        }

        public async Task Create(UserModel NewUser)
        {
            await _DbContext.AddAsync(NewUser);
            await _DbContext.SaveChangesAsync();
        }

        public bool UserExists(string username) => _DbContext.Users.Any(u => u.Name == username);

        public Task<UserModel> Verify(string username, string password)
        {
            return Task<UserModel>.Factory.StartNew(() =>
            {
                return _DbContext.Users.FirstOrDefault(u => u.Name == username && u.Password == Utility.Md5Hash(password));
            });
        }
    }
}
