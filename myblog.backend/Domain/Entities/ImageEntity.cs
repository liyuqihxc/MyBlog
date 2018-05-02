using System;
using System.Collections.Generic;

namespace MyBlog.Domain.Entities
{
    public class ImageEntity
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public byte[] Image { get; set; }

        public ICollection<PostEntity> Posts { get; set; }
    }
}
