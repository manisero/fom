﻿using System.Collections.Generic;

namespace Core.Extensions
{
    public static class StringExtensions
    {
        public static int ToInt(this string value)
        {
            return int.Parse(value);
        }

        public static string FormatWith(this string pattern, params object[] arguments)
        {
            return string.Format(pattern, arguments);
        }

        public static string JoinWith(this IEnumerable<string> values, string separator)
        {
            return string.Join(separator, values);
        }
    }
}
