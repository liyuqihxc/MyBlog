using System;
using System.Security.Cryptography;
using System.Text;

namespace MyBlog.Common
{
    public static class Utility
    {
        public static Encoding DefaultEncoding { get; } = Encoding.UTF8;
        public static byte[] Md5Hash(byte[] data) => MD5.Create().ComputeHash(data);

        public static string Md5Hash(string data)
        {
            var hash = Md5Hash(DefaultEncoding.GetBytes(data));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        public static string GenerateSecurityStamp()
        {
            byte[] random = new byte[256 / 8];
            RNGCryptoServiceProvider.Create().GetNonZeroBytes(random);
            var hash = Md5Hash(random);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
