using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MyBlog.Domain.Entities
{
    public class TagEntity
    {
        [JsonProperty("key")]
        public int ID { get; set; }

        [JsonProperty("label")]
        public string Name { get; set; }

        [JsonIgnore]
        public ICollection<PostTagRelationEntity> TagRelations { get; set; }
    }
}
