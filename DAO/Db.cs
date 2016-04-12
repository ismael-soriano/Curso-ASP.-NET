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
    public class Db
    {
        public static int Execute(string queryString)
        {
            if (string.IsNullOrEmpty(queryString))
            {
                throw new ArgumentNullException("queryString");
            }

            using (var connection = HelperDb.GetConnection())
            using (DbCommand command = HelperDb.GetCommand())
            {
                command.CommandText = queryString;
                connection.Open();
                command.Connection = connection;
                return command.ExecuteNonQuery();
            }
        }
    }
}
