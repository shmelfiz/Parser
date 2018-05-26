using System;
using System.Collections.Generic;
using System.Linq;

using GufoMeParser.Parsers.GufoMe.Interfaces;

namespace GufoMeParser.CheckObjects
{
    public static class CheckTypedTxt
    {
        public static void CheckWroteByUserLink(List<string> urls, IParser parser)
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
    }
}
