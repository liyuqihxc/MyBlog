using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBlog.Domain.Entities
{
    public class UserEntity
    {
        public const int MaxUserNameLength = 20;
        public const int MaxNickNameLength = 50;
        public const int MaxPasswordLength = 128;
        public const int MaxSecurityStampLength = 32;

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required, StringLength(MaxUserNameLength)]
        public string UserName { get; set; }

        [Required, StringLength(MaxNickNameLength)]
        public string NickName { get; set; }

        [Required, StringLength(MaxPasswordLength)]
        public string Password { get; set;}

        [Required, StringLength(MaxSecurityStampLength)]
        public string SecurityStamp { get; set; }

        public ICollection<PostEntity> Posts { get; set; }

        public void SetDefaultNickName()
        {
            NickName = UserName;
        }
    }
}
