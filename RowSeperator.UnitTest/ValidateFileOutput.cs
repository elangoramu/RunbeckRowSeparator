using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace RowSeperator.UnitTest
{
    [TestClass]
    public class ValidateFileOutput
    {
        [TestMethod]
        public void CSVSample_CreateBothFiles()
        {
            UserInput userInput = new UserInput();
            RowSeperator.FileSeperator fileSeperator = new RowSeperator.FileSeperator();

            userInput.FileName = @"C:\Work\Runbeck\RowSeperator\Data\sample.txt";
            userInput.Seperator = ",";
            userInput.NumberOfFields = 3;

            fileSeperator.UserInput = userInput;
            fileSeperator.StartProcess();

            string fileExtension = new FileInfo(userInput.FileName).Extension;

            string matchedFileName = userInput.FileName.Replace(fileExtension, "_") + @"Output_MatchedRecords.txt";
            string unMatchedFileName = userInput.FileName.Replace(fileExtension, "_") + @"Output_UnMatchedRecords.txt";

            Assert.AreEqual(File.Exists(matchedFileName), true);
            Assert.AreEqual(File.Exists(unMatchedFileName), true);
        }

        [TestMethod]
        public void TabSample_CreateBothFiles()
        {
            UserInput userInput = new UserInput();
            RowSeperator.FileSeperator fileSeperator = new RowSeperator.FileSeperator();

            userInput.FileName = @"C:\Work\Runbeck\RowSeperator\Data\tabSample.txt";
            userInput.Seperator = "\t";
            userInput.NumberOfFields = 3;

            fileSeperator.UserInput = userInput;
            fileSeperator.StartProcess();

            string fileExtension = new FileInfo(userInput.FileName).Extension;

            string matchedFileName = userInput.FileName.Replace(fileExtension, "_") + @"Output_MatchedRecords.txt";
            string unMatchedFileName = userInput.FileName.Replace(fileExtension, "_") + @"Output_UnMatchedRecords.txt";

            Assert.AreEqual(File.Exists(matchedFileName), true);
            Assert.AreEqual(File.Exists(unMatchedFileName), true);
        }

        [TestMethod]
        public void Empty_NoFiles()
        {
            UserInput userInput = new UserInput();
            RowSeperator.FileSeperator fileSeperator = new RowSeperator.FileSeperator();

            userInput.FileName = @"C:\Work\Runbeck\RowSeperator\Data\empty.txt";
            userInput.Seperator = ",";
            userInput.NumberOfFields = 3;

            fileSeperator.UserInput = userInput;
            fileSeperator.StartProcess();

            string fileExtension = new FileInfo(userInput.FileName).Extension;

            string matchedFileName = userInput.FileName.Replace(fileExtension, "_") + @"Output_MatchedRecords.txt";
            string unMatchedFileName = userInput.FileName.Replace(fileExtension, "_") + @"Output_UnMatchedRecords.txt";

            Assert.AreEqual(File.Exists(matchedFileName), false);
            Assert.AreEqual(File.Exists(unMatchedFileName), false);
        }

        [TestMethod]
        public void exactNumberOfFields_OnlyMatchFile()
        {
            UserInput userInput = new UserInput();
            RowSeperator.FileSeperator fileSeperator = new RowSeperator.FileSeperator();

            userInput.FileName = @"C:\Work\Runbeck\RowSeperator\Data\exactNumberOfFields.txt";
            userInput.Seperator = ",";
            userInput.NumberOfFields = 3;

            fileSeperator.UserInput = userInput;
            fileSeperator.StartProcess();

            string fileExtension = new FileInfo(userInput.FileName).Extension;

            string matchedFileName = userInput.FileName.Replace(fileExtension, "_") + @"Output_MatchedRecords.txt";
            string unMatchedFileName = userInput.FileName.Replace(fileExtension, "_") + @"Output_UnMatchedRecords.txt";

            Assert.AreEqual(File.Exists(matchedFileName), true);
            Assert.AreEqual(File.Exists(unMatchedFileName), false);
        }

        [TestMethod]
        public void OnlyHeader_NoFiles()
        {
            UserInput userInput = new UserInput();
            RowSeperator.FileSeperator fileSeperator = new RowSeperator.FileSeperator();

            userInput.FileName = @"C:\Work\Runbeck\RowSeperator\Data\onlyHeader.txt";
            userInput.Seperator = ",";
            userInput.NumberOfFields = 3;

            fileSeperator.UserInput = userInput;
            fileSeperator.StartProcess();

            string fileExtension = new FileInfo(userInput.FileName).Extension;

            string matchedFileName = userInput.FileName.Replace(fileExtension, "_") + @"Output_MatchedRecords.txt";
            string unMatchedFileName = userInput.FileName.Replace(fileExtension, "_") + @"Output_UnMatchedRecords.txt";

            Assert.AreEqual(File.Exists(matchedFileName), false);
            Assert.AreEqual(File.Exists(unMatchedFileName), false);
        }
    }
}
