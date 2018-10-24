using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace MyBlog.Domain.Entities
{
    public class CategoryEntity
    {
        public const int MaxNameLength = 20;

        [JsonProperty("key")]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [JsonProperty("label")]
        [Required, StringLength(MaxNameLength)]
        public string Name { get; set; }

        [JsonIgnore]
        public ICollection<PostEntity> Posts { get; set; }
    }
}
