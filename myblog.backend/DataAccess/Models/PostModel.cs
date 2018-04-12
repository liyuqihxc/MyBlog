using System;
using System.Collections.Generic;

namespace MyBlog.DataAccess.Models
{
    public class PostModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public bool Published { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedData { get; set; }
        public string Content { get; set; }

        public int AnnouncerID { get; set; }
        public virtual UserModel Announcer { get; set; }

        public int CategoryID { get; set; }
        public virtual CategoryModel Category { get; set; }

        public virtual ICollection<PostTagRelationModel> TagRelations { get; set; }

        public int? CoverImageID { get; set; }

        public ImageModel CoverImage { get; set; }
}
}
