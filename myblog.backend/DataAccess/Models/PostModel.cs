using System;
using System.Collections.Generic;

namespace MyBlog.DataAccess.Models
{
    public partial class PostModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public bool Published { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedData { get; set; }
        public int AnnouncerID { get; set; }
        public UserModel Announcer { get; set; }
        public string Content { get; set; }

        public int CategoryID { get; set; }
        public CategoryModel Category { get; set; }

        public ICollection<TagModel> Tags { get; set; }
    }
}
