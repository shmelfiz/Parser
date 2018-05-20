using GufoMeParser.Parsers.GufoMe.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GufoMeParser.Parsers.GufoMe.Classes
{
    public class ParserCreator : IParserCreator
    {
        public IParser GetParser<T>() where T : IParser
        {
            if (typeof(T) == typeof(GufoParser))
            {
                return new GufoParser();
            }

            throw new Exception("Name of type is incorrect!");
        }
    }
}
