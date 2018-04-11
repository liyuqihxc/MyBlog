
using System;
using Newtonsoft.Json.Converters;

namespace MyBlog.Common
{
    class DateConverter : IsoDateTimeConverter
    {
        public DateConverter()
        {
            base.DateTimeFormat = "yyyy-MM-dd";
        }
    }
}
