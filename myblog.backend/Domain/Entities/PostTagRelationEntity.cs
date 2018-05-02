using System;
using System.Collections.Generic;

namespace MyBlog.Domain.Entities
{
    public class PostTagRelationEntity
    {
        public int ID { get; set; }
        public int TagID { get; set; }
        public TagEntity Tag { get; set; }
        public int PostID { get; set; }
        public PostEntity Post { get; set; }
    }
}
