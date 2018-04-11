using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MyBlog.DataAccess.Models
{
    public partial class CategoryModel
    {
        [JsonProperty("key")]
        public int ID { get; set; }

        [JsonProperty("label")]
        public string Name { get; set; }

        [JsonIgnore]
        public ICollection<PostModel> Posts { get; set; }
    }
}
