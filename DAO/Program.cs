using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Data.SqlClient;

namespace DAO
{
    class Program
    {
        static int Main(string[] args)
        {
            if (null == args)
                throw new ArgumentNullException("args");

            var sql = "insert into [Table](Name) Values(@name)";
            return Db.Execute(sql, new List<DbParameter>()
            {
                HelperDb.GetParameter("@name", args[0])
            });
        }
    }
}
