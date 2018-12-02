using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace test_api.helpelrs
{
    public class SplitTextHelpler
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="charSeparator"></param>
        /// <param name="strToSplit"></param>
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