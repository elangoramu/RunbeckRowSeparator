using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RowSeperator.UnitTest
{
    [TestClass]
    public class ValidateFileName
    {
        [TestMethod]
        public void Folder()
        {
            UserInput userInput = new UserInput();
            bool methodResult;
            bool actualResult = false;
            methodResult = userInput.ValidateInputFileName(@"C:\Work\Runbeck\RowSeperator\Data");
            Assert.AreEqual(methodResult, actualResult);
        }

        [TestMethod]
        public void FileDoesNotExists()
        {
            UserInput userInput = new UserInput();
            bool methodResult;
            bool actualResult = false;
            methodResult = userInput.ValidateInputFileName(@"C:\Work\Runbeck\RowSeperator\Data\FileDoesNotExists.txt");
            Assert.AreEqual(methodResult, actualResult);
        }

        [TestMethod]
        public void ValidFile()
        {
            UserInput userInput = new UserInput();
            bool methodResult;
            bool actualResult = true;
            methodResult = userInput.ValidateInputFileName(@"C:\Work\Runbeck\RowSeperator\Data\sample.txt");
            Assert.AreEqual(methodResult, actualResult);
        }

        [TestMethod]
        public void Null()
        {
            UserInput userInput = new UserInput();
            bool methodResult;
            bool actualResult = false;
            methodResult = userInput.ValidateInputFileName(null);
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
            methodResult = userInput.ValidateInputFileName(" ");
            Assert.AreEqual(methodResult, actualResult);
        }
    }
}
