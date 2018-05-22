namespace GufoMeParser.Parsers.GufoMe.Interfaces
{
    public interface IParserCreator
    {
        IParser GetParser<T>() where T : IParser;
    }
}
