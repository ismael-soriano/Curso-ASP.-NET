using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.Odbc;

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

        public static DbCommand GetCommand()
        {
            if (Config.Instance.ConnectionType == ConnectionType.Odbc)
            {
                return new OdbcCommand();
            }

            return new SqlCommand();
        }

        public static DbParameter GetParameter(string parameterName, object value)
        {
            if (null == parameterName)
                throw new ArgumentNullException("parameterName");

            if (Config.Instance.ConnectionType == ConnectionType.Odbc) {
                return new OdbcParameter(parameterName, value);
            }

            return new SqlParameter(parameterName, value);
        }
    }
}
