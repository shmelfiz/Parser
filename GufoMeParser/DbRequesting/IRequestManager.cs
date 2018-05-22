namespace GufoMeParser.DbRequesting
{
    public interface IRequestManager
    {
        IRequest GetRequest<T>() where T : IRequest;
    }
}
