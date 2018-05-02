using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MyBlog.Domain.Entities;
using MyBlog.Domain.IRepository;

namespace MyBlog.Repository
{
    public class PostTagRelationsRepository : BaseRepository<PostTagRelationEntity>, IPostTagRelationsRepository
    {
        public PostTagRelationsRepository(BlogDbContext dbc) : base(dbc)
        {
        }
    }
}
