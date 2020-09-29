using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepartidorOnline.Infraestructure.Database
{
    public class DatabaseUtil
    {
        public static IDbConnection CreateDBConnection()
        {

            var connectionString = ConfigurationManager.ConnectionStrings["dbConnectionRepartidor"].ConnectionString;

            return new SqlConnection(connectionString);
        }

    }
}
