using System;
using System.Collections.Generic;

namespace MyBlog.DataAccess.Models
{
    public partial class TagModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<TagRelationModel> TagRelations { get; set; }
    }
}
