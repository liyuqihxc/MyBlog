using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyBlog.Common;
using MyBlog.DataAccess.Models;
using MyBlog.IRepository;

namespace MyBlog.App
{
    public class AuthApp
    {
        private IBaseRepository<UserModel> _UserRepository { get; }
        
        public AuthApp(IBaseRepository<UserModel> userRepository)
        {
            _UserRepository = userRepository;
        }

        public Task<UserModel> Verify(string username, string password)
        {
            return Task<UserModel>.Factory.StartNew(() => 
            {
                return _UserRepository.FirstOrDefault(u => u.Name == username && u.Password == Utility.Md5Hash(password));
            });
        }

        public Task ResetUserSecurityStamp()
        {
            throw new NotImplementedException();
        }
    }
}
