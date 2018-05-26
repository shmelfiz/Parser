using GufoMeParser.Parsers.EnAcademic.Classes;
using GufoMeParser.Parsers.GufoMe.Classes;
using GufoMeParser.Parsers.Interfaces;
using System;

namespace GufoMeParser.Parsers.Factory.Classes
{
    public class ParserCreator : IParserCreator
    {
        public IParser GetParser<T>() where T : IParser
        {
            if (typeof(T) == typeof(GufoParser))
            {
                return new GufoParser();
            }
            if(typeof(T) == typeof(EnAcademicParser))
            {
                return new EnAcademicParser();
            }

            throw new Exception("Name of type is incorrect!");
        }
    }
}
