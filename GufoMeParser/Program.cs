using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using HtmlAgilityPack;
using GufoMeParser.FileSaving;
using GufoMeParser.Core.Agility.Interfaces;
using GufoMeParser.Core.Agility.Classes;
using System.Threading;

namespace GufoMeParser
{
    class Program
    {
        public static IParserCreator ParserCreator{ get; set;}
        public static IFileSaverCreator FileSaver { get; set; }

        static void Main(string[] args)
        {
            ParserCreator = new ParserCreator();
            FileSaver = new FileSaverCreator();

            var parser = ParserCreator.GetParser();
            var fileSaver = FileSaver.GetFileSaver();

            var urls = new List<string> { "https://gufo.me/dict/ozhegov/%D0%B0" };
            var parsing = true;
            var wordsCount = 0L;

            Console.WriteLine("Processing!");

            while (parsing)
            {
                wordsCount++;
                var currentWord = parser.GetPageName(urls.LastOrDefault());
                Console.WriteLine(currentWord);

                fileSaver.Save(parser.GetParsedTxt(urls.LastOrDefault()), currentWord).Wait();

                var nextUrl = parser.GetNextUrl(urls.LastOrDefault());

                if(nextUrl.Contains("Complete!"))
                {
                    Console.WriteLine(nextUrl + " Words count: " + wordsCount.ToString() + ".");
                    Console.ReadKey();
                    parsing = false;
                }

                urls.Add(nextUrl);

                Thread.Sleep(1000);
            }
        }
    }
}
