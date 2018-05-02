using System;
using System.Collections.Generic;

namespace MyBlog.Domain.Entities
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
        public UserEntity Announcer { get; set; }

        public int CategoryID { get; set; }
        public CategoryEntity Category { get; set; }

        public ICollection<PostTagRelationEntity> TagRelations { get; set; }

        public int? CoverImageID { get; set; }

        public ImageEntity CoverImage { get; set; }
}
}
