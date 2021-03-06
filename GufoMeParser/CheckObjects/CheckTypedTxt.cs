﻿using System;
using System.Collections.Generic;
using System.Linq;

using GufoMeParser.Parsers.Interfaces;

namespace GufoMeParser.CheckObjects
{
    public static class CheckTypedTxt
    {
        public static void CheckWroteByUserLink(List<string> urls, IParser parser)
        {
            Console.WriteLine("If u wanna start from main url, type \"continue\".");
            Console.WriteLine("For the exit press \"Ctrl + C\".");

            var nameOfParser = parser.GetType().Name.ToLower();

            if (!nameOfParser.ToLower().Contains("gufoparser") && !nameOfParser.ToLower().Contains("enacademicparser"))
            {
                throw new Exception("Typed name of name of parser is not support!");
            }

            switch (nameOfParser)
            {
                case "gufoparser":
                    {
                        CheckWroteByUserLinkGufo(urls, parser);
                        return;
                    }
                case "enacademicparser":
                    {
                        CheckWroteByUserLinkEnAcademic(urls, parser);
                        return;
                    }
            }
        }

        private static void CheckWroteByUserLinkGufo(List<string> urls, IParser parser)
        {
            var isRight = false;

            while (isRight == false)
            {
                Console.Write("Insert start url (example: https://gufo.me/dict/ozhegov/а): ");
                var readStartLink = Console.ReadLine();
                urls.Add(readStartLink);

                if (urls.Last().ToLower().Contains("continue"))
                {
                    Console.WriteLine(string.Format("Programm starting from start url: {0}", parser.MainUrl));
                    urls.RemoveAt(urls.IndexOf(urls.Last()));
                }

                if (urls.Count > 1 && !urls.Last().Contains(parser.StockUrl))
                {
                    Console.WriteLine(string.Format("The link must be like: {0}", parser.MainUrl));
                    urls.RemoveAt(urls.IndexOf(urls.Last()));

                    continue;
                }

                isRight = true;
            }
        }

        private static void CheckWroteByUserLinkEnAcademic(List<string> urls, IParser parser)
        {
            var isRight = false;

            while (isRight == false)
            {
                Console.Write("Insert start url (example: http://terms_en.enacademic.com/2205): ");
                var readStartLink = Console.ReadLine();
                urls.Add(readStartLink);

                if (urls.Last().ToLower().Contains("continue"))
                {
                    Console.WriteLine(string.Format("Programm starting from start url: {0}", parser.MainUrl));
                    urls.RemoveAt(urls.IndexOf(urls.Last()));
                }

                if (urls.Count > 1 && !urls.Last().Contains(parser.StockUrl))
                {
                    Console.WriteLine(string.Format("The link must be like: {0}", parser.MainUrl));
                    urls.RemoveAt(urls.IndexOf(urls.Last()));

                    continue;
                }

                isRight = true;
            }
        }
    }
}
