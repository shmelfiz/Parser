using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GufoMeParser.FileSaving
{
    class FileSaver : IFileSaver
    {
        public Task Save(string text, string name)
        {
            return WriteTextAsync(GetPath(name), text);
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

        private string GetPath(string name)
        {
            var SavingDirectory = Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\SavedFiles");
            var path = new StringBuilder();
            path.Append(SavingDirectory);
            path.Append("\\");
            path.Append(name);
            path.Append(".txt");

            return path.ToString();
        }
    }
}
