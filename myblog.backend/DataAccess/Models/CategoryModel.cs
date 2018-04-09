using System;
using System.Collections.Generic;

namespace MyBlog.DataAccess.Models
{
    public partial class CategoryModel
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public ICollection<PostModel> Posts { get; set; }
    }
}
