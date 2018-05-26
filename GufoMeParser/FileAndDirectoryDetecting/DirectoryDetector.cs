using GufoMeParser.Parsers.GufoMe.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;

namespace GufoMeParser.FileAndDirectoryDetecting
{
    public static class DirectoryDetector
    {
        public static void CheckCurrentDirectory(IParser parser, List<string> urls)
        {
            if (IsExists((int)Resources.ParsedTxt))
            {
                urls.Add(parser.StockUrl + FileDetector.GetLastFileName(GetPath((int)Resources.ParsedTxt)));
            }
        }

        private static bool IsExists(int fileType)
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

