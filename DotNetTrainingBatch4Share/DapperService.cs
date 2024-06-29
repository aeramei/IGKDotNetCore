using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace DotNetTrainingBatch4Share
{
    public class DapperService
    {
        private readonly string _connectionString;

        public DapperService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<M> Query<M>( string query, object? param = null)
        {
            using IDbConnection aera = new SqlConnection(_connectionString);
            var lst = aera.Query<M>(query, param).ToList();
            return lst;
        }

        public int Execute( string query, object? param = null)
        {
           using IDbConnection aera = new SqlConnection(_connectionString);
            var result =  aera.Execute(query, param);
            return result;
        }

        public M QueryFirstOrDefault<M>(string query, object? param = null)
        {
            using IDbConnection aera = new SqlConnection(_connectionString);
            var item = aera.Query<M>(query, param).FirstOrDefault();
            return item;
        }

    }
}
