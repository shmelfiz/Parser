using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GufoMeParser.FileSaving
{
    interface IFileSaver
    {
        Task Save(string text, string name);
    }
}
