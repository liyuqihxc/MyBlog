using System;
using System.Collections.Generic;

namespace MyBlog.DataAccess.Entities
{
    public class PostTagRelationEntity
    {
        public int ID { get; set; }
        public int TagID { get; set; }
        public virtual TagEntity Tag { get; set; }
        public int PostID { get; set; }
        public virtual PostEntity Post { get; set; }
    }
}
