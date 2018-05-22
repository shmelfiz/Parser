using System;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GufoMeParser.FileSaving
{
    public class FileSaver : IFileSaver
    {
        private string _parsedTxtPath = Directory.GetCurrentDirectory() + "\\SavedFiles";
        private string _parsedHtmlPath = Directory.GetCurrentDirectory() + "\\SavedFilesHtml";

        public Task Save(string text, string name, int fileType)
        {
            return WriteTextAsync(GetCreatedPath(name, fileType), text);
        }

        private async Task WriteTextAsync(string filePath, string text)
        {
            byte[] encodedText = Encoding.Unicode.GetBytes(text);

            using (FileStream sourceStream = new FileStream(filePath,
                FileMode.Append, FileAccess.Write, FileShare.None,
                bufferSize: 4096, useAsync: true))
            {
                await sourceStream.WriteAsync(encodedText, 0, encodedText.Length);
            };
        }

        private string GetCreatedPath(string name, int fileType)
        {
            switch (fileType)
            {
                case (int)Resources.ParsedTxt:
                    {
                        var savingDirectory = Directory.CreateDirectory(_parsedTxtPath);
                        var path = new StringBuilder();
                        path.Append(savingDirectory);
                        path.Append("\\");
                        path.Append(name);
                        path.Append(".txt");

                        return path.ToString();
                    }
                case (int)Resources.ParsedHtml:
                    {
                        var savingDirectory = Directory.CreateDirectory(_parsedHtmlPath);
                        var path = new StringBuilder();
                        path.Append(savingDirectory);
                        path.Append("\\");
                        path.Append(name);
                        path.Append(".txt");

                        return path.ToString();
                    }
            }
            throw new Exception("U r wrote wrong type of file!");
        }
    }
}
