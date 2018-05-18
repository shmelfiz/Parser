using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GufoMeParser.Core.Agility.Interfaces
{
    interface IParser
    {
        string GetParsedTxt(string url);

        string GetNextUrl(string currentUrl);

        string GetPageName(string url);
    }
}
