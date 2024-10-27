using dapper_api.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace dapper_api.Models
{
    public class ApiDbContext : IApiDbContext
    {
        private readonly string _connectionString;

        public ApiDbContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING");
        }

        public IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
