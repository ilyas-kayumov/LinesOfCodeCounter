namespace LinesOfCodeCounter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var parser = new CommandLineArgumentsParser(args);
            var printer = new Printer();
            var validator = new ArgumentsValidator();

            NotRunReason reason;

            if (validator.ShouldRunCounter(parser, out reason))
            {
                var path = parser.GetPath();
                var pathType = PathTypeDetection.GetPathType(path);
                var fileExtensions = parser.GetFileExtensions();
                var linesCounter = new PathLinesCounter(pathType, fileExtensions);

                var count = linesCounter.GetCount(path);

                printer.PrintLinesOfCode(count);
            }
            else
            {
                printer.Print(reason, parser);
            }
        }
    }
}
