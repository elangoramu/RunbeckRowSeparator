using System;
using System.IO;

namespace RowSeperator
{
    public class UserInput
    {
        public string FileName { get; set; }
        public string Seperator { get; set; }
        public int NumberOfFields { get; set; }

        public void Init()
        {
            ConsoleOut.PrintInfoMessage("+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-++-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-++-+-+");
            Console.WriteLine("Row Seperator");
            Console.WriteLine("Input: File (.txt or .dat)");
            Console.WriteLine("Output: 2 Files (.txt)");
            Console.WriteLine("\tFile 1 Contains the records that match the number of fields entered");
            Console.WriteLine("\tFile 2 Contains the records that do not have the number of fields");

            GetUserInput();
        }
        private void GetUserInput()
        {
            GetUserInputFileName();
            GetUserInputFileType();
            GetUserInputNumberOfFields();
        }

        private void GetUserInputFileName()
        {
            string line = "";
            bool valid = false;

            do
            {
                FileName = null;  //Set FileName to null - to avoid previous values

                Console.WriteLine("");
                Console.WriteLine("*********************************************");
                Console.WriteLine("[type 'quit' to exit]");
                Console.WriteLine("*********************************************");

                Console.Write("File Location: ");
                line = Console.ReadLine().Trim();
                line = string.IsNullOrEmpty(line) ? "" : line;

                valid = ValidateInputFileName(line);

                if(valid)
                {
                    FileName = line;
                }
            } while (!valid);
        }
        private void GetUserInputFileType()
        {
            string line = "";
            bool valid = false;

            do
            {
                Seperator = null;  //Set Seperator to null - to avoid previous values

                Console.Write("File Format [1] CSV or [2] Tab Seperated: ");
                line = Console.ReadLine().Trim();
                line = string.IsNullOrEmpty(line) ? "" : line;

                valid = ValidateInputFileType(line);

                if (valid)
                {
                    switch (line)
                    {
                        case "1":
                            Seperator = ",";
                            break;

                        case "2":
                            Seperator = "\t";
                            break;
                        default:
                            break;
                    }
                }
            } while (!valid);
        }

        private void GetUserInputNumberOfFields()
        {
            string line = "";
            bool valid = false;

            do
            {
                NumberOfFields = -1;  //Set NumberOfFields to (-1) - to avoid previous values

                Console.Write("Number of Fields per Record: ");
                
                line = Console.ReadLine().Trim();
                line = string.IsNullOrEmpty(line) ? "" : line;

                valid = ValidateInputNumberOfFields(line);

                if (valid)
                {
                    NumberOfFields = int.Parse(line);
                }
            } while (!valid);
        }

        private void ValidateInput(string input)
        {
            if (input == null)
                return;

            if (input.Trim().ToUpper() == "QUIT")
            {
                Environment.Exit(0);
            }
        }

        public bool ValidateInputFileName(string fileName)
        {
            ValidateInput(fileName);
            FileInfo fileInfo = null;
            bool valid = false;

            if (fileName != null && fileName.Length > 0)
            {
                try
                {
                    fileInfo = new FileInfo(fileName);

                    valid = fileInfo.Exists;
                }
                catch (Exception)
                {
                    
                }

                if (!valid)
                {
                    ConsoleOut.PrintErrorMessage(string.Format("Error - File Not Found..! --> [{0}]", fileName));
                }
            }
            else
            {
                ConsoleOut.PrintErrorMessage("Error - Enter a File Name!");
            }

            return valid;
        }

        public bool ValidateInputFileType(string fileType)
        {
            bool valid = false;
            ValidateInput(fileType);

            switch (fileType)
            {
                case "1":
                case "2":
                    valid = true;
                    break;
                default:
                    break;
            }

            if (!valid)
            {
                ConsoleOut.PrintErrorMessage("Error Re-Enter a valid File Format.");
            }

            return valid;
        }
        public bool ValidateInputNumberOfFields(string numberOfFields)
        {
            bool valid = false;
            int convertedInt = -1;

            ValidateInput(numberOfFields);

            valid = int.TryParse(numberOfFields, out convertedInt);

            if (valid)
            {
                if (convertedInt < 0)
                {
                    ConsoleOut.PrintErrorMessage("Error Re-Enter a valid Number of Fields per record Greater than or Equal to zero (0).");
                    valid = false;
                }
            }
            else
            {
                ConsoleOut.PrintErrorMessage("Error Re-Enter a valid Number of Fields per record.");
            }

            return valid;
        }
    }
}
