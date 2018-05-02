using System;
using System.Collections.Generic;

namespace MyBlog.Models
{
    public class LoginModel
    {
        public string username { get; set; }
        public string password { get; set; }
        public string g_recaptcha_response { get; set; }
    }
}
