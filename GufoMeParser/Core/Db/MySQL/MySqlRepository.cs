using GufoMeParser.Core.MySQL.Db;
using System;

namespace GufoMeParser.Core.Db.MySQL
{
    public class MySqlRepository : IDisposable, IRepository
    {
        public MySQLContext DbContext { get; private set; }

        public MySqlRepository()
        {
            DbContext = new MySQLContext();
        }

        public void Dispose()
        {
            DbContext.Dispose();
        }
    }
}
