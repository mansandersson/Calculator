/*
    Copyright (c) 2011, Måns Andersson <mail@mansandersson.se>

    Permission to use, copy, modify, and/or distribute this software for any
    purpose with or without fee is hereby granted, provided that the above
    copyright notice and this permission notice appear in all copies.

    THE SOFTWARE IS PROVIDED "AS IS" AND THE AUTHOR DISCLAIMS ALL WARRANTIES
    WITH REGARD TO THIS SOFTWARE INCLUDING ALL IMPLIED WARRANTIES OF
    MERCHANTABILITY AND FITNESS. IN NO EVENT SHALL THE AUTHOR BE LIABLE FOR
    ANY SPECIAL, DIRECT, INDIRECT, OR CONSEQUENTIAL DAMAGES OR ANY DAMAGES
    WHATSOEVER RESULTING FROM LOSS OF USE, DATA OR PROFITS, WHETHER IN AN
    ACTION OF CONTRACT, NEGLIGENCE OR OTHER TORTIOUS ACTION, ARISING OUT OF
    OR IN CONNECTION WITH THE USE OR PERFORMANCE OF THIS SOFTWARE.
*/
using System;


namespace Calculator.Operands
{
    /// <summary>
    /// Operand (value)
    /// </summary>
    public class Operand : Op
    {
        private static Constants c = new Constants();
        /// <summary>
        /// Value of operand
        /// </summary>
        public double Value { get; set; }
        /// <summary>
        /// Whether value is an integer value
        /// </summary>
        public bool IsInteger
        {
            get
            {
                return (Value == (Int64)Value);
            }
        }

        /// <summary>
        /// Constructor, initalize value from string
        /// </summary>
        /// <param name="value">string value, hex, binary or decimal</param>
        public Operand(String value)
        {
            Value = ParseValue(value) ?? 0;
        }

        /// <summary>
        /// Constructor, initialize value from double
        /// </summary>
        /// <param name="value">double value</param>
        public Operand(double value)
        {
            Value = value;
        }

        /// <summary>
        /// This parses a token as a value (hex, bit and decimal strings supported)
        /// </summary>
        /// <param name="token">token to parse</param>
        /// <returns>value received after parsing, null if we couldn't parse value</returns>
        public static double? ParseValue(String token)
        {

            double? returnValue = null;
            if (token.Length > 2)
            {
                try
                {
                    string prefix = token.Substring(0, 2);
                    if (prefix.CompareTo("0x") == 0 && token.Length > 2)
                    {
                        returnValue = (double)Convert.ToInt32(token, 16);
                    }
                    else if (prefix.CompareTo("0b") == 0 && token.Length > 2)
                    {
                        returnValue = (double)Convert.ToInt32(token.Substring(2), 2);
                    }
                }
                catch (Exception)
                {
                    // We couldn't parse string, even though we tried
                }
            }

            if (!returnValue.HasValue)
            {
                c.TryGetValue(token, out returnValue);
            }
            if (!returnValue.HasValue)
            {
                Variables.Instance.TryGetValue(token, out returnValue);
            }
            if (!returnValue.HasValue)
            {
                double v = 0;
                if (Double.TryParse(token, out v))
                {
                    returnValue = v;
                }
            }
            return returnValue;
        }
    }
}
