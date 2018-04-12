using System;
using System.Collections.Generic;

namespace MyBlog.DataAccess.Models
{
    public class UserModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }
        public string Password { get; set;}
        public string SecurityStamp { get; set; }

        public virtual ICollection<PostModel> Posts { get; set; }
    }
}
