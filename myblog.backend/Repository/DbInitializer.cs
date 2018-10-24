using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyBlog.Common;
using MyBlog.Domain.Entities;

namespace MyBlog.Repository
{
    internal static class DbInitializer
    {
        public static void Initialize(BlogDbContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Users.Any())
            {
                UserEntity user = new UserEntity
                {
                    UserName = "admin",
                    NickName = "admin",
                    Password = Utility.Md5Hash("963852"),
                    SecurityStamp = Utility.GenerateSecurityStamp()
                };
                context.Users.Add(user);

                context.Categories.Add(new CategoryEntity
                {
                    Name = "电子技术"
                });
                context.Categories.Add(new CategoryEntity
                {
                    Name = "软件技术"
                });
                context.Categories.Add(new CategoryEntity
                {
                    Name = "操作系统"
                });

                context.Tags.Add(new TagEntity
                {
                    Name = "CPP"
                });
                context.Tags.Add(new TagEntity
                {
                    Name = "DotNet"
                });

                context.SaveChanges();
            }
        }
    }
}
