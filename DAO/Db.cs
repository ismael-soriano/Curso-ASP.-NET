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
        public static int Execute(string queryString, List<DbParameter> parameters = null)
        {
            if (string.IsNullOrEmpty(queryString))
            {
                throw new ArgumentNullException("queryString");
            }

            using (var connection = HelperDb.GetConnection())
            using (DbCommand command = HelperDb.GetCommand())
            {
                connection.Open();
                PrepareCommand(command, queryString, parameters);
                command.Connection = connection;
                return command.ExecuteNonQuery();
            }
        }

        private static void PrepareCommand(DbCommand command, string queryString, List<DbParameter> parameters)
        {
            command.CommandText = queryString;
            BindParams(command, parameters);
        }

        private static void BindParams(DbCommand command, List<DbParameter> parameters)
        {
            if (null != parameters)
            {
                foreach (var item in parameters)
                {
                    command.Parameters.Add(item);
                }
            }
        }
    }
}
