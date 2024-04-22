using GeneralLibrary;

namespace DecodeTestMSTtest
{
    [TestClass]
    public class DecodeTests
    {
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
    }
}