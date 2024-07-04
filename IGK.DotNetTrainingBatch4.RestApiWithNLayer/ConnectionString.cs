using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGK.DotNetTrainingBatch4.RestApiWithNLayer
{
    internal static class ConnectionString
    {
        public static SqlConnectionStringBuilder SqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = "AERA\\SQLEXPRESS",
            InitialCatalog = "DotNetTrainingBatch4",
            UserID = "sa",
            Password = "ingyinkhine@123",
            TrustServerCertificate = true
        };
    }
}
