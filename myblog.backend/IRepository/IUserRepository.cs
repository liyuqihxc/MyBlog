using System;
using System.Threading.Tasks;
using MyBlog.DataAccess.Models;

namespace MyBlog.IRepository
{
    public interface IUserRepository : IBaseRepository<UserModel>
    {
        
    }
}
