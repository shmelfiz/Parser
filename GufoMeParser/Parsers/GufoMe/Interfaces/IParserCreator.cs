using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GufoMeParser.Parsers.GufoMe.Interfaces
{
    public interface IParserCreator
    {
        IParser GetParser<T>() where T : IParser;
    }
}
