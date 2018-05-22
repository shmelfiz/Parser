using System;

namespace GufoMeParser.DbRequesting
{
    public class RequestManager : IRequestManager
    {
        public IRequest GetRequest<T>() where T : IRequest
        {
            if (typeof(T) == typeof(DescrRuRequest))
            {
                return new DescrRuRequest();
            }

            throw new Exception("This name does't exist in the RequestManager!");
        }
    }
}
