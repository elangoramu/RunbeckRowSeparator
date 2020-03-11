using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RowSeperator.UnitTest
{
    [TestClass]
    public class ValidateInputFileType
    {
        [TestMethod]
        public void EqualToZero()
        {
            UserInput userInput = new UserInput();
            bool methodResult;
            bool actualResult = false;
            methodResult = userInput.ValidateInputFileType("0");
            Assert.AreEqual(methodResult, actualResult);
        }

        [TestMethod]
        public void LessThanZero()
        {
            UserInput userInput = new UserInput();
            bool methodResult;
            bool actualResult = false;
            methodResult = userInput.ValidateInputFileType("0");
            Assert.AreEqual(methodResult, actualResult);
        }

        [TestMethod]
        public void EqualToOne()
        {
            UserInput userInput = new UserInput();
            bool methodResult;
            bool actualResult = true;
            methodResult = userInput.ValidateInputFileType("1");
            Assert.AreEqual(methodResult, actualResult);
        }

        [TestMethod]
        public void EqualToTwo()
        {
            UserInput userInput = new UserInput();
            bool methodResult;
            bool actualResult = true;
            methodResult = userInput.ValidateInputFileType("2");
            Assert.AreEqual(methodResult, actualResult);
        }

        [TestMethod]
        public void Null()
        {
            UserInput userInput = new UserInput();
            bool methodResult;
            bool actualResult = false;
            methodResult = userInput.ValidateInputFileType(null);
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
            methodResult = userInput.ValidateInputFileType(" ");
            Assert.AreEqual(methodResult, actualResult);
        }
    }
}
