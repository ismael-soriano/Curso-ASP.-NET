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
            args = new string[] { "Pepito" };
            if (null == args)
            {
                throw new ArgumentNullException("args");
            }

            var sql = "insert into [Table](Name) Values(@name)";
            var parameters = new Dictionary<string,object>()
            {
                {"@name", args[0]}
            };
            var command = HelperDb.GetCommand(HelperDb.GetConnection(), sql, parameters);

            return Db.Execute(command);
        }
    }
}
