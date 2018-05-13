using System;
using System.Collections.Generic;
using System.Linq;

namespace MyBlog.Models
{
    public class PagingModel<T>
        where T : class
    {
        public int CurrentPage { get; set; }
        public int TotalNum { get; set; }
        public T Data { get; set; }
    }
}
