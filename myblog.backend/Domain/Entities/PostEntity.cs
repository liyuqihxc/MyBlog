using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBlog.Domain.Entities
{
    public class PostEntity
    {
        public const string AnnouncerIDColumnName = nameof(AnnouncerID);
        public const string CategoryIDColumnName = nameof(CategoryID);
        public const string CoverImageIDColumnName = nameof(CoverImageID);

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Title { get; set; }
        public bool Published { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedData { get; set; }
        public string Content { get; set; }

        public int AnnouncerID { get; set; }

        [ForeignKey(AnnouncerIDColumnName)]
        public UserEntity Announcer { get; set; }

        public int CategoryID { get; set; }

        [ForeignKey(CategoryIDColumnName)]
        public CategoryEntity Category { get; set; }

        public ICollection<PostTagRelationEntity> TagRelations { get; set; }

        public int? CoverImageID { get; set; }

        [ForeignKey(CoverImageIDColumnName)]
        public ImageEntity CoverImage { get; set; }
    }
}
