using System.IO;

namespace Common.Model.Utility
{
    public static class FileReader
    {
        public static string Read(string path)
        {
            return File.ReadAllText(path);
        }
        public static string[] ReadLines(string path)
        {
            return File.ReadAllLines(path);
        }
    }
}
