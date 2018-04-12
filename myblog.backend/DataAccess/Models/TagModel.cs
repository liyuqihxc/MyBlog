using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MyBlog.DataAccess.Models
{
    public class TagModel
    {
        [JsonProperty("key")]
        public int ID { get; set; }

        [JsonProperty("label")]
        public string Name { get; set; }

        [JsonIgnore]
        public virtual ICollection<PostTagRelationModel> TagRelations { get; set; }
    }
}
