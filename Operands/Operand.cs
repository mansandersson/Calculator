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
        /// <summary>
        /// Value of operand
        /// </summary>
        public double Value { get; set; }

        /// <summary>
        /// Constructor, initalize value from string
        /// </summary>
        /// <param name="value">string value, hex, binary or decimal</param>
        public Operand(string value)
        {
            bool isParsed = false;
            if (value.Length > 2)
            {
                try
                {
                    string prefix = value.Substring(0, 2);
                    if (prefix.CompareTo("0x") == 0 && value.Length > 2)
                    {
                        Value = (double)Convert.ToInt32(value, 16);
                        isParsed = true;
                    }
                    else if (prefix.CompareTo("0b") == 0 && value.Length > 2)
                    {
                        Value = (double)Convert.ToInt32(value.Substring(2), 2);
                        isParsed = true;
                    }
                }
                catch (Exception)
                {
                    // We couldn't parse string, even though we tried
                    isParsed = false;
                }
            }

            if (!isParsed)
            {
                double v = 0;
                if (Double.TryParse(value, out v))
                {
                    Value = v;
                }
                else
                {
                    Value = 0;
                }
            }
        }

        /// <summary>
        /// Constructor, initialize value from double
        /// </summary>
        /// <param name="value">double value</param>
        public Operand(double value)
        {
            Value = value;
        }
    }
}
