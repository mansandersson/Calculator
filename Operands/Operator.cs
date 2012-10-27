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
using System.Collections.Generic;

namespace Calculator.Operands
{
    /// <summary>
    /// Precedences (the higher the precedence is the sooner it gets executed)
    /// </summary>
    public enum Precedences
    {
        /// <summary>
        /// Plus and minus precedence factor
        /// </summary>
        PlusMinus = 1,
        /// <summary>
        /// Multiplication and division precedence factor
        /// </summary>
        MultDiv = 2,
        /// <summary>
        /// Bitwise (e.g. and, xor) precedence factor
        /// </summary>
        Bitwise = 3,
        /// <summary>
        /// Exponential calculations precedence factor
        /// </summary>
        Exponent = 4,
    }

    /// <summary>
    /// Abstract operator class
    /// </summary>
    public abstract class Operator : Op
    {
        /// <summary>
        /// Precedence of operator
        /// </summary>
        public Precedences? Precedence { get; protected set; }

        /// <summary>
        /// Execute operator
        /// </summary>
        /// <param name="operands">stack of operands to execute on</param>
        /// <returns>true / false if succeeded</returns>
        public abstract bool Execute(Stack<Operand> operands);
    }
}
