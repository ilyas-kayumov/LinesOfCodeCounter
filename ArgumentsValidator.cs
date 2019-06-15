namespace LinesOfCodeCounter
{
    public class ArgumentsValidator
    {
        public bool ShouldRunCounter(CommandLineArgumentsParser parser, out NotRunReason notRunReason)
        {
            notRunReason = NotRunReason.None;

            if (!parser.IsValidNumberOfArguments())
            {
                notRunReason = NotRunReason.InvalidNumberOfArguments;
                return false;
            }

            if (parser.IsHelp())
            {
                notRunReason = NotRunReason.Help;
                return false;
            }

            var path = parser.GetPath();

            var pathType = PathTypeDetection.GetPathType(path);

            if (pathType == PathType.Undefined)
            {
                notRunReason = NotRunReason.PathDoesNotExist;
                return false;
            }

            return true;
        }
    }
}