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
    public static class CreateConnectionDb
    {
        public static DbConnection GetConnection(ConnectionType connectionType)
        {
            if (connectionType == ConnectionType.Odbc)
            {
                return new OdbcConnection();
            }

            return new SqlConnection();
        }
    }
}
