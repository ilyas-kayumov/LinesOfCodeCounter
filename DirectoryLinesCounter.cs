using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LinesOfCodeCounter
{
    public class DirectoryLinesCounter : ILinesCounter
    {
        private readonly FileLinesCounter fileLinesCounter;
        private readonly IEnumerable<string> fileExtensions;

        public DirectoryLinesCounter(FileLinesCounter fileLinesCounter, IEnumerable<string> fileExtensions)
        {
            this.fileLinesCounter = fileLinesCounter;
            this.fileExtensions = fileExtensions;
        }

        public int GetCount(string path)
        {
            var count = GetLinesCountFromDirectories(path);

            count += GetLinesCountFromFiles(path);

            return count;
        }

        private int GetLinesCountFromDirectories(string path)
        {
            var count = 0;

            var directoryPaths = Directory.GetDirectories(path);

            foreach (var directoryPath in directoryPaths)
            {
                count += GetCount(directoryPath);
            }

            return count;
        }

        private int GetLinesCountFromFiles(string path)
        {
            IEnumerable<string> filePaths = Directory.GetFiles(path);

            if (fileExtensions.Count() > 0)
            {
                filePaths = GetFilepathsWithExtensions(filePaths);
            }

            var count = 0;

            foreach (var filePath in filePaths)
            {
                count += fileLinesCounter.GetCount(filePath);
            }

            return count;
        }

        private IEnumerable<string> GetFilepathsWithExtensions(IEnumerable<string> filePaths)
        {
            foreach (var filePath in filePaths)
            {
                var splitedPath = filePath.Split('.');

                if (splitedPath.Length > 1)
                {
                    var extension = splitedPath[1];

                    if (fileExtensions.Contains(extension))
                    {
                        yield return filePath;
                    }
                }
            }
        }
    }
}
