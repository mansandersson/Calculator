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
    /// Function operator class
    /// </summary>
    public class Function : Operator
    {
        /// <summary>
        /// Available Function Types
        /// </summary>
        public enum FunctionTypes
        {
            /// <summary>Absolute value</summary>
            ABS,
            /// <summary>Floor value</summary>
            FLOOR,
            /// <summary>Ceiling value</summary>
            CEILING,
            /// <summary>Rounded value</summary>
            ROUND,
            /// <summary>Log e</summary>
            LN,
            /// <summary>Log 10</summary>
            LOG,
            /// <summary>Sine</summary>
            SIN,
            /// <summary>Cosine</summary>
            COS,
            /// <summary>Tangent</summary>
            TAN,
            /// <summary>Square Root</summary>
            SQRT,
            /// <summary>Unknown function</summary>
            UNKNOWN
        }

        /// <summary>
        /// This function's function type
        /// </summary>
        public FunctionTypes Type { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public Function(FunctionTypes type)
        {
            this.Type = type;
            this.Precedence = Precedences.Function;
        }

        /// <summary>
        /// Execute function operator and push answer onto operands stack
        /// </summary>
        /// <param name="operands">stack of operands</param>
        /// <param name="mode">mode to operate in</param>
        /// <returns>true/false if execution went well</returns>
        public override bool Execute(Stack<Operand> operands, CalculatorMode mode)
        {
            try
            {
                if (this.Type == FunctionTypes.UNKNOWN)
                {
                    return false;
                }

                Operand argument = operands.Pop();
                Operand answer = null;

                switch (this.Type)
                {
                    case FunctionTypes.ABS:
                        answer = new Operand(Math.Abs(argument.Value));
                        break;
                    case FunctionTypes.FLOOR:
                        answer = new Operand(Math.Floor(argument.Value));
                        break;
                    case FunctionTypes.CEILING:
                        answer = new Operand(Math.Ceiling(argument.Value));
                        break;
                    case FunctionTypes.ROUND:
                        answer = new Operand(Math.Floor(argument.Value + 0.5));
                        break;
                    case FunctionTypes.LN:
                        answer = new Operand(Math.Log(argument.Value, 2.718281828));
                        break;
                    case FunctionTypes.LOG:
                        answer = new Operand(Math.Log10(argument.Value));
                        break;
                    case FunctionTypes.SIN:
                        answer = new Operand(Math.Sin(argument.Value));
                        break;
                    case FunctionTypes.TAN:
                        answer = new Operand(Math.Tan(argument.Value));
                        break;
                    case FunctionTypes.COS:
                        answer = new Operand(Math.Cos(argument.Value));
                        break;
                    case FunctionTypes.SQRT:
                        answer = new Operand(Math.Sqrt(argument.Value));
                        break;
                }

                if (answer != null)
                {
                    operands.Push(answer);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Checks function names and returns its function types
        /// </summary>
        /// <param name="functionName">function name to check</param>
        /// <returns>function type for function name</returns>
        public static FunctionTypes GetFunctionType(string functionName)
        {
            switch (functionName)
            {
                case "abs":
                    return FunctionTypes.ABS;
                case "floor":
                    return FunctionTypes.FLOOR;
                case "ceil":
                    return FunctionTypes.CEILING;
                case "round":
                    return FunctionTypes.ROUND;
                case "ln":
                    return FunctionTypes.LN;
                case "log":
                    return FunctionTypes.LOG;
                case "sin":
                    return FunctionTypes.SIN;
                case "tan":
                    return FunctionTypes.TAN;
                case "cos":
                    return FunctionTypes.COS;
                case "sqrt":
                    return FunctionTypes.SQRT;
                default:
                    return FunctionTypes.UNKNOWN;
            }
        }
    }
}
