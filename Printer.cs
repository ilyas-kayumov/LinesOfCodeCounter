using System;

namespace LinesOfCodeCounter
{
    public class Printer
    {
        public const string InvalidNumberOfArguments = "Invalid number of arguments";
        public const string Help = 
        @"LinesOfCodeCounter usage:
Arguments: [path-to-existing-file-or-directory] [extensions]
Example of use (file): path/to/existing/file/or/directory cs cpp
Example of use (directory): path/to/existing/file.cs";

        public void PrintLinesOfCode(int count)
        {
            Print($"Lines of code: {count}");
        }

        public void Print(NotRunReason notRunReason, CommandLineArgumentsParser parser)
        {
                switch (notRunReason)
                {
                    case NotRunReason.InvalidNumberOfArguments:
                        Print(InvalidNumberOfArguments);
                        break;
                    case NotRunReason.PathDoesNotExist:
                        PrintPathDoesNotExist(parser.GetPath());
                        break;
                    case NotRunReason.None:
                        throw new ArgumentException(nameof(notRunReason));
                }

                Print(Help);
        }

        private void PrintPathDoesNotExist(string path)
        {
            Print($@"Path: ""{path}"" does not exist");
        }

        public void Print(string str)
        {
            Console.WriteLine(str);
        }
    }
}
