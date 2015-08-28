using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebNews.Utils.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNotNullOrEmpty(this string str)
        {
            return !string.IsNullOrEmpty(str);
        }
    }
}