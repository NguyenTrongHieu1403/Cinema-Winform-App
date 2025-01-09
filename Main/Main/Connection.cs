using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Main
{
    internal class Connection
    {

        private static string stringConnection = @"Data Source=LAPTOP-96IDN57Q\LAPTRINH2024;Initial Catalog=CinemaDBAW;Integrated Security=True";

        public static SqlConnection GetSqlConnection()
        {
            return new SqlConnection(stringConnection);
        }

    }
}
