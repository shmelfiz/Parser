using GufoMeParser.Core.MySQL.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GufoMeParser.Core.Db
{
    public interface IRepository
    {
        MySQLContext DbContext { get; }
    }
}
