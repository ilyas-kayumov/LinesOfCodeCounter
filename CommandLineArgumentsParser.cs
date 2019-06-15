using System;
using System.Collections.Generic;
using System.Linq;

namespace LinesOfCodeCounter
{
    public class CommandLineArgumentsParser
    {
        private readonly string[] args;

        public CommandLineArgumentsParser(string[] args)
        {
            this.args = args;
        }

        public bool IsValidNumberOfArguments()
        {
            return args.Length != 0;
        }

        public bool IsHelp()
        {
            if (!IsValidNumberOfArguments())
            {
                throw new InvalidOperationException();
            }

            var helpArgs = new [] { "help", "-help", "h", "-h" };

            if (helpArgs.Contains(args[0]))
            {
                return true;
            }

            return false;
        }

        public string GetPath()
        {
            if (!IsValidNumberOfArguments())
            {
                throw new InvalidOperationException();
            }

            return args[0];
        }

        public IEnumerable<string> GetFileExtensions()
        {
            if (!IsValidNumberOfArguments())
            {
                throw new InvalidOperationException();
            }

            var fileExtensions = new List<string>();

            for (var i = 1; i < args.Length; i++)
            {
                fileExtensions.Add(args[i]);
            }

            return fileExtensions;
        }
    }
}
