using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MyBlog.Domain.Entities;
using MyBlog.Domain.IRepository;

namespace MyBlog.Repository
{
    public class UserRepository : BaseRepository<UserEntity>, IUserRepository
    {
        public UserRepository(BlogDbContext dbc) : base(dbc)
        {
            
        }
    }
}
