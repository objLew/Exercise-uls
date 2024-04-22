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






    }
}