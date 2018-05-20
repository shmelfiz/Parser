using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GufoMeParser.FileSaving
{
    public class FileSaverCreator : IFileSaverCreator
    {
        public IFileSaver GetFileSaver()
        {
            var fileSaver = new FileSaver();

            return fileSaver;
        }
    }
}
