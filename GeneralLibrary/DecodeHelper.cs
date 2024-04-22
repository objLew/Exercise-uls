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

            List<string> resultOfDM = RunSpecifiedOperations(splitString, "*", "/");
            List<string> resultString = RunSpecifiedOperations(resultOfDM, "+", "-");

            // the resultString should only contain the final answer, 

            if (resultString.Count != 1)
                throw new Exception("string malformed");

            double result = double.Parse(resultString.First());


            return result;
        }


        private static List<string> RunSpecifiedOperations(List<string> splitString, params string[] operators)
        {
            List<string> result = new List<string>();

            int lastOperation = -100;
            for (int i = 1; i < splitString.Count-1; i++)
            {
                if (i >= splitString.Count) break;

                string currentPos = splitString[i];


                string posMinusOne = splitString[i-1];
                string posPlusOne = splitString[i+1];
                //if position ahead contains operator, skip
                if (operators.Contains(posPlusOne)) continue;


                // reset temporary variables
                double firstVal = 0.0;
                double secondVal = 0.0;

                //if this is an operator, perform the calculation
                bool operatorMatched = false;
                foreach (var numericalOperator in operators)
                {
                    // if this is an operator, do the calculation
                    if(currentPos == numericalOperator)
                    {
                        // pop list if we added this result previously (we are using a result we just made)
                        if (lastOperation == i - 2)
                        {
                            posMinusOne = result[result.Count() - 1];
                            result.RemoveAt(result.Count() - 1);
                        }

                        firstVal = double.Parse(posMinusOne);
                        secondVal = double.Parse(posPlusOne);

                        var resultOfOperation = PerformCalulation(numericalOperator, firstVal, secondVal);
                        result.Add(resultOfOperation.ToString());

                        
                        //update last operation
                        lastOperation = i;

                        //step ahead one (plus loop adds one) so that we don't interact any numbers we have already calculated
                        i++;
                        operatorMatched = true;

                        break;
                    }
                }

                if (operatorMatched)
                    continue;

                // if this is a number just add to the list
                result.Add(currentPos);

                //if not calculation at the end, add the last item.
                if(i == splitString.Count-2)
                    result.Add(splitString[splitString.Count - 1]); 
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
            string pattern = @"(\+|\-|\*|\/)";

            // Update to regex so that we can keep the operators
            var splits = Regex.Split(inputString, pattern).ToList();

            return splits;
        }


    }
}
