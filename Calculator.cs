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
using Calculator.Operands;

namespace Calculator
{
    /// <summary>
    /// Calculator execution class
    /// </summary>
    public class Calculator
    {
        private string _input = null;
        private List<Op> _operands = null;

        /// <summary>
        /// Constructor, initalize expression
        /// </summary>
        /// <param name="input">expression to evaluate with calculator</param>
        public Calculator(string input)
        {
            _input = input;
        }

        /// <summary>
        /// Evaluate expression
        /// </summary>
        /// <returns>result of calculations</returns>
        public double? Calculate()
        {
            Tokenize();
            Operand result = OperatorPrecedence();

            if (result != null)
                return result.Value;
            else
                return null;
        }

        /// <summary>
        /// Execute operator precedence (requires expression to be tokenized)
        /// </summary>
        /// <returns>the result operand</returns>
        private Operand OperatorPrecedence()
        {
            Stack<Operand> operands = new Stack<Operand>();
            Stack<Operator> operators = new Stack<Operator>();
            
            foreach (Op o in _operands)
            {
                if (o is Operand)
                {
                    operands.Push((Operand)o);
                }
                else if (o is Operator)
                {
                    if (o is LeftParenthesis)
                    {
                        operators.Push((Operator)o);
                    }
                    else if (o is RightParenthesis)
                    {
                        while (operators.Count > 0)
                        {
                            Operator top = operators.Pop();
                            if (top is LeftParenthesis)
                            {
                                continue;
                            }
                            else
                            {
                                top.Execute(operands);
                            }
                        }
                    }
                    else
                    {
                        while (operators.Count > 0)
                        {
                            Operator top = operators.Peek();
                            if (top.Precedence >= ((Operator)o).Precedence)
                            {
                                top = operators.Pop();
                                top.Execute(operands);
                            }
                            else
                            {
                                break;
                            }
                        }
                        operators.Push((Operator)o);
                    }
                }
            }

            while (operators.Count > 0)
            {
                Operator top = operators.Pop();
                top.Execute(operands);
            }

            if (operands.Count == 1)
            {
                return operands.Pop();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Split expression into tokens
        /// </summary>
        private void Tokenize()
        {
            if (_operands == null)
            {
                _operands = new List<Op>();
                string currToken = null;
                char[] characters = _input.ToCharArray();
                foreach (char character in characters)
                {
                    switch (character) // check every possible operator character, or append to operand token
                    {
                        case ' ':
                            // Skip spaces
                            break;
                        case '+':
                            AddOperand(currToken);
                            currToken = null;
                            _operands.Add(new Plus());
                            break;
                        case '-':
                            AddOperand(currToken);
                            currToken = null;
                            _operands.Add(new Minus());
                            break;
                        case '*':
                            AddOperand(currToken);
                            currToken = null;
                            _operands.Add(new Multiplication());
                            break;
                        case '/':
                            AddOperand(currToken);
                            currToken = null;
                            _operands.Add(new Div());
                            break;
                        case '%':
                            AddOperand(currToken);
                            currToken = null;
                            _operands.Add(new Modulus());
                            break;
                        case '&':
                            AddOperand(currToken);
                            currToken = null;
                            _operands.Add(new And());
                            break;
                        case '^':
                            AddOperand(currToken);
                            currToken = null;
                            _operands.Add(new Xor());
                            break;
                        case '~':
                            AddOperand(currToken);
                            currToken = null;
                            _operands.Add(new Not());
                            break;
                        case '|':
                            AddOperand(currToken);
                            currToken = null;
                            _operands.Add(new Or());
                            break;
                        case '(':
                            if (AddOperand(currToken))
                            {
                                _operands.Add(new Multiplication());
                                currToken = null;
                            }
                            else
                            {
                                currToken = null;
                            }
                            _operands.Add(new LeftParenthesis());
                            break;
                        case ')':
                            AddOperand(currToken);
                            currToken = null;
                            _operands.Add(new RightParenthesis());
                            break;
                        default:
                            if (currToken != null)
                                currToken += character.ToString();
                            else
                                currToken = character.ToString();
                            break;
                    }
                }
                AddOperand(currToken);
            }
        }

        /// <summary>
        /// Create operand object and push into stack
        /// </summary>
        /// <param name="token">operand as string</param>
        /// <returns>true/false if operand was created</returns>
        private bool AddOperand(string token)
        {
            if (token != null)
            {
                Operand op = new Operand(token);
                _operands.Add(op);
                return true;
            }
            return false;
        }
    }
}
