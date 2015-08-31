using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebNews.Utils.Extensions
{
    public static class DateExtensions
    {
        public static string FormatDateString(this DateTime? dateTime)
        {
            if (dateTime.HasValue)
                return dateTime.Value.ToString(Utils.Constants.DateTimeFormats.StandardFullFormat);

            return string.Empty;
        }
    }
}