using System;
using System.Collections.Generic;
using System.Linq;

namespace MyBlog.ViewModels
{
    public class PagingVM<T>
        where T : class
    {
        public int CurrentPage { get; set; }
        public int TotalPage { get; set; }
        public T Data { get; set; }
    }
}
