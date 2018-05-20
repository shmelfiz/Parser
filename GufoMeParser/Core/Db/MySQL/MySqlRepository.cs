using GufoMeParser.Core.MySQL.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
