/*
    Copyright (c) 2011-2012, Måns Andersson <mail@mansandersson.se>

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
using Calculator.Operands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Calculator
{
    /// <summary>
    /// Calculator execution class
    /// </summary>
    public class Calculator
    {
        /// <summary>
        /// Different types of tokens for quick identification
        /// </summary>
        private enum TokenType
        {
            /// <summary>Operator</summary>
            Operator,
            /// <summary>Left Parenthesis</summary>
            LeftParenthesis,
            /// <summary>RightParenthesis</summary>
            RightParenthesis,
            /// <summary>Value</summary>
            Value,
        }
        private string _input = null;

        /// <summary>
        /// Constructor, initalize expression
        /// </summary>
        /// <param name="input">expression to evaluate with calculator</param>
        public Calculator(string input)
        {
            _input = input;
        }

        /// <summary>
        /// Evaluate expression with Dijkstra's Shunting Yard Algorithm
        /// </summary>
        /// <returns>result of calculations</returns>
        public double? Calculate()
        {
            if (_input == null)
                throw new ArgumentException();

            Stack<Op> operatorStack = new Stack<Op>();
            Queue<Op> outputQueue = new Queue<Op>();

            // Let's split the input string into a token list
            List<String> tokenList = Regex.Split(_input, @"( AND | OR | XOR |[\+\-\*\(\)\/\ ])").Select(t => t.Trim()).Where(t => !String.IsNullOrEmpty(t)).ToList();
            for (int tokenNum = 0; tokenNum < tokenList.Count(); ++tokenNum)
            {
                double? tmpValue;
                String token = tokenList[tokenNum];
                TokenType tokenType = GetTokenType(token, out tmpValue);

                // Handle this token and insert into the correct queue or stack
                switch (tokenType)
                {
                    case TokenType.Value:
                        if (tmpValue.HasValue)
                            outputQueue.Enqueue(new Operand(tmpValue.Value));
                        else
                            throw new ArgumentException("Unknown operand " + token);
                        break;
                    case TokenType.Operator:
                        Operator newOperator = null;
                        switch (token)
                        {
                            case "+":
                                newOperator = new Plus();
                                break;
                            case "-":
                                if (tokenNum == 0 || tokenList[tokenNum - 1] == "(")
                                    newOperator = new Negative();
                                else
                                    newOperator = new Minus();
                                break;
                            case "*":
                                newOperator = new Multiplication();
                                break;
                            case "/":
                                newOperator = new Div();
                                break;
                            case "AND":
                                newOperator = new And();
                                break;
                            case "OR":
                                newOperator = new Or();
                                break;
                            case "XOR":
                                newOperator = new Xor();
                                break;
                            default:
                                throw new ArgumentException("Unknown operator " + token);
                        }
                        if (operatorStack.Count > 0)
                        {
                            Op topOperator = operatorStack.Peek();
                            if (topOperator is Operator)
                            {
                                if (newOperator.Precedence <= ((Operator)topOperator).Precedence)
                                {
                                    outputQueue.Enqueue(operatorStack.Pop());
                                }
                            }
                        }
                        operatorStack.Push(newOperator);
                        break;
                    case TokenType.LeftParenthesis:
                        operatorStack.Push(new LeftParenthesis());
                        break;
                    case TokenType.RightParenthesis:
                        // Handle all operators in the stack (i.e. move them to the outputQueue)
                        // until we find the LeftParenthesis
                        while (!(operatorStack.Peek() is LeftParenthesis))
                        {
                            outputQueue.Enqueue(operatorStack.Pop());
                        }
                        operatorStack.Pop();
                        break;
                }

                // If we don't find any token between a value and parenthesis, automatically
                // add a multiply sign
                if (tokenType == TokenType.Value || tokenType == TokenType.RightParenthesis)
                {
                    if (tokenNum < tokenList.Count() - 1)
                    {
                        String nextToken = tokenList[tokenNum + 1];
                        TokenType nextTokenType = GetTokenType(nextToken, out tmpValue);
                        if (nextTokenType != TokenType.Operator && nextTokenType != TokenType.RightParenthesis)
                        {
                            tokenList.Insert(tokenNum + 1, "*");
                        }
                    }
                }
            }

            // Move all operators into the outputqueue
            while (operatorStack.Count > 0)
            {
                Op operand = operatorStack.Pop();
                if (operand is LeftParenthesis || operand is RightParenthesis)
                {
                    throw new ArgumentException("Mismatched parentheses");
                }

                outputQueue.Enqueue(operand);
            }

            // Now we have the expression in reverse polish notation and it's easy to calculate
            // Step through the outputQueue and calculate the result
            Stack<Operand> outputStack = new Stack<Operand>();
            while (outputQueue.Count > 0)
            {
                Op currentOp = outputQueue.Dequeue();

                if (currentOp is Operand)
                {
                    outputStack.Push((Operand)currentOp);
                }
                else if (currentOp is Operator)
                {
                    Operator currentOperator = (Operator)currentOp;
                    currentOperator.Execute(outputStack);
                }
            }

            // If we haven't got only one answer, the formula is invalid, return that.
            if (outputStack.Count != 1)
            {
                throw new ArgumentException("Invalid formula");
            }

            // Pop and return the result
            return outputStack.Pop().Value;
        }

        /// <summary>
        /// Checks which token type a token belongs to
        /// </summary>
        /// <param name="token">token to check</param>
        /// <returns>the token type for the token</returns>
        private TokenType GetTokenType(String token, out double? value)
        {
            if ((value = Operand.ParseValue(token)) != null)
            {
                return TokenType.Value;
            }
            else if (token == "(")
            {
                return TokenType.LeftParenthesis;
            }
            else if (token == ")")
            {
                return TokenType.RightParenthesis;
            }
            else if (token == "+" ||
                     token == "-" ||
                     token == "*" ||
                     token == "/" ||
                     token == "AND" ||
                     token == "OR" ||
                     token == "XOR")
            {
                return TokenType.Operator;
            }
            else
            {
                throw new ArgumentException("Invalid token");
            }
        }
    }
}
