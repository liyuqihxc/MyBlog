using System;
using System.Collections.Generic;

namespace MyBlog.Domain.Entities
{
    public class UserEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }
        public string Password { get; set;}
        public string SecurityStamp { get; set; }

        public ICollection<PostEntity> Posts { get; set; }
    }
}
