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
using System;
using System.Collections.Generic;
namespace Calculator
{
    /// <summary>
    /// Variables
    /// </summary>
    public class Variables
    {
        public static Variables Instance = new Variables();

        /// <summary>
        /// A single variable definition
        /// </summary>
        private class Variable
        {
            /// <summary>
            /// Calculator mode for calculation
            /// </summary>
            public CalculatorMode Mode { get; set; }
            /// <summary>
            /// Calculation
            /// </summary>
            public string Calculation { get; set; }
            /// <summary>
            /// Value
            /// </summary>
            public double? Value
            {
                get
                {
                    Calculator calc = new Calculator(Calculation); // risk for a never-ending loop due to recursion
                    calc.Mode = Mode;
                    try
                    {
                        return calc.Calculate();
                    }
                    catch (Exception)
                    {
                        return null;
                    }
                }
            }
        }

        private Dictionary<string, Variable> VariableDict;

        /// <summary>
        /// Constructor, initialize variables class
        /// </summary>
        public Variables()
        {
            this.VariableDict = new Dictionary<string, Variable>();
        }

        /// <summary>
        /// add a constant value to the variables dictionary
        /// </summary>
        /// <param name="name">variable name</param>
        /// <param name="calculation">variable calculation</param>
        /// <param name="mode">calculator mode for calculation</param>
        /// <returns>True if variable was added, false if it already exists</returns>
        public bool AddOrUpdateVariable(string name, string calculation, CalculatorMode mode)
        {
            try
            {
                if (!this.VariableDict.ContainsKey(name))
                {
                    this.VariableDict.Add(name, new Variable());
                }

                Variable var;
                if (this.VariableDict.TryGetValue(name, out var))
                {
                    var.Calculation = calculation;
                    var.Mode = mode;
                    return true;
                }
            }
            catch
            {
                // do nothing
            }
            return false;
        }

        /// <summary>
        /// checks if a string is declared in the the dictionary of variables
        /// and in that case retreives the parameter
        /// </summary>
        /// <param name="name">Name to find</param>
        /// <param name="retVal">storage for constant if found</param>
        /// <returns>True if constant was found, else False</returns>
        public bool TryGetValue(string name, out double? retVal)
        {
            Variable var;
            if (this.VariableDict.TryGetValue(name, out var))
            {
                retVal = var.Value;
                return true;
            }
            retVal = null;
            return false;
        }
    }
}

