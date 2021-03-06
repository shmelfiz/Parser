﻿using GufoMeParser.Parsers.Interfaces;
using HtmlAgilityPack;
using System;
using System.Linq;
using System.Text;

namespace GufoMeParser.Parsers.GufoMe.Classes
{
    public class GufoParser : IParser
    {
        public string MainUrl => "https://gufo.me/dict/ozhegov/а";
        public string StockUrl => "https://gufo.me/dict/ozhegov/";

        public string GetParsedTxt(string url)
        {
            var parsedTxtDirty = GetWebPage(url)
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
                return "Complete!";  //костылец
            }

            var parsedUrlDirty = GetWebPage(currentUrl)
                .DocumentNode.SelectNodes("//i[@class='fa fa-long-arrow-right']//preceding-sibling::a")
                .Select(x => x.Attributes.FirstOrDefault()).FirstOrDefault();

            var parsedUrl = new StringBuilder();
            parsedUrl.Append("\n");
            parsedUrl.Append("https://gufo.me");
            parsedUrl.Append(parsedUrlDirty.Value);

            return parsedUrl.ToString();
        }

        public string GetPageName(string url)
        {
            try
            {
                var parsedNameDirty = GetWebPage(url)
                     .DocumentNode.SelectNodes("//h1")
                     .Select(x => x.InnerText).FirstOrDefault();

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
                .SelectNodes("//p")
                .Select(x => x.OuterHtml);

            foreach(string parsedNode in parsedHtmlSplitted)
            {
                parsedHtml.Append(parsedNode);
            }

            return parsedHtml.ToString(); ;
        }
    }
}
