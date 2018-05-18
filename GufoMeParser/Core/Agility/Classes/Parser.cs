using GufoMeParser.Core.Agility.Interfaces;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GufoMeParser.Core.Agility.Classes
{
    class Parser : IParser
    {
        public string GetParsedTxt(string url)
        {
            var parsedTxtDirty = GetCurrentWebPage(url)
                .DocumentNode.SelectNodes("//p")
                .Select(x => x.InnerText);
            
            var parsedText = new StringBuilder();

            foreach (var row in parsedTxtDirty)
            {
                parsedText.AppendLine(row);
            }

            return parsedText.ToString().Replace("&copy; 2018 Gufo.me","");
        }

        public string GetNextUrl(string currentUrl)
        {
            if(currentUrl.Contains("%D1%8F%D1%89%D1%83%D1%80"))
            {
                return "Complete!";
            }

            var parsedUrlDirty = GetCurrentWebPage(currentUrl)
                .DocumentNode.SelectNodes("//i[@class='fa fa-long-arrow-right']//preceding-sibling::a")
                .Select(x => x.Attributes.FirstOrDefault()).FirstOrDefault();

            var parsedUrl = new StringBuilder();
            parsedUrl.Append("https://gufo.me");
            parsedUrl.Append(parsedUrlDirty.Value);

            return parsedUrl.ToString();
        }

        public string GetPageName(string url)
        {
            var parsedNameDirty = GetCurrentWebPage(url)
                 .DocumentNode.SelectNodes("//h1")
                 .Select(x => x.InnerText).FirstOrDefault();

            var parsedName = new StringBuilder();
            parsedName.Append(parsedNameDirty);

            return parsedName.ToString();
        }

        private HtmlDocument GetCurrentWebPage(string url)
        {
            var web = new HtmlWeb();
            var page = web.Load(url);

            return page;
        }
    }
}
