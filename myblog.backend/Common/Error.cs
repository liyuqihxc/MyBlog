using System;
using System.Collections.Generic;

namespace MyBlog.Common
{
    public static class Error
    {
        public const int Success = 0;

        public const int Fail = -1;

        public static string GetErrorDescription(int errCode)
        {
            Dictionary<int, string> map = new Dictionary<int, string>
            {
                { Success, "操作成功完成。" },
                { Fail, "操作失败。" }
            };

            return map[errCode];
        }
    }
}
