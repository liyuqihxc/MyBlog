using System;
using System.Collections.Generic;

namespace MyBlog.DataAccess.Models
{
    public class PostTagRelationModel
    {
        public int ID { get; set; }
        public int TagID { get; set; }
        public TagModel Tag { get; set; }
        public int PostID { get; set; }
        public PostModel Post { get; set; }
    }
}