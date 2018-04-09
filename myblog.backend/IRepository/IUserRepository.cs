using System;
using System.Threading.Tasks;
using MyBlog.DataAccess.Models;

namespace MyBlog.IRepository
{
    public interface IUserRepository
    {
        bool UserExists(string username);

        Task<UserModel> Verify(string username, string password);

        Task Create(UserModel NewUser);
    }
}
