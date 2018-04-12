using System;
using System.Collections.Generic;

namespace MyBlog.DataAccess.Models
{
    public class ImageModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public byte[] Image { get; set; }

        public virtual ICollection<PostModel> Posts { get; set; }
    }
}
