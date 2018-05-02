using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MyBlog.Domain.Entities
{
    public class CategoryEntity
    {
        [JsonProperty("key")]
        public int ID { get; set; }

        [JsonProperty("label")]
        public string Name { get; set; }

        [JsonIgnore]
        public ICollection<PostEntity> Posts { get; set; }
    }
}
