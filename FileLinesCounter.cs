using System.IO;

namespace LinesOfCodeCounter
{
    public class FileLinesCounter : ILinesCounter
    {
        public int GetCount(string path)
        {
            var count = 0;

            using (var stream = File.OpenRead(path))
            using (var reader = new StreamReader(stream))
            {
                int c;
                while ((c = reader.Read()) != -1)
                {
                    if (c == '\n')
                    {
                        count++;
                    }
                }
            }

            return count;
        }
    }
}
