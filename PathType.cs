using System.IO;

namespace LinesOfCodeCounter
{
    public enum PathType
    {
        File,
        Directory,
        Undefined
    }

    public static class PathTypeDetection
    {
        public static PathType GetPathType(string path)
        {
            if (File.Exists(path))
            {
                return PathType.File;
            }
            else if (Directory.Exists(path))
            {
                return PathType.Directory;
            }
            else
            {
                return PathType.Undefined;
            }
        }
    }
}
