using System;
using System.Collections.Generic;
using System.Linq;

using GufoMeParser.FileSaving;
using GufoMeParser.Parsers.Interfaces;
using GufoMeParser.Parsers.GufoMe.Classes;
using System.Threading;
using GufoMeParser.Core;
using GufoMeParser.DbRequesting;
using GufoMeParser.CheckObjects;
using GufoMeParser.Parsers.EnAcademic.Classes;

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

            InitializeParser(out IParser parser, out IFileSaver fileSaver, out IRequest request);

            RunParser(parser, fileSaver, request);
        }
        private static void InitializeIoC()
        {
            ParserCreator = Container.Resolve<IParserCreator>();
            FileSaver = Container.Resolve<IFileSaverCreator>();
            DbRequestManager = Container.Resolve<IRequestManager>();
        }

        private static void InitializeParser(out IParser parser, out IFileSaver fileSaver, out IRequest request)
        {
            parser = null;
            fileSaver = null;
            request = null;

            Console.Write("Type \"Gufo\" or \"EnAcademic\": ");
            var nameOfParser = Console.ReadLine().ToLower();

            if (!nameOfParser.ToLower().Contains("gufo") && !nameOfParser.ToLower().Contains("enacademic"))
            {
                throw new Exception("Typed name of name of parser is not support!");
            }

            switch (nameOfParser)
            {
                case "gufo":
                    {
                        parser = ParserCreator.GetParser<GufoParser>();
                        fileSaver = FileSaver.GetFileSaver();
                        request = DbRequestManager.GetRequest<DescrRuRequest>();
                        return;
                    }
                case "enacademic":
                    {
                        parser = ParserCreator.GetParser<EnAcademicParser>();
                        fileSaver = FileSaver.GetFileSaver();
                        request = DbRequestManager.GetRequest<DescrEnRequest>();
                        return;
                    }
            }           
        }

        private static void RunParser(IParser parser, IFileSaver fileSaver, IRequest request)
        {
            var parsing = true;
            var wordsCount = 0L;
            List<string> urls = new List<string> { parser.MainUrl };

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

                if(nextUrl.ToLower().Contains("complete"))
                {
                    parsing = false;
                }

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
