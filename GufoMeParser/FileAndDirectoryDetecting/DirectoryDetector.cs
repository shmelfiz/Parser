using System;
using System.IO;

namespace GufoMeParser.FileAndDirectoryDetecting
{
    public static class DirectoryDetector
    {
        public static bool IsExists(int fileType)
        {
            switch (fileType)
            {
                case (int)Resources.ParsedTxt:
                    {
                        var savingDirectory = Directory.GetCurrentDirectory() + "\\SavedFiles";
                        var isExists = Directory.Exists(savingDirectory);

                        return isExists;
                    }
                case (int)Resources.ParsedHtml:
                    {
                        var savingDirectory = Directory.GetCurrentDirectory() + "\\SavedFilesHtml";
                        var isExists = Directory.Exists(savingDirectory);

                        return isExists;
                    }
            }

            throw new Exception("U r wrote wrong type of file!");
        }

        public static string GetPath(int fileType)
        {
            switch (fileType)
            {
                case (int)Resources.ParsedTxt:
                    {
                        var savingDirectory = Directory.GetCurrentDirectory() + "\\SavedFiles";

                        return savingDirectory;
                    }
                case (int)Resources.ParsedHtml:
                    {
                        var savingDirectory = Directory.GetCurrentDirectory() + "\\SavedFilesHtml";

                        return savingDirectory;
                    }
            }
            throw new Exception("U r wrote wrong type of file!");
        }

    }
}

