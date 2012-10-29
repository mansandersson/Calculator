using System;
using System.Collections.Generic;
namespace Calculator.Operands.Constants
{
    /// <summary>
    /// Constants
    /// </summary>
    public class Constants
    {
        public Dictionary<string, double?>ConstantDict;
        /// <summary>
        /// Constructor, initialize constant class with relevant constants.
        /// </summary>
        public Constants()
        {
            this.ConstantDict = new Dictionary<string, double?>();
            ConstantDict.Add("pi", 3.141592653589793);
            ConstantDict.Add("e", 2.718281828);
            ConstantDict.Add("phi", 1.61803398874);
        }
        /// <summary>
        /// checks if a string is declared in the the dictionary of constants
        /// and in that case retreives the parameter
        /// </summary>
        /// <param name="Key">Key string to check</param>
        /// <param name="RetVal">storage for constant if found</param>
        /// <returns>True if constant was found, else False</returns>
        public bool TryGetValue(string Key, out double? RetVal)
        {
            return this.ConstantDict.TryGetValue(Key.ToLower(), out RetVal);
        }
    }
}

