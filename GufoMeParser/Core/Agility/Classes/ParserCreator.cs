using GufoMeParser.Core.Agility.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GufoMeParser.Core.Agility.Classes
{
    class ParserCreator : IParserCreator
    {
        public IParser GetParser()
        {
            return new Parser();
        }
    }
}
