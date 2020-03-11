using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RowSeperator.UnitTest
{
    [TestClass]
    public class ValidateFileSeperator
    {
        [TestMethod]
        public void PostiveInput()
        {
            UserInput userInput = new UserInput();
            RowSeperator.FileSeperator fileSeperator = new RowSeperator.FileSeperator();

            userInput.FileName = @"C:\Work\Runbeck\RowSeperator\Data\sample.txt";
            userInput.Seperator = ",";
            userInput.NumberOfFields = 3;

            fileSeperator.UserInput = userInput;

            bool methodResult;
            bool actualResult = true;

            methodResult = fileSeperator.CanProcess();
            Assert.AreEqual(methodResult, actualResult);
        }

        [TestMethod]
        public void FileName_Incorrect()
        {
            UserInput userInput = new UserInput();
            RowSeperator.FileSeperator fileSeperator = new RowSeperator.FileSeperator();

            userInput.FileName = @"C:\Work\Runbeck\RowSeperator\Data\";
            userInput.Seperator = ",";
            userInput.NumberOfFields = 3;

            fileSeperator.UserInput = userInput;

            bool methodResult;
            bool actualResult = false;

            methodResult = fileSeperator.CanProcess();
            Assert.AreEqual(methodResult, actualResult);
        }

        [TestMethod]
        public void Seperator_Incorrect()
        {
            UserInput userInput = new UserInput();
            RowSeperator.FileSeperator fileSeperator = new RowSeperator.FileSeperator();

            userInput.FileName = @"C:\Work\Runbeck\RowSeperator\Data\input.txt";
            userInput.Seperator = "";
            userInput.NumberOfFields = 3;

            fileSeperator.UserInput = userInput;

            bool methodResult;
            bool actualResult = false;

            methodResult = fileSeperator.CanProcess();
            Assert.AreEqual(methodResult, actualResult);
        }

        [TestMethod]
        public void NumberOfFields_LessThanZero()
        {
            UserInput userInput = new UserInput();
            RowSeperator.FileSeperator fileSeperator = new RowSeperator.FileSeperator();

            userInput.FileName = @"C:\Work\Runbeck\RowSeperator\Data\input.txt";
            userInput.Seperator = ",";
            userInput.NumberOfFields = -1;

            fileSeperator.UserInput = userInput;

            bool methodResult;
            bool actualResult = false;

            methodResult = fileSeperator.CanProcess();
            Assert.AreEqual(methodResult, actualResult);
        }

        [TestMethod]
        public void NumberOfFields_EqualToZero()
        {
            UserInput userInput = new UserInput();
            RowSeperator.FileSeperator fileSeperator = new RowSeperator.FileSeperator();

            userInput.FileName = @"C:\Work\Runbeck\RowSeperator\Data\sample.txt";
            userInput.Seperator = ",";
            userInput.NumberOfFields = 0;

            fileSeperator.UserInput = userInput;

            bool methodResult;
            bool actualResult = true;

            methodResult = fileSeperator.CanProcess();
            Assert.AreEqual(methodResult, actualResult);
        }
    }
}
