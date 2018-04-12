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
    public class ImagesRepository : BaseRepository<ImageModel>
    {
        public ImagesRepository(BlogDbContext dbc) : base(dbc)
        {

        }
    }
}
