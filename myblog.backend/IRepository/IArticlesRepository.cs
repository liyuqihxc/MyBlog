using System;
using System.Threading.Tasks;
using MyBlog.DataAccess.Entities;

namespace MyBlog.IRepository
{
    public interface IArticlesRepository : IBaseRepository<PostEntity>
    {
        
    }
}
