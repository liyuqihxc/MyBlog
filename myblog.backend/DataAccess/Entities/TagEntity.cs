using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MyBlog.DataAccess.Entities
{
    public class TagEntity
    {
        [JsonProperty("key")]
        public int ID { get; set; }

        [JsonProperty("label")]
        public string Name { get; set; }

        [JsonIgnore]
        public virtual ICollection<PostTagRelationEntity> TagRelations { get; set; }
    }
}
