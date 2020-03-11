using System;
using System.IO;

namespace RowSeperator
{
    class Program
    {
        static void Main(string[] args)
        {
            init();
            //BulkTest();
        }

        static void init()
        {
            UserInput userInput = new UserInput();
            FileSeperator fileSeperator = new FileSeperator();

            do
            {
                userInput.Init();
                fileSeperator.UserInput = userInput;

                fileSeperator.StartProcess();
            } while (true); //Repeat until user inputs 'quit' or exits the application
        }

        static void BulkTest()
        {
            UserInput userInput = new UserInput();
            FileSeperator fileSeperator = new FileSeperator();

            fileSeperator.UserInput = userInput;

            userInput.Seperator = ",";
            userInput.NumberOfFields = 3;
            userInput.FileName = @"C:\Work\Runbeck\RowSeperator\Data\sample.txt";
            fileSeperator.StartProcess();

            userInput.FileName = @"C:\Work\Runbeck\RowSeperator\Data\empty.txt";
            fileSeperator.StartProcess();

            userInput.FileName = @"C:\Work\Runbeck\RowSeperator\Data\exactNumberOfFields.txt";
            fileSeperator.StartProcess();

            userInput.FileName = @"C:\Work\Runbeck\RowSeperator\Data\onlyHeader.txt";
            fileSeperator.StartProcess();

            userInput.Seperator = "\t";
            userInput.FileName = @"C:\Work\Runbeck\RowSeperator\Data\tabSample.txt";
            fileSeperator.StartProcess();
        }
    }

    public static class ConsoleOut
    {
        public static void PrintErrorMessage(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg);
            Console.ResetColor();
        }

        public static void PrintSuccessMessage(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(msg);
            Console.ResetColor();
        }

        public static void PrintInfoMessage(string msg)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(msg);
            Console.ResetColor();
        }
    }
}