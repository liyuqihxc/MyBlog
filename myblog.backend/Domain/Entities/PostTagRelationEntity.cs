using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBlog.Domain.Entities
{
    public class PostTagRelationEntity
    {
        public const string TagIDColumnName = nameof(TagID);
        public const string PostIDColumnName = nameof(PostID);

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int TagID { get; set; }

        [ForeignKey(TagIDColumnName)]
        public TagEntity Tag { get; set; }
        
        public int PostID { get; set; }

        [ForeignKey(PostIDColumnName)]
        public PostEntity Post { get; set; }
    }
}
