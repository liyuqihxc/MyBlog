using System;
using System.Collections.Generic;
using MyBlog.Domain.Entities;

namespace MyBlog.Domain.IRepository
{
    public interface IPostTagRelationsRepository : IBaseRepository<PostTagRelationEntity>
    {
    }
}
