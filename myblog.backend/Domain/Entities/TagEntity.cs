using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace MyBlog.Domain.Entities
{
    public class TagEntity
    {
        public const int MaxNameLength = 10;

        [JsonProperty("key")]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [JsonProperty("label")]
        [Required, StringLength(MaxNameLength)]
        public string Name { get; set; }

        [JsonIgnore]
        public ICollection<PostTagRelationEntity> TagRelations { get; set; }
    }
}
