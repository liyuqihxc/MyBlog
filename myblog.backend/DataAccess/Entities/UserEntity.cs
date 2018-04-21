using System;
using System.Collections.Generic;

namespace MyBlog.DataAccess.Entities
{
    public class UserEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }
        public string Password { get; set;}
        public string SecurityStamp { get; set; }

        public virtual ICollection<PostEntity> Posts { get; set; }
    }
}
