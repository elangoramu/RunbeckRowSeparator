using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RowSeperator
{
    public class FileSeperator
    {
        public UserInput UserInput { get; set; }
        private List<string> Records { get; set; }

        public void StartProcess()
        {          
            Console.WriteLine("Start Processing File...");

            if(CanProcess())
            {
                ReadFile();
                WriteFile();
            }
        }

        private void ReadFile()
        {
            string fileContent = null;

            Console.WriteLine("Reading File: " + UserInput.FileName);

            try
            {
                fileContent = File.ReadAllText(UserInput.FileName);
                Records = new List<string>(fileContent.Trim().Split("\r\n"));
            }
            catch (Exception ex)
            {
                ConsoleOut.PrintErrorMessage("Cannot read File. " + ex.Message);
            }
        }
        
        private void WriteFile()
        {
            if (Records.Count > 1)
            {
                ConsoleOut.PrintInfoMessage(String.Format("Writing File... Match On -- Delimiter: [{0}] Number of Fields: [{1}]",UserInput.Seperator == "," ? "Comma":"Tab",UserInput.NumberOfFields));

                Records.RemoveAt(0);    //Remove file Line, as it is the header

                var matchedRecords = from record in Records where record.Split(UserInput.Seperator).Length == UserInput.NumberOfFields select record;
                var unMatchedRecords = from record in Records where record.Split(UserInput.Seperator).Length != UserInput.NumberOfFields select record;

                string fileExtension = new FileInfo(UserInput.FileName).Extension;

                string matchedFileName = UserInput.FileName.Replace(fileExtension, "_") + @"Output_MatchedRecords.txt";
                string unMatchedFileName = UserInput.FileName.Replace(fileExtension, "_") + @"Output_UnMatchedRecords.txt";

                File.Delete(matchedFileName);       //Delete File, if exists
                File.Delete(unMatchedFileName);     //Delete File, if exists

                if (matchedRecords.Count() > 0)     //Create File for Matched Records
                {
                    ConsoleOut.PrintSuccessMessage("  Write Matched File: " + matchedFileName + " # of Records: " + matchedRecords.Count());
                    File.AppendAllLines(matchedFileName, matchedRecords);
                }
                else
                {
                    ConsoleOut.PrintInfoMessage("  Skip Writing Matched File --> Zero Matched Records");
                }

                if (unMatchedRecords.Count() > 0)     //Create File for UnMatched Records
                {
                    ConsoleOut.PrintSuccessMessage("  Write UnMatched File: " + unMatchedFileName + " # of Records: " + unMatchedRecords.Count());
                    File.AppendAllLines(unMatchedFileName, unMatchedRecords);
                }
                else
                {
                    ConsoleOut.PrintInfoMessage("  Skip Writing UnMatched File --> Zero UnMatched Records");
                }
            }
            else
            {
                ConsoleOut.PrintErrorMessage("  File Does not contain any data");
            }
        }

        public bool CanProcess()
        {
            bool canProcess = true;

            Console.Write("Validate File...");

            canProcess &= File.Exists(UserInput.FileName);
            canProcess &= !string.IsNullOrEmpty(UserInput.Seperator);
            canProcess &= (UserInput.NumberOfFields > -1);

            Console.WriteLine(canProcess ? "Passed" : "Failed");

            return canProcess;
        }
    }
}