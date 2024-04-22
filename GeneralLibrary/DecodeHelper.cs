using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace GeneralLibrary
{
    public static class DecodeHelper
    {
        // I will just contain all code in the class


        /// <summary>
        /// Sanity check that this is a valid string
        /// </summary>
        /// <param name="inputString">string to check</param>
        /// <returns>True if this string can be processed</returns>
        public static bool SanityCheckInput(string inputString)
        {
            if(string.IsNullOrEmpty(inputString)) return false;


            // Ensure the string consists only of numbers, +, /, * and . otherwise this is not a valid string
            string pattern = @"^[0-9\+\-\*/\.]+$";

            Regex regex = new Regex(pattern);


            return regex.IsMatch(inputString);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static double GetResult(string inputString)
        {
            // Split string by non numberical value for processing
            List<string> splitString = SplitInput(inputString);



            double result = 0.0;

            return result;
        }


        /// <summary>
        /// Splits a string by / * + - 
        /// </summary>
        /// <param name="inputString">string to split</param>
        /// <returns>list containing individual elements</returns>
        public static List<string> SplitInput(string inputString)
        {


            return new List<string>();
        }


    }
}
