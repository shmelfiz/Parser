namespace GufoMeParser.DbRequesting
{
    public interface IRequest
    {
        void SendDataAsync(string word, string parsedTxt, string parsedHtml);
    }
}
