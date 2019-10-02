using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    class SqlHelper
    {
        SqlConnection sqlconn;

        public SqlHelper(String connectionStrong) {
            sqlconn = new SqlConnection(connectionStrong);
        }

        public bool IsConnected
        {
            get
            {
                if (sqlconn.State==System.Data.ConnectionState.Closed)
                    sqlconn.Open();
                    return true;

            }
        }
    }
}
