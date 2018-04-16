using System;
using System.Collections.Generic;
using System.Linq;
using MyBlog.Common;
using Newtonsoft.Json;

namespace MyBlog.ViewModels
{
    public class ArticleVM
    {
        public int ID { get; set; }
        public string Title { get; set; }

        [JsonConverter(typeof(DateConverter))]
        public DateTime CreateDate { get; set; }

        [JsonConverter(typeof(DateConverter))]
        public DateTime ModifiedData { get; set; }
        public string Announcer { get; set; }
        public string Content { get; set; }
        public int? CoverImageID { get; set; }
        public int Category { get; set; }
        public IEnumerable<int> Tags { get; set; }
    }
}
