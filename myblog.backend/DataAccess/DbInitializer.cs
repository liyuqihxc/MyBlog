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
                context.SaveChanges();
            }

            context.SaveChanges();
        }
    }
}
