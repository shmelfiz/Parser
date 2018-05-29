using System;
using System.Linq;
using System.Text;

using GufoMeParser.Parsers.Interfaces;
using HtmlAgilityPack;

namespace GufoMeParser.Parsers.EnAcademic.Classes
{
    public class EnAcademicParser : IParser
    {
        public string MainUrl => "http://terms_en.enacademic.com/2205";

        public string StockUrl => "http://terms_en.enacademic.com/";

        public string GetParsedTxt(string url)
        {
            var parsedTxtDirty = GetWebPage(url)
                //.DocumentNode.SelectNodes("//meta[@name='Description']")
                .DocumentNode.SelectNodes("//dd")
                //.Select(x => x.GetAttributeValue("Content", "false"));
                .Select(x => x.InnerText);

            var parsedText = new StringBuilder();

            foreach (var row in parsedTxtDirty)
            {
                parsedText.AppendLine(row);
            }

            return parsedText.ToString();
        }

        public string GetNextUrl(string currentUrl)
        {
            if (currentUrl.Contains("47432"))
            {
                return "Complete!";  //костылец
            }

            var parsedUrlDirty = GetWebPage(currentUrl)
                .DocumentNode.SelectNodes("//li[@class='next']/a")
                .Select(x => x.Attributes.FirstOrDefault()).FirstOrDefault();

            var parsedUrl = new StringBuilder();
            parsedUrl.Append("\n");
            parsedUrl.Append(parsedUrlDirty.Value);

            return parsedUrl.ToString();
        }

        public string GetPageName(string url)
        {
            try
            {
                var parsedNameDirty = GetWebPage(url).DocumentNode.SelectNodes("//dt").Select(x => x.InnerText).FirstOrDefault();

                var parsedName = new StringBuilder();
                parsedName.Append(parsedNameDirty);

                return parsedName.ToString();
            }
            catch
            {
                throw new Exception("This ip was banned! Wait for 10 minutes and try again from last link in \"Links.txt\".");
            }
        }

        private HtmlDocument GetWebPage(string url)
        {
            var web = new HtmlWeb();
            var page = web.Load(url);

            return page;
        }

        public string GetParsedHtml(string url)
        {
            var web = new HtmlWeb();
            var page = web.Load(url);
            var parsedHtml = new StringBuilder();

            var parsedHtmlSplitted = page.DocumentNode
                .SelectNodes("//dd")
                .Select(x => x.OuterHtml);

            foreach (string parsedNode in parsedHtmlSplitted)
            {
                parsedHtml.Append(parsedNode);
            }

            return parsedHtml.ToString(); ;
        }
    }
}
