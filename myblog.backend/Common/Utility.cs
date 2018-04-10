using System;
using System.Security.Cryptography;
using System.Text;

namespace MyBlog.Common
{
    public static class Utility
    {
        public static Encoding DefaultEncoding { get; } = Encoding.UTF8;
        public static byte[] Md5Hash(byte[] data) => MD5.Create().ComputeHash(data);

        public static string Md5Hash(string data) => StringFromByteArray(Md5Hash(DefaultEncoding.GetBytes(data)));

        public static string GenerateSecurityStamp()
        {
            byte[] random = new byte[256 / 8];
            RNGCryptoServiceProvider.Create().GetNonZeroBytes(random);
            var hash = Md5Hash(random);
            return StringFromByteArray(hash);
        }

        private static string StringFromByteArray(byte[] data)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sb.Append(data[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
