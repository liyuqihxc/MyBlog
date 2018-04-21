using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyBlog.Common;
using MyBlog.DataAccess.Entities;
using MyBlog.IRepository;

namespace MyBlog.App
{
    public class AuthApp
    {
        private IBaseRepository<UserEntity> _UserRepository { get; }
        
        public AuthApp(IBaseRepository<UserEntity> userRepository)
        {
            _UserRepository = userRepository;
        }

        public Task<UserEntity> Verify(string username, string password)
        {
            return Task<UserEntity>.Factory.StartNew(() => 
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
