using System;
using System.Collections.Generic;
using System.Linq;

using GufoMeParser.FileSaving;
using GufoMeParser.Parsers.GufoMe.Interfaces;
using GufoMeParser.Parsers.GufoMe.Classes;
using System.Threading;
using GufoMeParser.Core;
using GufoMeParser.DbRequesting;
using GufoMeParser.CheckObjects;

namespace GufoMeParser
{
    class Program
    {
        private static IParserCreator ParserCreator{ get; set;}
        private static IFileSaverCreator FileSaver { get; set; }
        private static IRequestManager DbRequestManager { get; set; }

        static void Main(string[] args)
        {
            InitializeIoC();
            var parser = ParserCreator.GetParser<GufoParser>();
            var fileSaver = FileSaver.GetFileSaver();
            var request = DbRequestManager.GetRequest<DescrRuRequest>();

            RunParser(parser, fileSaver, request);
        }
        private static void InitializeIoC()
        {
            ParserCreator = Container.Resolve<IParserCreator>();
            FileSaver = Container.Resolve<IFileSaverCreator>();
            DbRequestManager = Container.Resolve<IRequestManager>();
        }

        private static void RunParser(IParser parser, IFileSaver fileSaver, IRequest request)
        {
            var parsing = true;
            var wordsCount = 0L;
            List<string> urls = new List<string> { parser.MainUrl };

            Console.WriteLine("If u wanna start from main url, type \"continue\".");
            Console.WriteLine("For the exit press \"Ctrl + C\".");
            CheckTypedTxt.CheckWroteByUserLink(urls, parser);

            Console.WriteLine("Processing!");

            while (parsing)
            {
                wordsCount++;
                var currentWord = parser.GetPageName(urls.LastOrDefault());
                var parsedTxt = parser.GetParsedTxt(urls.LastOrDefault());
                var parsedHtml = parser.GetParsedHtml(urls.LastOrDefault());

                fileSaver.Save(parsedTxt, currentWord, (int)Resources.ParsedTxt).Wait();
                fileSaver.Save(parsedHtml, currentWord, (int)Resources.ParsedHtml).Wait();

                request.SendDataAsync(currentWord, parsedTxt, parsedHtml);

                var nextUrl = parser.GetNextUrl(urls.LastOrDefault());
                fileSaver.Save(nextUrl, "Links", (int)Resources.ParsedLink).Wait();

                urls.Add(nextUrl);

                Console.WriteLine(currentWord);
                Console.CancelKeyPress += Cancel;

                Thread.Sleep(1000);
            }
        }       

        private static void Cancel(object sender, ConsoleCancelEventArgs args)
        {
            if(args.Cancel)
            {
                Environment.Exit(0);
            }
        }
    }
}
