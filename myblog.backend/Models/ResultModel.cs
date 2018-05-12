using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MyBlog.Models
{
    public class ResultModel
    {
        public int StatusCode { get; set; }

        public string Message { get; set; }

        public object Data { get; set; }
    }
}
