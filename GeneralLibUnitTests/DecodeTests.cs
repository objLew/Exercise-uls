using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GeneralLibUnitTests
{
    /// <summary>
    /// I'll test all functions here although this could be split for easier maintenance 
    /// All tests will follow AAA standard (arrange, act, assert)
    /// </summary>
    [TestClass]
    public class DecodeTests
    {
        [TestMethod]
        public void SanityCheckInvalidCharacter()
        {
            // Arrange
            string inputString = "2.5*3p";

            // Act
            bool result = DecodeHelper.SanityCheck(inputString);

            // Assert
            Assert.IsFalse(result);
        }



    }
}
