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
    }
}
