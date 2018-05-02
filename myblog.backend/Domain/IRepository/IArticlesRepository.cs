using System;
using System.Threading.Tasks;
using MyBlog.Domain.Entities;

namespace MyBlog.Domain.IRepository
{
    public interface IArticlesRepository : IBaseRepository<PostEntity>
    {
        
    }
}
