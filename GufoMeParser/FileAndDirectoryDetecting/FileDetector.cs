using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GufoMeParser.FileAndDirectoryDetecting
{
    public class FileDetector
    {
        public static string GetLastFileName(string directoryPath)
        {
            var filesPaths = Directory.GetFiles(directoryPath);

            if(filesPaths.Count() == 0)
            {
                return string.Empty;
            }

            Dictionary<string, DateTime> files = new Dictionary<string, DateTime>();

            foreach(string path in filesPaths)
            {
                files.Add(Path.GetFileName(path), File.GetCreationTime(path));
            }

            files = files.OrderBy(x => x.Value.Millisecond).ToDictionary(x => x.Key, x => x.Value);

            return files.Last().Key.Replace(".txt", "");
        }
    }
}
