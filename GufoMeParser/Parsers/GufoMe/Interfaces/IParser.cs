namespace GufoMeParser.Parsers.GufoMe.Interfaces
{
    public interface IParser
    {
        string MainUrl { get;}
        string StockUrl { get; }
        string GetParsedTxt(string url);
        string GetNextUrl(string currentUrl);
        string GetPageName(string url);
        string GetParsedHtml(string url);

    }
}
