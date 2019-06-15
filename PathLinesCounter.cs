using System;
using System.Collections.Generic;

namespace LinesOfCodeCounter
{
    public class PathLinesCounter : ILinesCounter
    {
        private readonly PathType pathType;
        private readonly IEnumerable<string> fileExtensions;

        public PathLinesCounter(PathType pathType, IEnumerable<string> fileExtensions)
        {
            this.pathType = pathType;
            this.fileExtensions = fileExtensions;
        }

        public int GetCount(string path)
        {
            ILinesCounter linesCounter;

            if (pathType == PathType.File)
            {
                linesCounter = new FileLinesCounter();
            }
            else if (pathType == PathType.Directory)
            {
                linesCounter = new DirectoryLinesCounter(new FileLinesCounter(), fileExtensions);
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(pathType));
            }

            return linesCounter.GetCount(path);
        }
    }
}
