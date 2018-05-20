using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GufoMeParser.DbRequesting
{
    public interface IRequest
    {
        void SendDataAsync(string word, string parsedTxt, string parsedHtml);
    }
}
