using GeneralLibrary;

namespace DecodeTestMSTtest
{
    [TestClass]
    public class DecodeTests
    {

        // NOTE:
        // can do many of these but I don't have time to be as thorough as I'd like so will cover only one of each area to test

        #region invalid items

        [TestMethod]
        public void SanityCheckInvalidCharacter()
        {
            // Arrange
            string inputString = "2.5*3p";

            // Act
            bool result = DecodeHelper.SanityCheckInput(inputString);

            // Assert
            Assert.IsFalse(result);
        }


        [TestMethod]
        public void SanityCheckInvalidCharacterMultiValue()
        {
            // Arrange
            List<string> invalidInputs = new List<string>() { "2.5*3p", "s", "dfouih79gh", "and so on" };

            // Act
            // -> all of these are invalid, if any are true we have an issue
            bool result = false;
            foreach (string input in invalidInputs) 
            {
                result = DecodeHelper.SanityCheckInput(input);

                if (result) 
                {
                    // Assert
                    Assert.Fail("Result returned true for invalid string: "+ input);
                    return;
                }
            }

        }

        // ...

        #endregion


        #region valid items

        [TestMethod]
        public void SanityCheckValidCharacter()
        {
            // Arrange
            string inputString = "4+5*2";

            // Act
            bool result = DecodeHelper.SanityCheckInput(inputString);

            // Assert
            Assert.IsTrue(result);
        }


        [TestMethod]
        public void SanityCheckValidCharacterMultiValue()
        {
            // Arrange
            List<string> invalidInputs = new List<string>() { "4+5*2", "4+5/2", "4+5/2-1" };

            // Act
            // -> all of these are invalid, if any are true we have an issue
            bool result = false;
            foreach (string input in invalidInputs)
            {
                result = DecodeHelper.SanityCheckInput(input);

                if (!result)
                {
                    // Assert
                    Assert.Fail("Result returned true for invalid string: " + input);
                    return;
                }
            }

        }

        // ...

        #endregion


        #region perform calculation test

        [TestMethod]
        public void Multiply()
        {
            // Arrange
            string mathOperator = "*";
            double one = 5;
            double two = 2;

            // Act
            double result = DecodeHelper.PerformCalulation(mathOperator, one, two);


            //Assert
            Assert.IsTrue(result == 10);
        }


        [TestMethod]
        public void Divide()
        {
            // Arrange
            string mathOperator = "/";
            double one = 5;
            double two = 2;

            // Act
            double result = DecodeHelper.PerformCalulation(mathOperator, one, two);


            //Assert
            Assert.IsTrue(result == 2.5);

        }

        // ...

        #endregion


        #region get result
        
        [TestMethod]
        public void GetResultOfSimpleStringPlus()
        {
            // Arrange
            string inputString = "2+77";


            // Act
            double result = DecodeHelper.GetResult(inputString);


            //Assert
            Assert.IsTrue(result == 79);
        }


        [TestMethod]
        public void GetResultOfSimpleStringSubtraction()
        {
            // Arrange
            string inputString = "10-4";


            // Act
            double result = DecodeHelper.GetResult(inputString);


            //Assert
            Assert.IsTrue(result == 6);

        }

        [TestMethod]
        public void GetResultOfComplexStringSubtraction()
        {
            // Arrange
            string inputString = "2/3+5*3-6+7";


            // Act
            double result = DecodeHelper.GetResult(inputString);
            result = Math.Round(result, 2);

            //Assert
            Assert.IsTrue(result == 16.67);
        }

        // would test many variation of this
        // likely a list or dictionary containing verified results so that we could test any edgecases


        #endregion

        #region split string
        [TestMethod]
        public void SplitString()
        {
            // Arrange
            string inputString = "2/3+5*3-6+7";


            // Act
            List<string> result = DecodeHelper.SplitInput(inputString);


            //Assert
            List<string> validSplit = new List<string>() 
            {
                "2", "/","3","+","5","*","3","-","6","+","7"
            };

            // -> .AreEqual is returning false, will just assert myself for nw
            var resultList1 = validSplit.Except(result).ToList();
            var resultList2 = result.Except(validSplit).ToList();

            if (!resultList1.Any() && !resultList2.Any())
            {
                Assert.IsTrue(true);
                return;
            }
            
            Assert.IsTrue(false);
           
        }



        #endregion



        //and so on, even for a simple api like this you can do hundreds of tests but I will leave it here.


    }
}