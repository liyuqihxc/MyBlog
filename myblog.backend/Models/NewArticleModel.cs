using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyBlog.Models
{
    public class NewArticleModel
    {
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [MinLength(1)]
        public int[] Tags{ get; set; }

        [Required]
        public int Category { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
