using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.Data;

namespace DAO
{
    public static class HelperDb
    {
        public static DbConnection GetConnection()
        {

            if (Config.Instance.ConnectionType == ConnectionType.Odbc)
            {
                return new OdbcConnection(Config.Instance.ConnectionString);
            }

            return new SqlConnection(Config.Instance.ConnectionString);
        }

        public static IDbCommand GetCommand(string sql, IDbConnection connection, Dictionary<string, object> parameters = null)
        {
            if (null == sql)
            {
                throw new ArgumentNullException("sql");
            }

            if (null == connection)
            {
                throw new ArgumentNullException("connection");
            }

            IDbCommand command = CreateCommand();
            command.CommandText = sql;
            command.Connection = connection;
            MapDictionaryToParameters(command, parameters);
            return command;
        }

        private static IDbCommand CreateCommand()
        {
            if (Config.Instance.ConnectionType == ConnectionType.Odbc)
            {
                return new OdbcCommand();
            }
                return new SqlCommand();
        }

        private static void MapDictionaryToParameters(IDbCommand command, Dictionary<string, object> parameters)
        {
            if (null != parameters)
            {
                foreach (var item in parameters)
                {
                    var param = HelperDb.GetParameter(item.Key, item.Value?? System.DBNull.Value);
                    command.Parameters.Add(param);
                }
            }
        }

        public static DbParameter GetParameter(string parameterName, object value)
        {
            if (null == parameterName)
                throw new ArgumentNullException("parameterName");

            if (Config.Instance.ConnectionType == ConnectionType.Odbc)
            {
                return new OdbcParameter(parameterName, value);
            }

            return new SqlParameter(parameterName, value);
        }
    }
}
