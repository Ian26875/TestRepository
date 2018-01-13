using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class StringExtension
    {

        /// <summary>
        /// Determines whether [is null or white space].
        /// </summary>
        /// <param name="word">The word.</param>
        /// <returns>
        ///   <c>true</c> if [is null or white space] [the specified word]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNullOrWhiteSpace(this string word)
        {
            return string.IsNullOrWhiteSpace(word);
        }

        /// <summary>
        /// Determines whether [is null or empty].
        /// </summary>
        /// <param name="word">The word.</param>
        /// <returns>
        ///   <c>true</c> if [is null or empty] [the specified word]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNullOrEmpty(this string word)
        {
            return string.IsNullOrEmpty(word);
        }
    }
}
