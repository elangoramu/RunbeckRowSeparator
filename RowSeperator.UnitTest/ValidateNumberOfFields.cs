using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RowSeperator.UnitTest
{
    [TestClass]
    public class ValidateNumberOfFields
    {
        [TestMethod]
        public void GreaterThanZero()
        {
            UserInput userInput = new UserInput();
            bool methodResult;
            bool actualResult = true;
            methodResult = userInput.ValidateInputNumberOfFields("3");
            Assert.AreEqual(methodResult, actualResult);
        }

        [TestMethod]
        public void EqualToZero()
        {
            UserInput userInput = new UserInput();
            bool methodResult;
            bool actualResult = true;
            methodResult = userInput.ValidateInputNumberOfFields("0");
            Assert.AreEqual(methodResult, actualResult);
        }

        [TestMethod]
        public void LessThanZero()
        {
            UserInput userInput = new UserInput();
            bool methodResult;
            bool actualResult = false;
            methodResult = userInput.ValidateInputNumberOfFields("-1");
            Assert.AreEqual(methodResult, actualResult);
        }

        [TestMethod]
        public void Null()
        {
            UserInput userInput = new UserInput();
            bool methodResult;
            bool actualResult = false;
            methodResult = userInput.ValidateInputNumberOfFields(null);
            Assert.AreEqual(methodResult, actualResult);
        }

        [TestMethod]
        public void Empty()
        {
            UserInput userInput = new UserInput();
            bool methodResult;
            bool actualResult = false;
            methodResult = userInput.ValidateInputFileType("");
            Assert.AreEqual(methodResult, actualResult);
        }

        [TestMethod]
        public void Blank()
        {
            UserInput userInput = new UserInput();
            bool methodResult;
            bool actualResult = false;
            methodResult = userInput.ValidateInputNumberOfFields(" ");
            Assert.AreEqual(methodResult, actualResult);
        }
    }
}
