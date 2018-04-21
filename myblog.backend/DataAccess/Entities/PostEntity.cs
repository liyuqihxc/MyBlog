using System;
using System.Collections.Generic;

namespace MyBlog.DataAccess.Entities
{
    public class PostEntity
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public bool Published { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedData { get; set; }
        public string Content { get; set; }

        public int AnnouncerID { get; set; }
        public virtual UserEntity Announcer { get; set; }

        public int CategoryID { get; set; }
        public virtual CategoryEntity Category { get; set; }

        public virtual ICollection<PostTagRelationEntity> TagRelations { get; set; }

        public int? CoverImageID { get; set; }

        public ImageEntity CoverImage { get; set; }
}
}
