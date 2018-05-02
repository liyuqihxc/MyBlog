using System;
using System.Collections.Generic;

namespace MyBlog.Models
{
    public class KeyLabelModel<TKey>
    {
        public TKey Key { get; set; }

        public string Label { get; set; }
    }
}
