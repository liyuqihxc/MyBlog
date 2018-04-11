using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyBlog.Common;
using MyBlog.DataAccess.Models;

namespace MyBlog.DataAccess
{
    internal static class DbInitializer
    {
        public static void Initialize(BlogDbContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Users.Any())
            {
                UserModel user = new UserModel
                {
                    Name = "admin",
                    NickName = "admin",
                    Password = Utility.Md5Hash("963852"),
                    SecurityStamp = Utility.GenerateSecurityStamp()
                };
                context.Users.Add(user);

                context.Categories.Add(new CategoryModel
                {
                    Name = "电子技术"
                });
                context.Categories.Add(new CategoryModel
                {
                    Name = "软件技术"
                });
                context.Categories.Add(new CategoryModel
                {
                    Name = "操作系统"
                });

                context.Tags.Add(new TagModel
                {
                    Name = "CPP"
                });
                context.Tags.Add(new TagModel
                {
                    Name = "DotNet"
                });

                context.SaveChanges();
            }
        }
    }
}
