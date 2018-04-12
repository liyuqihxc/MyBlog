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
    public class PostTagRelationsRepository : BaseRepository<PostTagRelationModel>
    {
        public PostTagRelationsRepository(BlogDbContext dbc) : base(dbc)
        {
        }
    }
}
