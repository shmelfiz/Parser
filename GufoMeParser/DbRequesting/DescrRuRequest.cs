using System;

using GufoMeParser.Core;
using GufoMeParser.Core.Db;
using MySql.Data.MySqlClient;

namespace GufoMeParser.DbRequesting
{
    public class DescrRuRequest : IRequest
    {
        private IRepository _Repository { get; set; }

        public DescrRuRequest()
        {
            _Repository = Container.Resolve<IRepository>();
        }

        public async void SendDataAsync(string word, string parsedTxt, string parsedHtml)
        {
            try
            {
                await _Repository.DbContext.Database
                    .ExecuteSqlCommandAsync("call DictWordRu(@Wordfrom, @Descript, @Descript2)",
                    new MySqlParameter("@Wordfrom", word),
                    new MySqlParameter("@Descript", parsedTxt),
                     new MySqlParameter("@Descript2", parsedHtml));
            }
            catch
            {
                throw new Exception("Проблема записи в БД!");
            }
        }
    }
}
