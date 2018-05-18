using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GufoMeParser.FileSaving
{
    interface IFileSaverCreator
    {
        IFileSaver GetFileSaver();
    }
}
