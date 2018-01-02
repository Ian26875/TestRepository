using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Extensions
{
    public static class StringExtension
    {

        public static bool IsNullOrWhiteSpace(this string word)
        {
            return string.IsNullOrWhiteSpace(word);
        }

        public static bool IsNullOrEmpty(this string word)
        {
            return string.IsNullOrEmpty(word);
        }
    }
}
