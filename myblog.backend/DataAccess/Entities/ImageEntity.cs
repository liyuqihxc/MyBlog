using System;
using System.Collections.Generic;

namespace MyBlog.DataAccess.Entities
{
    public class ImageEntity
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public byte[] Image { get; set; }

        public virtual ICollection<PostEntity> Posts { get; set; }
    }
}
