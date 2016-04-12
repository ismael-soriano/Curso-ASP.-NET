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
        public static int Execute(string queryString, Dictionary<string, object> parameters = null)
        {
            if (string.IsNullOrEmpty(queryString))
            {
                throw new ArgumentNullException("queryString");
            }

            using (var connection = HelperDb.GetConnection())
            using (var command = HelperDb.GetCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = queryString;
                MapDictionaryToParameters(command, parameters);
                return command.ExecuteNonQuery();
            }
        }

        private static void MapDictionaryToParameters(DbCommand command, Dictionary<string, object> parameters)
        {
            if (null != parameters)
            {
                foreach (var item in parameters)
                {
                    var param = HelperDb.GetParameter(item.Key, item.Value);
                    command.Parameters.Add(param);
                }
            }
        }
    }
}
