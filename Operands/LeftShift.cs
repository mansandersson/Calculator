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
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculator.Operands
{
    /// <summary>
    /// LeftShift operator class
    /// </summary>
    public class LeftShift : Operator
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public LeftShift()
        {
            this.Precedence = Precedences.Bitwise;
        }

        /// <summary>
        /// Execute left shift operator and push answer onto operands stack
        /// </summary>
        /// <param name="operands">stac with operandsk</param>
        /// <param name="mode">mode to operate in</param>
        /// <returns>true/false if execution went well</returns>
        public override bool Execute(Stack<Operand> operands, CalculatorMode mode)
        {
            try
            {
                // b % a
                Operand a = operands.Pop();
                Operand b = operands.Pop();
                if (!a.IsInteger || !b.IsInteger)
                    return false;

                Operand c = new Operand((Int32)b.Value << (Int32)a.Value);
                operands.Push(c);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
