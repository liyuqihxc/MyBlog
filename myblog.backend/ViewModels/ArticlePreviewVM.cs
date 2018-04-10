using System;
using System.Collections.Generic;
using System.Linq;

namespace MyBlog.ViewModels
{
    public class ArticlePreviewVM
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public bool Published { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedData { get; set; }
        public int AnnouncerID { get; set; }
        public string Announcer { get; set; }
        public string Category { get; set; }
        public ICollection<string> Tags { get; set; }
    }
}
