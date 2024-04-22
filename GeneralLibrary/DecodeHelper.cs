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


            // now that we have the split string we can step through highest 'DMAS' as assuming no brackets/indicies from spec
            // meaning division and multiplication are same level, addition and subtration are the same level.

            // As there are finite steps I will step through and do DM calculations and then AS calculations
            // note:
            //      one alternative can be keeping a stack and popping in order but this may be harder for another dev to understand

            




            double result = 0.0;

            return result;
        }


        private static List<string> RunSpecifiedOperations(List<string> splitString, List<string> operators)
        {
            var result = new List<string>();

            List<string> resultOfDivisionMultiplcation = new List<string>();

            for (int i = 1; i < splitString.Count; i++)
            {
                string currentPos = splitString[i];

                // first and last will definitely be numbers as we have done sanity check so can just add these then continue
                if (i == 0 || i == splitString.Count() - 1)
                {
                    resultOfDivisionMultiplcation.Add(currentPos);
                    continue;
                }


                string posMinusOne = splitString[i];
                string posPlusOne = splitString[i];

                // reset temporary variables
                double firstVal = 0.0;
                double secondVal = 0.0;
                double tempResult = 0.0;


                foreach (var numericalOperator in operators)
                {
                    // if this is an operator, do the calculation
                    if(currentPos == numericalOperator)
                    {
                        firstVal = double.Parse(posMinusOne);
                        secondVal = double.Parse(posPlusOne);

                        var resultOfOperation = PerformCalulation(numericalOperator, firstVal, secondVal);
                    }
                }

            }



            return result;
        }



        /// <summary>
        /// Takes operator and value and return the result
        /// </summary>
        /// <param name="numericalOperator">the mathmatical oeprator</param>
        /// <param name="a">double value 1</param>
        /// <param name="b">double value 2</param>
        /// <returns>result of a (operator) b</returns>
        public static double PerformCalulation(string numericalOperator, double a, double b)
        {
            double result = 0.0;

            switch (numericalOperator)
            {
                case "/":
                    result = a / b;
                    break;
                case "*":
                    result = a * b;
                    break;
                case "+":
                    result = a + b;
                    break;
                case "-":
                    result = a - b;
                    break;
                default:
                    throw new NotImplementedException();
            }

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
