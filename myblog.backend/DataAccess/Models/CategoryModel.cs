using System;
using System.Collections.Generic;

namespace MyBlog.DataAccess.Models
{
    public partial class CategoryModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<PostModel> Posts { get; set; }
    }
}
