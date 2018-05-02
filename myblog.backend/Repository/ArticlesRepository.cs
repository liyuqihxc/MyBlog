using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MyBlog.Domain.Entities;
using MyBlog.Domain.IRepository;

namespace MyBlog.Repository
{
    public class ArticlesRepository : BaseRepository<PostEntity>, IArticlesRepository
    {
        public ArticlesRepository(BlogDbContext dbc) : base(dbc)
        {

        }
    }
}
