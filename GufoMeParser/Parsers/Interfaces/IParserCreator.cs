namespace GufoMeParser.Parsers.Interfaces
{
    public interface IParserCreator
    {
        IParser GetParser<T>() where T : IParser;
    }
}
