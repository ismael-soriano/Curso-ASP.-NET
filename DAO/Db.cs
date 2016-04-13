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
        public static int Execute(IDbCommand command)
        {
            if (null == command)
            {
                throw new ArgumentNullException("command");
            }

            using (command.Connection)
            using (command)
            {
                command.Connection.Open();
                return command.ExecuteNonQuery();
            }
        }


    }
}
