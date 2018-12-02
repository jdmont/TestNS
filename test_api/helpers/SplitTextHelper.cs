using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace test_api.helpelrs
{
    /// <summary>
    /// Helper for split strings
    /// </summary>
    public class SplitTextHelper
    {
        /// <summary>
        /// Splits the string based on the character separator, also, 
        /// replace the characters '\r\n' to '\n' for plain text
        /// </summary>
        /// <param name="charSeparator">Character to split the string</param>
        /// <param name="strToSplit">String that will be splitted</param>
        /// <returns></returns>
        public static  List<string> splitStringLines(char charSeparator, string strToSplit)
        {
            try
            {                
                if (string.IsNullOrEmpty(charSeparator.ToString()) || string.IsNullOrEmpty(strToSplit))
                    throw new Exception("No data");
                return strToSplit.Replace("\r\n", "\n").Split(charSeparator).ToList();                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}