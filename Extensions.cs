using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculator
{
    /// <summary>
    /// Collection of extension functions
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Reverse the string
        /// </summary>
        /// <param name="s">this string object</param>
        /// <returns>The string reversed</returns>
        public static string Reverse(this string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        /// <summary>
        /// Split a string every nth character
        /// </summary>
        /// <param name="s">this string object</param>
        /// <param name="n">number of characters per chunk</param>
        /// <returns></returns>
        public static IEnumerable<String> SplitEveryNth(this String s, Int32 n)
        {
            if (s == null)
                throw new ArgumentNullException("s");
            if (n <= 0)
                throw new ArgumentException("N has to be positive.", "partLength");

            for (var i = 0; i < s.Length; i += n)
                yield return s.Substring(i, Math.Min(n, s.Length - i));
        }
    }
}
