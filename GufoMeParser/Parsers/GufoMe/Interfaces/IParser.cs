using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GufoMeParser.Parsers.GufoMe.Interfaces
{
    public interface IParser
    {
        List<string> MainUrl { get; }

        string GetParsedTxt(string url);

        string GetNextUrl(string currentUrl);

        string GetPageName(string url);

        string GetParsedHtml(string url);

    }
}
