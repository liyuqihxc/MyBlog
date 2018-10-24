using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBlog.Domain.Entities
{
    public class ImageEntity
    {
        public const int MaxFileNameLength = 50;
        public const int MaxDescriptionLength = 150;

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required, StringLength(MaxFileNameLength)]
        public string FileName { get; set; }

        [StringLength(MaxDescriptionLength)]
        public string Description{ get; set; }

        [Required]
        public byte[] Image { get; set; }

        public ICollection<PostEntity> Posts { get; set; }
    }
}
